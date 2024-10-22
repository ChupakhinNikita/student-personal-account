using System.ComponentModel.DataAnnotations;

namespace webUniversity.Models
{
    public class RecordBook
    {
        [Key]
        public int? IdRecordBook { get; set; } = null!;

        public string? Discipline { get; set; }

        public string? ControlPeriod { get; set; }

        public string? ControlType { get; set; }

        public string? Grade { get; set; }

        public DateTime? Date { get; set; }

        public DateTime? StartTime { get; set; }

        public string? Teacher { get; set; }

        public int? IdTeacher { get; set; }
    }
}
