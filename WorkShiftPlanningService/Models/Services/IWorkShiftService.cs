namespace WorkShiftPlanningService.Models.Services
{
    public interface IWorkShiftService
    {
        public Task<List<WorkShift>> GetWorkShiftsAsync(int restaurantId, DateTime dateFirst, DateTime dateSecond);
        public Task<WorkShift> GetWorkShiftAsync(int id);
        public Task AddWorkShiftAsync(WorkShift workShift);
        public Task UpdateWorkShiftAsync(WorkShift workShift);
        public Task DeleteWorkShiftAsync(int id);
    }
}
