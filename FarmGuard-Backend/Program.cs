using FarmGuard_Backend.Animals.Application.Internal.ComandServices;
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
using FarmGuard_Backend.Notifications.Domain.Repositories;
using FarmGuard_Backend.Notifications.Infrastructure.Persistence.EFC.Repositories;
using FarmGuard_Backend.Shared.Domain.Repositories;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration.Extensions;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Repositories;
using FarmGuard_Backend.Shared.Interfaces.ASP.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (connectionString != null)
    {
        if (builder.Environment.IsDevelopment())
            options.UseMySQL(connectionString).LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging().EnableDetailedErrors();
        else if (builder.Environment.IsProduction())
            options.UseMySQL(connectionString).LogTo(Console.WriteLine, LogLevel.Error).EnableDetailedErrors();
    }
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
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

builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IAnimalCommandService, AnimalCommandService>();
builder.Services.AddScoped<IAnimalQueryService, AnimalQueryService>();
builder.Services.AddScoped<IIventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IInventoryCommandService, InventoryCommandService>();
builder.Services.AddScoped<IInventoryQueryService, InventoryQueryService>();
builder.Services.AddScoped<IVaccineRepository, VaccineRepository>();
builder.Services.AddScoped<IVaccineCommandService, VaccineCommandService>();
builder.Services.AddScoped<IVaccineQueryService, VaccineQueryService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<NotificationCommandService>();
builder.Services.AddScoped<IAnimalContextFacade, AnimalContextFacade>();
builder.Services.AddScoped<ExternalAnimalService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();