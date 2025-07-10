using team_mapper_infrastructure.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSqlServer<AppDbContext>(builder.Configuration["ConnectionStrings:TeamMapperDb"]);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

await app.RunAsync();
