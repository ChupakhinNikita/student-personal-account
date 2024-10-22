using System.ComponentModel.DataAnnotations;

namespace webUniversity.Models
{
    public class Statement
    {
        [Key]
        public int? statementID { get; set; }

        public string? code { get; set; }

        public DataType? date { get; set; }

        public DataType? timeStart { get; set; }

        public DataType? timeEnd { get; set; }

        public bool? isIndividual { get; set; }

        public int statementTypeID { get; set; } // внешний ключ
        public StatementType? StatementType { get; set; } // навигационное свойство

        public int controlFormID { get; set; } // внешний ключ
        public ControlForm? ControlForm { get; set; } // навигационное свойство

        public int disciplineID { get; set; } // внешний ключ
        public Discipline? Discipline { get; set; } // навигационное свойство

        public int controlPeriodID { get; set; } // внешний ключ
        public ControlPeriod? ControlPeriod { get; set; } // навигационное свойство

        public int markID { get; set; } // внешний ключ
        public Mark? Mark { get; set; } // навигационное свойство

        public int professorID { get; set; } // внешний ключ
        public Professor? Professor { get; set; } // навигационное свойство

        public int studentID { get; set; } // внешний ключ
        public Student? Student { get; set; } // навигационное свойство
    }
}
