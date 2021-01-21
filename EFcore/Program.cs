using System;
using Microsoft.EntityFrameworkCore;

namespace EFcore
{

    //---------------------------Entity Class-----------------------------------
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
            
    }
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }

    }


    //--------------------------context class------------------------------------

    public class  DB: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=firstDb;Trusted_Connection=True;");
        }
    }


    class program
    {
        static void Main(string[] args)
        {
            using(var context =new DB())
            {
                var std = new Student()
                {
                    Name = "Afaq"
                };
                var std1 = new Student()
                {
                    Name = "Wamiq"
                };

                var crs = new Course()
                {
                    Name="Computer Science"
                };
                context.Courses.Add(crs);
                context.SaveChanges();
            }
        }
    }
}
