using Microsoft.EntityFrameworkCore;

namespace WorkShiftPlanningService.Models
{
    public class MainDbContext : DbContext
    {
        public DbSet<WorkShift> WorkShifts { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<WorkShift> Departments { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }
    }
}
