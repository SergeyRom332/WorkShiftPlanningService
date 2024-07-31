using System.ComponentModel.DataAnnotations.Schema;

namespace WorkShiftPlanningService.Models
{
    [Table("staff")]
    public class Staff
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("phone")]
        public string Phone { get; set; }
        [Column("department_id")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
    }
}
