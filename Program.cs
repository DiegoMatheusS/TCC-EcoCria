using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TCCEcoCria.Data;
using TCCEcoCria.Interfaces;
using TCCEcoCria.Mappings;
using TCCEcoCria.Rest;
using TCCEcoCria.Services;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// 2. Banco de Dados (Certifique-se que o nome "ConexaoSomee" no appsettings.json está idêntico)
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoSomee"));
    
});

// 3. Injeção de Dependências
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddSingleton<IEnderecoServices, EnderecoService>();
builder.Services.AddSingleton<IBrasilApi, BrasilApiRest>();

builder.Services.AddAutoMapper(typeof(EnderecoMapping));

builder.Services.AddControllers();

// 4. Swagger (Configuração necessária para rodar em subpastas da Somee)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Minha API", Version = "v1" });
});

// 5. Autenticação JWT
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(
                builder.Configuration.GetSection("ConfiguracaoToken:Chave").Value!)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Logging.AddConsole();

var app = builder.Build();

// 6. Tratamento de Erros (Habilitando página de erro detalhada para te ajudar no debug)
if (app.Environment.IsDevelopment() || true) // Deixei "true" para você ver o erro real na Somee
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

// 7. Middlewares
// app.UseHttpsRedirection(); // Comentei para evitar erro 500 em planos sem SSL da Somee
app.UseStaticFiles();
app.UseRouting();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

// 8. Swagger UI (Ajustado para o link /site/)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("v1/swagger.json", "Minha API V1");
    c.RoutePrefix = "swagger"; // O link será ecocria.somee.com/site/swagger
});

app.MapControllers();

app.Run();