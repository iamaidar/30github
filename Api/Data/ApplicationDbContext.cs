using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) 
    {
           
    }

    public DbSet<Stock> Stocks {get; set;}
    public DbSet<Comment> Comments {get; set;}
}
