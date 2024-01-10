namespace StudentApplication.DAL.Entities
{
    public class Student
    {
        public string Name {  get; set; }
        public int Id { get; set; }
        public int Age {  get; set; }
        public int Marks { get; set; }

        public Student(string name, int id, int age, int marks)
        {
            Name = name; 
            Id = id;
            Age = age;
            Marks = marks;
        }

    }
}
