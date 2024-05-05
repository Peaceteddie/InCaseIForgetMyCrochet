using InCaseIForgetMyCrochet.Models;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

namespace InCaseIForgetMyCrochet;
public class PatternDbContext : DbContext
{
    public PatternDbContext() { }
    public PatternDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Pattern> Patterns { get; set; }


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