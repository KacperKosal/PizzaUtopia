using Microsoft.AspNetCore.Http;
using PizzaUtopia.Backend.Context;
using PizzaUtopia.Backend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<PizzaUtopiaDbContext>();

builder.Services.AddServerSideBlazor();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSession();

app.MapGet("/", (HttpContext context) =>
{
    int visitCount = context.Session.GetInt32("VisitCount") ?? 0;
    visitCount++;
    context.Session.SetInt32("VisitCount", visitCount);
    return $"Backend serwisu PizzaUtopia - Visit Count: {visitCount}";
});

app.MapPost("/register", (PizzaUtopiaDbContext dbContext, User user) =>
{
    dbContext.Users.Add(user);
    dbContext.SaveChanges();
    return Results.Created($"/user/{user.Id}", user);
});

app.Run();
