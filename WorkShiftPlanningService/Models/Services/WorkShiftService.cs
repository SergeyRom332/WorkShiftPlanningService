﻿using Microsoft.EntityFrameworkCore;

namespace WorkShiftPlanningService.Models.Services
{
    public class WorkShiftService : IWorkShiftService
    {
        private MainDbContext _dbContext;

        public WorkShiftService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<WorkShift>> GetWorkShiftsAsync(int restaurantId, DateTime dateFirst, DateTime dateSecond)
        {
            return await _dbContext.WorkShifts
                .Where(i => i.RestaurantId == restaurantId && i.Date >= dateFirst && i.Date <= dateSecond)
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
