using System.ComponentModel.DataAnnotations;

namespace webUniversity.Models
{
    public class Specialization
    {
        [Key]
        public int? specializationID { get; set; }

        public string? code { get; set; }

        public string? name { get; set; }

        public string? addName { get; set; }

        public string? specializationCode { get; set; }

        public int specialityID { get; set; } // внешний ключ

        public Speciality? Speciality { get; set; } // навигационное свойство
    }
}
