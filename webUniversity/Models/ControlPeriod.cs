using System.ComponentModel.DataAnnotations;

namespace webUniversity.Models
{
    public class ControlPeriod
    {
        [Key]
        public int? controlPeriodID { get; set; }

        public string? code { get; set; }

        public string? name { get; set; }

        public string? index { get; set; }

        public List<Statement> Statement { get; set; } = new();
    }
}
