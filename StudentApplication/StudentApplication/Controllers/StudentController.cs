using Microsoft.AspNetCore.Mvc;
using StudentApplication.Services;
using StudentApplication.DAL.Entities; 

namespace StudentApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        StudentService studentService  = new();

        [HttpGet("get-students")]
        public ActionResult<List<Student>> Get() => studentService.students;

        [HttpPost("add-student")]
        public ActionResult<List<Student>> Post([FromBody] Student student)
        {
            studentService.AddStudent(student);
            return studentService.students;
        }

        [HttpDelete("delete-student")]
        public ActionResult<List<Student>> Delete(int id)
        { 
            studentService.DeleteStudent(id); 
            return studentService.students; 
        }

        [HttpPut("update-student-details")]
        public ActionResult<List<Student>> Put([FromBody] Student student)
        {
            studentService.UpdateStudentDetails(student);
            return studentService.students;
        }
    }
}
