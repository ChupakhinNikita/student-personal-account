using System.ComponentModel.DataAnnotations;

namespace webUniversity.Models
{
    public class OrderType
    {
        [Key]
        public int? orderTypeID { get; set; }

        public string? code { get; set; }

        public string? name { get; set; }

        public List<Orders> Orders { get; set; } = new();
    }
}
