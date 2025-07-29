using Microsoft.EntityFrameworkCore;
using Serilog;
using team_mapper_application;
using team_mapper_application.Interfaces;
using team_mapper_application.Services;
using team_mapper_infrastructure;
using team_mapper_infrastructure.Infrastructure;
using team_mapper_infrastructure.Interfaces;
using team_mapper_infrastructure.RepositoryPattern;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IWorkItemsManager, WorkItemsManager>();
builder.Services.AddScoped<IWorkItemService, WorkItemService>();
builder.Services.AddScoped<IPollyPolicyWrapper, PollyPolicyWrapper>();
builder.Services.AddScoped<IExpiringWorkItemsCronService, ExpiringWorkItemsCronService>();
builder.Services.AddHostedService<ConsumeScopedExpiringWorkItems>();

var connectionString = builder.Configuration.GetConnectionString("TeamMapperDb");
builder.Services.AddHealthChecks();
builder.Services.AddHealthChecks().AddDbContextCheck<ApplicationDbContext>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapGet("/", context =>
    {
        context.Response.Redirect("/swagger");
        return Task.CompletedTask;
    });
}

app.MapHealthChecks("/health");
app.MapHealthChecks("/efcorehealth");
app.UseHttpsRedirection();
app.UseCors();
app.MapControllers();
app.UseSerilogRequestLogging();

await app.RunAsync();
