using InCaseIForgetMyCrochet.Models;
using Microsoft.EntityFrameworkCore;
using dotenv.net;

namespace InCaseIForgetMyCrochet
{
    public class PatternDbContext : DbContext
    {
        public DbSet<Pattern> Patterns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DotEnv.Load();
            var dotEnv = DotEnv.Read();
            optionsBuilder.UseNpgsql($"Host={dotEnv["POSTGRES_HOST"]};Port={dotEnv["POSTGRES_PORT"]};Database={dotEnv["POSTGRES_DB"]};Username={dotEnv["POSTGRES_USER"]};Password={dotEnv["POSTGRES_PASSWORD"]}");
        }
    }
}