namespace WebApplication2.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherEmail { get; set; }
        public string ? TeacherPhone { get; set; } 
        public Class Class { get; set; }
    }
}
