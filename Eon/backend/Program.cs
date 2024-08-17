using Eon.Com.Api.Mvc.UserMvc.Service;
using Eon.Com.Application.Configurations.Cors;
using Eon.Com.Application.Configurations.Database.Postgresql;
using Eon.Com.Data.Factories.UserFactory;
using Eon.Com.Interfaces.Factories.UserFactory;
using Eon.Com.Interfaces.Repositories.UserRepository;
using Eon.Com.Interfaces.Services.UserService;
using Eon.Data.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona a política de CORS
builder.Services.AddCorsPolicy();

// Configurar o DbContext para usar PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Injeção de dependências de repositórios
builder.Services.AddTransient<IUserRepositoryInterface, UserRepository>();

// Injeção de dependências de fábricas
builder.Services.AddTransient<IUserFactoryInterface, UserFactory>();

// Adicione o registro dos serviços
builder.Services.AddTransient<IUserServiceInterface, UserService>();

// Adicionar suporte para controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCorsPolicy();
app.MapControllers();

// Define o endpoint "/health" que retorna uma mensagem "ok"
app.MapGet("/", () => Results.Ok("ok"));

app.Run();
