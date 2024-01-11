using StudentApplication.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq; 

namespace StudentApplication.Services
{
    public class StudentService : IStudentService
    {
        public List<Student> students = new()
        {
            new Student
            {
                Id = 1,
                Name = "ayush", 
                Age = 23,
                Marks = 69
            },
            new Student
            {
                Id = 2,
                Name = "sachin", 
                Age = 24,
                Marks = 90
            }
        };

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void DeleteStudent(int? id)
        {

            if (id != null)
            {
                students.RemoveAll(stu => stu.Id == id);
            }
        }

        public void UpdateStudentDetails(Student student)
        {
            for(int i = 0; i< students.Count; i++)
            {
                if (students[i].Id == student.Id)
                {
                    students[i].Name = student.Name;
                    students[i].Age = student.Age;
                    students[i].Marks = student.Marks;
                    students[i].Id = student.Id;
                    break;
                }
            }
        }
    }
}
