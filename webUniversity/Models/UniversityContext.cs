using Microsoft.EntityFrameworkCore;
using webUniversity.Models;

namespace webUniversity.Models
{
    public partial class UniversityContext : DbContext
    {
        public UniversityContext() { }

        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options) { }

        public  DbSet<User> Users { get; set; } = null!;

        public DbSet<Student> Students { get; set; } = null!;

        public DbSet<Statement> Statements { get; set; } = null!;

        public DbSet<Orders> Orders { get; set; } = null!;

        public DbSet<Group> Groups { get; set; } = null!;

        public DbSet<TuitionForm> TuitionForms { get; set; } = null!;

        public DbSet<TuitionType> TuitionTypes { get; set; } = null!;

        public DbSet<TrainingLevel> TrainingLevels { get; set; } = null!;

        public DbSet<StudentStatus> StudentStatuss { get; set; } = null!;

        public DbSet<Speciality> Specialitys { get; set; } = null!;

        public DbSet<Specialization> Specializations { get; set; } = null!;

        public DbSet<Course> Courses { get; set; } = null!;

        public DbSet<Faculty> Facultys { get; set; } = null!;

        public DbSet<StatementType> StatementTypes { get; set; } = null!;

        public DbSet<ControlForm> ControlForms { get; set; } = null!;

        public DbSet<Discipline> Disciplines { get; set; } = null!;

        public DbSet<ControlPeriod> ControlPeriods { get; set; } = null!;

        public DbSet<Mark> Marks { get; set; } = null!;

        public DbSet<Professor> Professors { get; set; } = null!;


        // public  DbSet<Teacher> Teachers { get; set; } = null!;

        // public DbSet<RecordBook> RecordBooks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=University2;userName=postgres;Password=123456");
        }


        // public  DbSet<Teacher> Teachers { get; set; } = null!;

        // public DbSet<RecordBook> RecordBooks { get; set; } = null!;

        public DbSet<webUniversity.Models.OrderType>? OrderType { get; set; }

    }
}
