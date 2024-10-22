using System.ComponentModel.DataAnnotations;

namespace webUniversity.Models
{
    public class Speciality
    {
        [Key]
        public int? specialityID { get; set; }

        public string? code { get; set; }

        public string? name { get; set; }

        public string? addName { get; set; }

        public string? specialityCode { get; set; }

        public string? largeGroup { get; set; }

        public string? branchScience { get; set; }

        public List<Specialization> Specialization { get; set; } = new();
    }
}
