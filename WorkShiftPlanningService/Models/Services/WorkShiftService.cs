using Microsoft.EntityFrameworkCore;

namespace WorkShiftPlanningService.Models.Services
{
    public class WorkShiftService : IWorkShiftService
    {
        private MainDbContext _dbContext;

        public WorkShiftService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<WorkShift>> GetWorkShiftsAsync(DateTime dateFirst, DateTime dateSecond, int restaurantId = 0)
        {
            var query = _dbContext.WorkShifts.Where(i=>i.Date.Date >= dateFirst.Date && i.Date <= dateSecond.Date);

            if (restaurantId != 0) query.Where(i => i.RestaurantId == restaurantId);

            return await query
                .Include(i=>i.Restaurant)
                .Include(i=>i.Staff)
                .ToListAsync();
        }

        public async Task<WorkShift> GetWorkShiftAsync(int id)
        {
            return await _dbContext.WorkShifts
                .Include(i => i.Restaurant)
                .Include(i => i.Staff)
                .FirstOrDefaultAsync(i => i.Id == id) ?? new WorkShift();
        }

        public async Task AddWorkShiftAsync(WorkShift workShift)
        {
            _dbContext.WorkShifts.Add(workShift);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateWorkShiftAsync(WorkShift workShift)
        {
            _dbContext.Entry(workShift).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteWorkShiftAsync(int id)
        {
            await _dbContext.WorkShifts.Where(i => i.Id == id).ExecuteDeleteAsync();
        }
    }

    public static class WorkShiftServiceProviderExtensions
    {
        public static void AddWorkShiftService(this IServiceCollection services)
        {
            services.AddTransient<IWorkShiftService, WorkShiftService>();
        }
    }
}
