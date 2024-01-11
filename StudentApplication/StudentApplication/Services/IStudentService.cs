using StudentApplication.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace StudentApplication.Services
{
    public interface IStudentService
    {

         void AddStudent(Student student);

         void DeleteStudent(int? id);

         void UpdateStudentDetails(Student student); 
        
    }
}
