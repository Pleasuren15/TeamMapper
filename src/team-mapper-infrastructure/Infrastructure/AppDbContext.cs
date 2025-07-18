using Microsoft.EntityFrameworkCore;

namespace team_mapper_infrastructure.Infrastructure;

public class AppDbContext(string connectionString) : DbContext
{
    private readonly string _connectionString = connectionString;

    public DbSet<team_mapper_domain.Models.Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString: _connectionString);
    }
}
