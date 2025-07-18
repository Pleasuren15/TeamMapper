using Microsoft.EntityFrameworkCore;

namespace team_mapper_infrastructure.Infrastructure;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<team_mapper_domain.Models.Task> Tasks { get; set; }
}
