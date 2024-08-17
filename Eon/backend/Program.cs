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

// Adiciona serviços ao contêiner de injeção de dependência.
// O EndpointsApiExplorer é usado para gerar informações de metadados de endpoints.
// SwaggerGen é adicionado para suportar a documentação da API com Swagger/OpenAPI.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona a política de CORS, que pode ser configurada em Eon.Com.Application.Configurations.Cors.
builder.Services.AddCorsPolicy();

// Configura o DbContext para usar PostgreSQL com a string de conexão definida no appsettings.json.
// O ApplicationDbContext deve ser configurado para acessar a base de dados.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuração de injeção de dependência para o repositório de usuários.
// IUserRepositoryInterface é implementado pela classe UserRepository.
builder.Services.AddTransient<IUserRepositoryInterface, UserRepository>();

// Configuração de injeção de dependência para a fábrica de usuários.
// IUserFactoryInterface é implementado pela classe UserFactory.
builder.Services.AddTransient<IUserFactoryInterface, UserFactory>();

// Configuração de injeção de dependência para o serviço de usuários.
// IUserServiceInterface é implementado pela classe UserService.
builder.Services.AddTransient<IUserServiceInterface, UserService>();

// Adiciona suporte para controllers e APIs.
builder.Services.AddControllers();

var app = builder.Build();

// Configuração do pipeline de requisição HTTP.
// Em ambiente de desenvolvimento, Swagger e SwaggerUI são habilitados para documentação da API.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilita redirecionamento de HTTP para HTTPS.
app.UseHttpsRedirection();

// Habilita a autorização com base em políticas configuradas.
app.UseAuthorization();

// Aplica a política de CORS definida anteriormente.
app.UseCorsPolicy();

// Mapeia os controllers para as rotas.
app.MapControllers();

// Define um endpoint básico "/health" que retorna uma mensagem "ok" para verificação de saúde do serviço.
app.MapGet("/", () => Results.Ok("ok"));

// Executa a aplicação.
app.Run();
