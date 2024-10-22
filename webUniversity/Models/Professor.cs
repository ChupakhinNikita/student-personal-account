using System.ComponentModel.DataAnnotations;

namespace webUniversity.Models
{
    public class Professor
    {
        [Key]
        public int? professorID { get; set; }

        public string? code { get; set; }

        public string? name { get; set; }

        public List<Statement> Statement { get; set; } = new();
    }
}
