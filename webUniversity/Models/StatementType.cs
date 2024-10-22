using System.ComponentModel.DataAnnotations;

namespace webUniversity.Models
{
    public class StatementType
    {
        [Key]
        public int? statementTypeID { get; set; }

        public string? code { get; set; }

        public string? name { get; set; }
    }
}
