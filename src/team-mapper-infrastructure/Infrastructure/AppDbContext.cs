using Microsoft.EntityFrameworkCore;

namespace team_mapper_infrastructure.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }
}
