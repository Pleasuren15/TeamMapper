using Microsoft.EntityFrameworkCore;

namespace team_mapper_infrastructure.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<team_mapper_domain.Models.Task> Tasks { get; set; }
}
