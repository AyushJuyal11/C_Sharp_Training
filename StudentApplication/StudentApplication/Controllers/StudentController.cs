using Microsoft.AspNetCore.Mvc;
using StudentApplication.DAL.Entities;
using System.Linq;

namespace StudentApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {

        List<Student> students = new()
        {
            new Student("ayush", 1, 23, 69),
            new Student("someone", 2, 24, 99)
        };

        [HttpGet("get-students")]
        public ActionResult<List<Student>> GetStudents()
        {
            return students;
        }

        [HttpPost("add-student")]
        public ActionResult<List<Student>> AddStudent([FromBody]Student student)  
        {
            students.Add(new Student(student.Name, student.Id, student.Age, student.Marks));
            return students;
        }

        [HttpDelete("delete-student")]
        public ActionResult<List<Student>> DeleteStudent(int id)
        {

            students.RemoveAll(stu => stu.Id == id);
            return students; 
        }

        [HttpPut("update-student-details")]
        public ActionResult<List<Student>> UpdateStudentDetails([FromBody]Student student) 
        {
            Student stu = students.FirstOrDefault(stu => stu.Id == student.Id);

            if(stu != null)
            {
                stu.Name = student.Name;
                stu.Age = student.Age;
                stu.Marks = student.Marks;
                stu.Id = student.Id;
            }
            return students; 
        }
    }
}
