using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace WebApplication2.Dtos
{
    public class TeacherGetAll
    {
        public string TeacherName { get; set; }
        public string TeacherEmail { get; set; }
        public string TeacherPhone { get; set; }
        public ClassGetAll Class { get; set; }
    }
    public class TeacherGetById
    {
        public string TeacherName { get; set; }
        public string TeacherEmail { get; set; }
        public string TeacherPhone { get; set; }
        public ClassGetTeacher Class { get; set; }
    }
    public class Teacherpost
    {
        [Required]
        public string TeacherName { get; set; }
        [Required]
        public string TeacherEmail { get; set; }
        public string TeacherPhone { get; set; }
    }
}
