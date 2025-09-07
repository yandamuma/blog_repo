using Microsoft.EntityFrameworkCore;
using Umr.BlogCraft.Model;
namespace Umr.BlogCraft.Data;

public class BlogCraftDbContext : DbContext
{
    public BlogCraftDbContext(DbContextOptions<BlogCraftDbContext> options) : base(options)
    {

    }

    public DbSet<Users> Users { get; set; } 
    public DbSet<Posts> Posts { get; set; }
    public DbSet<Comments> Comments { get; set; }
    public DbSet<Tags> Tags { get; set; }

}
