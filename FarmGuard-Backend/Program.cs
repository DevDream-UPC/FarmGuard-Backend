using FarmGuard_Backend.Animals.Application.Internal.ComandServices;
using FarmGuard_Backend.Animals.Application.Internal.OutboundServices;
using FarmGuard_Backend.Animals.Application.Internal.QueryServices;
using FarmGuard_Backend.Animals.Domain.Repositories;
using FarmGuard_Backend.Animals.Domain.Services;
using FarmGuard_Backend.Animals.Infrastructure.Persistence.EFC.Repositories;
using FarmGuard_Backend.Animals.Interfaces.Acl;
using FarmGuard_Backend.Animals.Interfaces.Acl.Services;
using FarmGuard_Backend.MedicHistory.Application.Internal.ComandServices;
using FarmGuard_Backend.MedicHistory.Application.Internal.OutboundServices;
using FarmGuard_Backend.MedicHistory.Application.Internal.QueryServices;
using FarmGuard_Backend.MedicHistory.Domain.Repositories;
using FarmGuard_Backend.MedicHistory.Domain.Services;
using FarmGuard_Backend.MedicHistory.Infrastructure.Persistence.EFC.Repositories;
using FarmGuard_Backend.Notifications.Application.Internal.CommandServices;
using FarmGuard_Backend.Notifications.Application.Internal.QueryService;
using FarmGuard_Backend.Notifications.Domain.Repositories;
using FarmGuard_Backend.Notifications.Domain.Services;
using FarmGuard_Backend.Notifications.Infrastructure.Persistence.EFC.Repositories;
using FarmGuard_Backend.Notifications.Interfaces.Rest.Acl;
using FarmGuard_Backend.Notifications.Interfaces.Rest.Acl.Services;
using FarmGuard_Backend.profile.Application.Internal.ComandServices;
using FarmGuard_Backend.profile.Application.Internal.OutboundServices;
using FarmGuard_Backend.profile.Domain.Repositories;
using FarmGuard_Backend.profile.Domain.Services;
using FarmGuard_Backend.profile.Infrastructure.Persistence.EFC.Repositories;
using FarmGuard_Backend.Shared.Domain.Repositories;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration.Extensions;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Repositories;
using FarmGuard_Backend.Shared.Interfaces.ASP.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

/*Configuracion LowerCaseUrl*/
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers( options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

/*Añadir Conexion DB*/
/*
*/
var connectionSrting = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? builder.Configuration.GetConnectionString("DefaultConnection");
/*Configurar Contexto de la DB and niveles de loggin*/

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionSrting != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionSrting)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionSrting)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();
    }
);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "DevDream.FarmGuard.Api",
                Version = "v1",
                Description = "DevDream FarmGuard Platform Api",
                TermsOfService = new Uri("https://example.com/terms"),
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
    });

/*Configure Lowercase URLs*/
builder.Services.AddRouting(options => options.LowercaseUrls = true);

/*Configurar la inyeccion de dependencias*/

//----------------Animal BoundedContext---------------------
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IAnimalCommandService, AnimalCommandService>();
builder.Services.AddScoped<IAnimalQueryService, AnimalQueryService>();

builder.Services.AddScoped<IIventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IInventoryCommandService, InventoryCommandService>();
builder.Services.AddScoped<IInventoryQueryService, InventoryQueryService>();

//----------------MedicalHistory BoundedContext---------------------
builder.Services.AddScoped<IVaccineRepository, VaccineRepository>();
builder.Services.AddScoped<IVaccineCommandService, VaccineCommandService>();
builder.Services.AddScoped<IVaccineQueryService,VaccineQueryService>();

//----------------Profile BoundedContext---------------------
builder.Services.AddScoped<IProfileRepository,ProfileRepository>();
builder.Services.AddScoped<IProfileCommandService,ProfileCommandService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//----------------Notification BoundedContext---------------------
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationCommandService,NotificationCommandService>();
builder.Services.AddScoped<INotificationQuerieService, NotificationQueryService>();

//----------------External Services BoundedContext---------------------
builder.Services.AddScoped<IAnimalContextFacade, AnimalContextFacade>();
builder.Services.AddScoped<ExternalAnimalService>();

builder.Services.AddScoped<IInventoryContextFacade, InventoryContextFacade>();
builder.Services.AddScoped<ExternalInventoryService>();

builder.Services.AddScoped<INotificationContextFacade, NotificationContextFacade>();
builder.Services.AddScoped<ExternalNotificationService>();

/* Add CORS Policy*/
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});


var app = builder.Build();

/* Verify Database Objects are created*/
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();