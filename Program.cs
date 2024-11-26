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

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<IEmailService, EmailService>();



// Registra o DbContext (banco de dados) com a conexão
builder.Services.AddDbContext<DataContext>(options =>
{
   options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoLocal"));
});

// Registra outros serviços
builder.Services.AddSingleton<IEnderecoServices, EnderecoService>();
builder.Services.AddSingleton<IBrasilApi, BrasilApiRest>();

// Registra o AutoMapper
builder.Services.AddAutoMapper(typeof(EnderecoMapping));

// Adiciona os controladores da aplicação
builder.Services.AddControllers();

// Configuração do Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Minha API", Version = "v1" });
});

// Configura a autenticação JWT (caso necessário)
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

var app = builder.Build();

// Configura o pipeline de requisições
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Usa a autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();

// Habilita o Swagger
app.UseSwagger();

// Habilita a UI do Swagger
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1");
});

// Configuração de endpoints
app.MapControllers();

// Run da aplicação
app.Run();

// Exemplo de definição de um endpoint de previsão do tempo (como no seu código original)
app.MapGet("/weatherforecast", () =>
{
    var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
