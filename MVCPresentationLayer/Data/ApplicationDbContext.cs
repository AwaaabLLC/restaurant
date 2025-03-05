using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DataObjectLayer;

namespace MVCPresentationLayer.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

public DbSet<DataObjectLayer.Employee> Employee { get; set; } = default!;

public DbSet<DataObjectLayer.EmployeeUser> EmployeeUser { get; set; } = default!;

//public DbSet<DataObjectLayer.Product> Product { get; set; } = default!;
}
