using EmployeeTracker.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTracker.Infrastructure
{
    public class EmployeeTrackerDbContext : IdentityDbContext<User, Role, int>
    {
        public EmployeeTrackerDbContext(DbContextOptions<EmployeeTrackerDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}