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

        var teamMemberId1 = Guid.NewGuid(); var teamMemberId2 = Guid.NewGuid(); var teamMemberId3 = Guid.NewGuid();

        modelBuilder.Entity<TeamMember>().HasData(
            new TeamMember { TeamMemberId = teamMemberId1, Name = "Pleasure Ndhlovu", Email = "PleasureNdhlovu@gmail.com" },
            new TeamMember { TeamMemberId = teamMemberId2, Name = "Cassy Johnson", Email = "CassyJohnson@gmail.com" },
            new TeamMember { TeamMemberId = teamMemberId3, Name = "Bridget Craft", Email = "BridgetCraf@gmail.com" });

        modelBuilder.Entity<WorkItem>().HasData(
            new WorkItem { WorkItemId = Guid.NewGuid(), Title = "Task1", Description = "Description 1", TeamMemberId = teamMemberId1 },
            new WorkItem { WorkItemId = Guid.NewGuid(), Title = "Task2", Description = "Description 2", TeamMemberId = teamMemberId2 },
            new WorkItem { WorkItemId = Guid.NewGuid(), Title = "Task3", Description = "Description 3", TeamMemberId = teamMemberId3 });
    }
}
