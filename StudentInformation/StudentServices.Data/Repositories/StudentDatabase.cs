using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentServices.Data.Interfaces;
using StudentServices.Data.Models;

namespace StudentServices.Data.Repositories
{
    public class StudentDatabase : IStudentRepository
    {

        private StudentContext db = new StudentContext();
        public bool AddNewStudent(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return true;
        }

        public List<Student> GetAllStudents()
        {
            return db.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return db.Students.FirstOrDefault(x=>x.Id==id);
        }

        public List<Student> GetStudent(string lastName)
        {
            
            var getstudents = db.Students.Where(o => o.LastName.ToLower().Contains(lastName.Trim().ToLower()));
               
            return getstudents.ToList();
            

            
        }


        public List<Student> GetStudentByFirstNameAndCourses(string firstName, int numberOfCourses)
        {
            var getstudents = db.Students.Where(o => o.FirstName.ToLower().Contains(firstName.Trim().ToLower()) && o.NumberOfCourses == numberOfCourses);
            
            
            return getstudents.ToList();
        }

        public bool Remove(int id)
        {
            var student = GetStudentById(id);
            if (student == null)
            {
                return false;
            }

            db.Students.Remove(student);
            db.SaveChanges();
            return true;
        }

        public List<Student> UpdateStudent(int id, Student student)
        {
            if (this.Remove(id))
            {
                this.AddNewStudent(student);
                db.SaveChanges();
                return db.Students.ToList();
            }

            return db.Students.ToList();
        }
    }
}
