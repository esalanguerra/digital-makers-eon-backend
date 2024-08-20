using Microsoft.EntityFrameworkCore;

using Eon.Com.Application.Configurations.Cors;
using Eon.Com.Application.Configurations.Database.Postgresql;

using Eon.Com.Api.Mvc.UserMvc.Service;
using Eon.Com.Api.Mvc.TeamMvc.Service;
using Eon.Com.Api.Mvc.TagMvc.Service;
using Eon.Com.Api.Mvc.SectorMvc.Service;
using Eon.Com.Api.Mvc.MessageSchedulingMvc.Service;
using Eon.Com.Api.Mvc.FolderMvc.Service;
using Eon.Com.Api.Mvc.FlowSharedMvc.Service;

using Eon.Com.Data.Factories.UserFactory;
using Eon.Com.Data.Factories.TeamFactory;
using Eon.Com.Data.Factories.TagFactory;
using Eon.Com.Data.Factories.SectorFactory;
using Eon.Com.Data.Factories.MessageSchedulingFactory;
using Eon.Com.Data.Factories.FolderFactory;
using Eon.Com.Data.Factories.FlowSharedFactory;

using Eon.Data.Repositories.UserRepository;
using Eon.Data.Repositories.TeamRepository;
using Eon.Data.Repositories.TagRepository;
using Eon.Data.Repositories.SectorRepository;
using Eon.Data.Repositories.MessageSchedulingRepository;
using Eon.Data.Repositories.FolderRepository;
using Eon.Data.Repositories.FlowSharedRepository;

using Eon.Com.Interfaces.Factories.UserFactory;
using Eon.Com.Interfaces.Repositories.UserRepository;
using Eon.Com.Interfaces.Services.UserService;
using Eon.Com.Interfaces.Factories.TeamFactory;
using Eon.Com.Interfaces.Repositories.TeamRepository;
using Eon.Com.Interfaces.Services.TeamService;
using Eon.Com.Interfaces.Factories.TagFactory;
using Eon.Com.Interfaces.Repositories.TagRepository;
using Eon.Com.Interfaces.Services.TagService;
using Eon.Com.Interfaces.Factories.SectorFactory;
using Eon.Com.Interfaces.Repositories.SectorRepository;
using Eon.Com.Interfaces.Services.SectorService;
using Eon.Com.Interfaces.Factories.MessageSchedulingFactory;
using Eon.Com.Interfaces.Repositories.MessageSchedulingRepository;
using Eon.Com.Interfaces.Services.MessageSchedulingService;
using Eon.Com.Interfaces.Factories.FolderFactory;
using Eon.Com.Interfaces.Repositories.FolderRepository;
using Eon.Com.Interfaces.Services.FolderService;
using Eon.Com.Interfaces.Factories.FlowSharedFactory;
using Eon.Com.Interfaces.Repositories.FlowSharedRepository;
using Eon.Com.Interfaces.Services.FlowSharedService;


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
builder.Services.AddTransient<ITeamRepositoryInterface, TeamRepository>();
builder.Services.AddTransient<ITagRepositoryInterface, TagRepository>();
builder.Services.AddTransient<ISectorRepositoryInterface, SectorRepository>();
builder.Services.AddTransient<IMessageSchedulingRepositoryInterface, MessageSchedulingRepository>();
builder.Services.AddTransient<IFolderRepositoryInterface, FolderRepository>();
builder.Services.AddTransient<IFlowSharedRepositoryInterface, FlowSharedRepository>();

// Configuração de injeção de dependência para a fábrica de usuários.
// IUserFactoryInterface é implementado pela classe UserFactory.
builder.Services.AddTransient<IUserFactoryInterface, UserFactory>();
builder.Services.AddTransient<ITeamFactoryInterface, TeamFactory>();
builder.Services.AddTransient<ITagFactoryInterface, TagFactory>();
builder.Services.AddTransient<ISectorFactoryInterface, SectorFactory>();
builder.Services.AddTransient<IMessageSchedulingFactoryInterface, MessageSchedulingFactory>();
builder.Services.AddTransient<IFolderFactoryInterface, FolderFactory>();
builder.Services.AddTransient<IFlowSharedFactoryInterface, FlowSharedFactory>();

// Configuração de injeção de dependência para o serviço de usuários.
// IUserServiceInterface é implementado pela classe UserService.
builder.Services.AddTransient<IUserServiceInterface, UserService>();
builder.Services.AddTransient<ITeamServiceInterface, TeamService>();
builder.Services.AddTransient<ITagServiceInterface, TagService>();
builder.Services.AddTransient<ISectorServiceInterface, SectorService>();
builder.Services.AddTransient<IMessageSchedulingServiceInterface, MessageSchedulingService>();
builder.Services.AddTransient<IFolderServiceInterface, FolderService>();
builder.Services.AddTransient<IFlowSharedServiceInterface, FlowSharedService>();

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
