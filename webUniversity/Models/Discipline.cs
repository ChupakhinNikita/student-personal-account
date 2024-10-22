using System.ComponentModel.DataAnnotations;

namespace webUniversity.Models
{
    public class Discipline
    {
        [Key]
        public int? disciplineID { get; set; }

        public string? code { get; set; }

        public string? name { get; set; }

        public string? addName { get; set; }

        public string? fullName { get; set; }

        public List<Statement> Statement { get; set; } = new();
    }
}
