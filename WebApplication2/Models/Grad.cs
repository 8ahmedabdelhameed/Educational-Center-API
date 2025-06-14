using System.Runtime.InteropServices;

namespace WebApplication2.Models
{
    public class Grad
    {
        public int GradId { get; set; }
        public int GradeYear { get; set; }
        public string GradeName { get; set; }
        public int ? StudentId  { get; set; } = null;
        public Student? Student  { get; set; }
    }
}
