using Microsoft.EntityFrameworkCore;

namespace WorkShiftPlanningService.Models.Services
{
    public class StaffService : IStaffService
    {
        private MainDbContext _dbContext;

        public StaffService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Staff>> GetAllStaffAsync(int departmentId)
        {
            return await _dbContext.Staff
                .Where(i => i.DepartmentId == departmentId)
                .Include(i => i.DepartmentId)
                .ToListAsync();
        }

        public async Task<Staff> GetStaffAsync(int id)
        {
            return await _dbContext.Staff
                .Include(i => i.DepartmentId)
                .FirstOrDefaultAsync(i => i.Id == id) ?? new Staff();
        }

        public async Task AddStaffAsync(Staff staff)
        {
            _dbContext.Staff.Add(staff);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateStaffAsync(Staff staff)
        {
            _dbContext.Entry(staff).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteStaffAsync(int id)
        {
            await _dbContext.Staff.Where(i => i.Id == id).ExecuteDeleteAsync();
        }
    }

    public static class StaffServiceProviderExtensions
    {
        public static void AddStaffService(this IServiceCollection services)
        {
            services.AddTransient<IStaffService, StaffService>();
        }
    }
}

