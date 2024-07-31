using System.ComponentModel.DataAnnotations.Schema;

namespace WorkShiftPlanningService.Models
{
    [Table("department")]
    public class Department
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
    }
}
