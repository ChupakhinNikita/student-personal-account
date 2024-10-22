using System.ComponentModel.DataAnnotations;

namespace webUniversity.Models
{
    public class Student
    {

        [Key]
        public int? studentID { get; set; } = null!;

        public string? code { get; set; }

        public string? gradebook { get; set; }

        public string? lastName { get; set; }

        public string? firstName { get; set; }

        public string? patronomic { get; set; }

        public int groupID { get; set; } // внешний ключ
        public Group? Group { get; set; } // навигационное свойство

        public int tuitionTypeID { get; set; } // внешний ключ
        public TuitionType? TuitionType { get; set; } // навигационное свойство

        public int tuitionFormID { get; set; } // внешний ключ
        public TuitionForm? TuitionForm { get; set; } // навигационное свойство

        public int trainingLevelID { get; set; } // внешний ключ
        public TrainingLevel? TrainingLevel { get; set; } // навигационное свойство

        public int studentStatusID { get; set; } // внешний ключ
        public StudentStatus? StudentStatus { get; set; } // навигационное свойство

        public int specialityID { get; set; } // внешний ключ
        public Speciality? Speciality { get; set; } // навигационное свойство

        public int specializationID { get; set; } // внешний ключ
        public Specialization? Specialization { get; set; } // навигационное свойство

        public int courseID { get; set; } // внешний ключ
        public Course? Course { get; set; } // навигационное свойство

        public int userID { get; set; } // внешний ключ
        public User? User { get; set; } // навигационное свойство

        public int facultyID { get; set; } // внешний ключ
        public Faculty? Faculty { get; set; } // навигационное свойство

        public List<Statement> Statement { get; set; } = new();

        public List<Orders> Orders { get; set; } = new();
    }
}
