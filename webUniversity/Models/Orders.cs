using System.ComponentModel.DataAnnotations;

namespace webUniversity.Models
{
    public class Orders
    {
        [Key]
        public int? ordersID { get; set; }

        public string? code { get; set; }

        public bool? isImplemented { get; set; }

        public string? number { get; set; }

        public string? title { get; set; }

        public DataType? data { get; set; }

        public DataType? dataStart { get; set; }

        public DataType? dataEnd { get; set; }

        public int studentID { get; set; } // внешний ключ
        public Student? Student { get; set; } // навигационное свойство

        public int orderTypeID { get; set; } // внешний ключ
        public OrderType? OrderType { get; set; } // навигационное свойство
    }
}
