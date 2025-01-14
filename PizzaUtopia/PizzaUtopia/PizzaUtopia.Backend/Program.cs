using PizzaUtopia.Backend.Context;
using PizzaUtopia.Backend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<PizzaUtopiaDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/", () => "Backend serwisu PizzaUtopia");

app.MapPost("/register", (PizzaUtopiaDbContext dbContext, User user) =>
{
    dbContext.Users.Add(user);
    dbContext.SaveChanges();
    return Results.Created($"/user/{user.Id}", user);
});

app.Run();

