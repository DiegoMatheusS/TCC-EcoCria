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

// Carregar a configuração do e-mail
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<IEmailService, EmailService>();  // Registrar o serviço de email

// Configuração do DbContext com a conexão ao banco de dados
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoLocal"));
});

// Registra outros serviços
builder.Services.AddSingleton<IEnderecoServices, EnderecoService>();
builder.Services.AddSingleton<IBrasilApi, BrasilApiRest>();

// Configuração do AutoMapper
builder.Services.AddAutoMapper(typeof(EnderecoMapping));

// Configuração dos controladores da aplicação
builder.Services.AddControllers();

// Configuração do Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Minha API", Version = "v1" });
});

// Configuração do JWT (caso necessário)
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("ConfiguracaoToken:Chave").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

// Configuração da aplicação
var app = builder.Build();

// Configurações de ambiente
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Configuração do pipeline de requisições
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Ativa a autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();

// Habilita o Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1");
});

// Mapeamento de endpoints
app.MapControllers();

// Inicializa a aplicação
app.Run();
