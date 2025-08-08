using Microsoft.EntityFrameworkCore;
using team_mapper_domain.Models;

namespace team_mapper_infrastructure.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<WorkItem> WorkItems { get; set; }
    public DbSet<ExpiringWorkItem> ExpiringWorkItems { get; set; }
    public DbSet<TeamMember> TeamMembers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
