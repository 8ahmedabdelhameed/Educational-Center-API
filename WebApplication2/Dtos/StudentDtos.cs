using System.ComponentModel.DataAnnotations;
using WebApplication2.Models;

namespace WebApplication2.Dtos
{
    public class StudentGet
    {
       public List<SubjectGet> Subjects { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }

    }
    public class StudentGetAll
    {
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public List<GradGet> Grads { get; set; }
        public ClassGetWithTeacher Class { get; set; }
    }
   
    public class StudentPost
    {
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string StudentEmail { get; set; }
        public string ClassName { get; set; }
        public List<GradDtos> Grads { get; set; }

    }
    public class StudentPostSub
    {
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string StudentEmail { get; set; }
        public ClassGetWithTeacher Class { get; set; }
        public List<GradDtos> Grads { get; set; }

    }
    public class StudentPostGrads
    {
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string StudentEmail { get; set; }
        public List<GradDtos> Grads { get; set; }

    }
    public class StudentPostssss
    {
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string StudentEmail { get; set; }
        public ClassGetWithTeacher Class { get; set; }

    }
    public class StudentPostss
    {
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string StudentEmail { get; set; }
        public ClassGetWithTeacher Class { get; set; }
        public List<GradDtos> Grads { get; set; }

    }
    public class StudentPostsss
    {
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string StudentEmail { get; set; }
        public string ClassName { get; set; }
        public List<GradDtos> Grads { get; set; }

    }
    public class updateStudent
    {
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string StudentEmail { get; set; }
        public string ClassName { get; set; }
        public List<GradDtoss> Grads { get; set; }

    }
}
