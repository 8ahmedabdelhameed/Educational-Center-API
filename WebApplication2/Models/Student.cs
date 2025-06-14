namespace WebApplication2.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string StudentEmail { get; set; } = string.Empty;
        public Class Class { get; set; } = new Class();
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public List<Grad> ? grads { get; set; } = new List<Grad>();

    }
}
