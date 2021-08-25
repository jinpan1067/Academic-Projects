using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentServices.Data.Models;

namespace StudentServices.Data.Interfaces
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();

        Student GetStudentById(int id);
        List<Student> GetStudent(string lastName);

        List<Student> GetStudentByFirstNameAndCourses(string firstName, int numberOfCourses);

        bool AddNewStudent(Student student);
        bool Remove(int id);
        List<Student> UpdateStudent(int id, Student student);
    }
}
