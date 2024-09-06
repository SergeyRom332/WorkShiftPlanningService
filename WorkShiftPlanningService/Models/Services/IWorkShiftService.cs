namespace WorkShiftPlanningService.Models.Services
{
    public interface IWorkShiftService
    {
        public Task<List<WorkShift>> GetWorkShiftsAsync(DateTime dateFirst, DateTime dateSecond, int restaurantId = 0);
        public Task<WorkShift> GetWorkShiftAsync(int id);
        public Task AddWorkShiftAsync(WorkShift workShift);
        public Task UpdateWorkShiftAsync(WorkShift workShift);
        public Task DeleteWorkShiftAsync(int id);
    }
}
