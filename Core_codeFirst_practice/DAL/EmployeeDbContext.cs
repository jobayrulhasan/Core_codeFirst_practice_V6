using Core_codeFirst_practice.Models.DBEntites;
using Microsoft.EntityFrameworkCore;

namespace Core_codeFirst_practice.DAL
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee>Employees { get; set; }
    }
}
