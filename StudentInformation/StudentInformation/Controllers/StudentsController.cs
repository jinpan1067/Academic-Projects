using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;
using Microsoft.Ajax.Utilities;
using StudentInformation.Models;
using StudentServices.Data.Interfaces;
using StudentServices.Data.Models;

namespace StudentInformation.Controllers
{
    [EnableCorsAttribute(origins:"*",headers:"*",methods:"*")]
    public class StudentsController : ApiController
    {
        private IStudentRepository students;

        public StudentsController(IStudentRepository _student)
        {
            this.students = _student;
        }


        [HttpGet]
        //Get/api/students
        public IEnumerable<Student> Get()
        {
            return students.GetAllStudents();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            
            var student = students.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpGet]

        
        public IHttpActionResult Get(string lastName)
        {


            var student = students.GetStudent(lastName);
            if (student == null)
            {
                return NotFound();
            }


            return Ok(student);

        }

    
    [HttpGet]
    public IHttpActionResult GetByNameAndCourse(string firstname, int numberOfCourses)
    {
    var student = students.GetStudentByFirstNameAndCourses(firstname, numberOfCourses);
    if (student == null)
            {
                return NotFound();
            }

    return Ok(student);
    }


    [HttpPost]
        public IHttpActionResult PostStudent(Student student)
        {
            bool result = students.AddNewStudent(student);
            if (result)
            {
                return Ok(student);

            }

            return BadRequest();
        }

        [HttpDelete]

        public IHttpActionResult DeleteStudent(int id)
        {
            if (students.Remove(id))
            {
                return Ok(students.GetAllStudents());
            }

            return NotFound();
        }

        [HttpPut]
        public IHttpActionResult UpdateStudent(int id, Student student)
        {
            var ustudent = students.UpdateStudent(id, student);
            if (ustudent != null)
            {
                return Ok(ustudent);
            }

            return NotFound();
        }

    }
}
