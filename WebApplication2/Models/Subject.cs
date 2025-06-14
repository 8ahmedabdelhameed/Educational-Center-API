namespace WebApplication2.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string SubjectDuration { get; set; }
        public List<Student> students  { get; set; }
    }
}
