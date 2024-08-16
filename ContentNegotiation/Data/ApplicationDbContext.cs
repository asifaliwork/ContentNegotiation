using Microsoft.EntityFrameworkCore;
using ContentNegotiation.Models.Items;

namespace ContentNegotiation.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Item> Items { get; set; }

}

