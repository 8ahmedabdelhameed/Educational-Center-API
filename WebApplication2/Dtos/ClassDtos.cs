using Microsoft.AspNetCore.Antiforgery;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Dtos
{
    public class ClassPost
    {
        [Required]
        public string ClassName { get; set; }
        [Required]
        public int TeacherId { get; set; }
        public List<int> Students { get; set; }
   }
    public class ClassGetWithTeacher
    {
        public string ClassName { get; set; }
        public Teacherpost Teacherz { get; set; }
    }

    public class ClassGetAll
    {
        public string ClassName { get; set; }
        public List<StudentGet> Students { get; set; }
    }
    public class ClassGetTeacher
    {
        public string ClassName { get; set; }
    }
}
