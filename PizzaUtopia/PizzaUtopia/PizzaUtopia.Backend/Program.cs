using PizzaUtopia.Backend.Context;
using PizzaUtopia.Backend.Dto;
using PizzaUtopia.Backend.Endpoints;
using PizzaUtopia.Backend.Models;

var builder = WebApplication.CreateBuilder(args);

// Ustawienia URL i portu
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000); // Nas³uchiwanie na porcie 5000 na wszystkich interfejsach
    options.ListenAnyIP(5001, listenOptions =>
    {
        listenOptions.UseHttps(); // Jeœli chcesz obs³ugiwaæ HTTPS na porcie 5001
    });
});

// Dodaj us³ugi do kontenera
builder.Services.AddOpenApi();
builder.Services.AddDbContext<PizzaUtopiaDbContext>();

var app = builder.Build();

// Konfiguracja potoku ¿¹dañ HTTP
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/", () => "Backend serwisu PizzaUtopia");

app.MapPost("/auth/login", async (PizzaUtopiaDbContext dbContext, LoginDataDto loginData) =>
{
    var loginEndPoint = new LoginEndPoint(dbContext);

    var result = await loginEndPoint.Login(loginData);

    if (result == "Niepoprawne dane logowania")
    {
        return Results.BadRequest(result);
    }
    else
    {
        return Results.Ok(result);
    }
});

app.MapPost("/register", (PizzaUtopiaDbContext dbContext, User user) =>
{
    dbContext.Users.Add(user);
    dbContext.SaveChanges();
    return Results.Created($"/user/{user.Id}", user);
});

app.Run();
