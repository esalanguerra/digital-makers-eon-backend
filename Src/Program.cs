using Eon.Configurations.Database;
using Eon.Configurations.Cors;
using Microsoft.EntityFrameworkCore;

using Eon.Data.Repositories;
using Eon.Data.Factories;

using Eon.Data.Interfaces.IServices;
using Eon.Data.Interfaces.IFactories;
using Eon.Data.Interfaces.IRepositories;

using Eon.Api.Services.UserService;
using Eon.Api.Services.FolderService;
using Eon.Api.Services.FlowService;
using Eon.Api.Services.TagService;
using Eon.Api.Services.FlowSharedService;
using Eon.Api.Services.MessageSchedulingService;
using Eon.Api.Services.SectorService;
using Eon.Api.Services.TeamService;
using Eon.Api.Services.TokenService;

var builder = WebApplication.CreateBuilder(args);

// Adicione serviços ao contêiner.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção de dependências de repositórios
builder.Services.AddTransient<IUserRepositoryInterface, UserRepository>();
builder.Services.AddTransient<IFolderRepositoryInterface, FolderRepository>();
builder.Services.AddTransient<IFlowRepositoryInterface, FlowRepository>();
builder.Services.AddTransient<ITagRepositoryInterface, TagRepository>();
builder.Services.AddTransient<IFlowSharedRepositoryInterface, FlowSharedRepository>();
builder.Services.AddTransient<IMessageSchedulingRepositoryInterface, MessageSchedulingRepository>();
builder.Services.AddTransient<ISectorRepositoryInterface, SectorRepository>();
builder.Services.AddTransient<ITeamRepositoryInterface, TeamRepository>();
builder.Services.AddTransient<ITokenRepositoryInterface, TokenRepository>();

// Injeção de dependências de fábricas
builder.Services.AddTransient<IUserFactoryInterface, UserFactory>();
builder.Services.AddTransient<IFolderFactoryInterface, FolderFactory>();
builder.Services.AddTransient<IFlowFactoryInterface, FlowFactory>();
builder.Services.AddTransient<ITagFactoryInterface, TagFactory>();
builder.Services.AddTransient<IFlowSharedFactoryInterface, FlowSharedFactory>();
builder.Services.AddTransient<IMessageSchedulingFactoryInterface, MessageSchedulingFactory>();
builder.Services.AddTransient<ISectorFactoryInterface, SectorFactory>();
builder.Services.AddTransient<ITeamFactoryInterface, TeamFactory>();
builder.Services.AddTransient<ITokenFactoryInterface, TokenFactory>();

// Adicione o registro dos serviços
builder.Services.AddTransient<IUserServiceInterface, UserService>();
builder.Services.AddTransient<IFolderServiceInterface, FolderService>();
builder.Services.AddTransient<IFlowServiceInterface, FlowService>();
builder.Services.AddTransient<ITagServiceInterface, TagService>();
builder.Services.AddTransient<IFlowSharedServiceInterface, FlowSharedService>();
builder.Services.AddTransient<IMessageSchedulingServiceInterface, MessageSchedulingService>();
builder.Services.AddTransient<ISectorServiceInterface, SectorService>();
builder.Services.AddTransient<ITeamServiceInterface, TeamService>();
builder.Services.AddTransient<ITokenServiceInterface, TokenService>();

// Configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("ApiCorsPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Configurar o DbContext para usar PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionar suporte para controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure o pipeline de solicitação HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("ApiCorsPolicy");

app.MapControllers();

app.Run();
