using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaUtopia.Backend.Models;

namespace PizzaUtopia.Backend.Context;

public class PizzaUtopiaDbContext(IConfiguration configuration) : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(configuration.GetValue<string>("MySQLConnectionString") ?? throw new ArgumentNullException("MySQLConnectionString", "Connection string nie może być pusty"), ServerVersion.AutoDetect(configuration.GetValue<string>("MySQLConnectionString") ?? throw new ArgumentNullException("MySQLConnectionString")));
    }
}
