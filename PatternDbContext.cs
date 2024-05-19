using InCaseIForgetMyCrochet.Models;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

namespace InCaseIForgetMyCrochet;
public class PatternDbContext : DbContext
{
    public DbSet<Pattern> Patterns { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pattern>()
            .HasMany(p => p.Rows)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Row>()
            .HasMany(r => r.Instructions)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IEnumerable<KeyValuePair<string, string>>? dotEnv = Env.TraversePath().Load();
        if (dotEnv != null)
            optionsBuilder.UseNpgsql(@$"
            Host={Env.GetString("POSTGRES_HOST")};
            Port={Env.GetString("POSTGRES_PORT")};
            Database={Env.GetString("POSTGRES_DB")};
            Username={Env.GetString("POSTGRES_USER")};
            Password={Env.GetString("POSTGRES_PASSWORD")};
            ");
    }
}