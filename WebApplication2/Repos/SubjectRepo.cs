using Microsoft.EntityFrameworkCore;
using WebApplication2.Dtos;
using WebApplication2.Interface;
using WebApplication2.Models;

namespace WebApplication2.Repos
{
    public class SubjectRepo : ISubjectRepo
    {
        private readonly AppDbContext _context;

        public SubjectRepo(AppDbContext context)
        {
            _context = context;
        }

        public List<SubjectPost> getAllSub()
        {
            return _context.subjects.Include(x => x.students).ThenInclude(y=>y.grads).Select(x => new SubjectPost
            {
                SubjectName = x.SubjectName,
                SubjectDuration = x.SubjectDuration,
                Students = x.students.Select(x => new StudentPostSub
                {
                    StudentEmail = x.StudentEmail,
                    StudentName = x.StudentName,
                    Grads = x.grads == null ? null: x.grads.Select(x => new GradDtos
                    {
                        GradeName = x.GradeName,
                        GradeYear = x.GradeYear,
                    }).ToList()
                }).ToList()
            }).ToList();
        }

        public SubjectGetById getSubbyid(int subjectid)
        {
            var subject = _context.subjects
                .Include(s => s.students)
                    .ThenInclude(st => st.grads)
                .FirstOrDefault(s => s.SubjectId == subjectid);

            if (subject == null)
                return null;
            return new SubjectGetById
            {
                SubjectName = subject.SubjectName,
                SubjectDuration = subject.SubjectDuration,
                Students = subject.students.Select(student => new StudentPostGrads
                {
                    StudentName = student.StudentName,
                    StudentEmail = student.StudentEmail,
                    Grads = student.grads.Select(grad => new GradDtos
                    {
                        GradeName = grad.GradeName,
                        GradeYear = grad.GradeYear
                    }).ToList()
                }).ToList()
            };
        }


        public void postSub(SubjectPost subjectPost)
        {
            Subject subject = new Subject
            {
                SubjectName = subjectPost.SubjectName,
                SubjectDuration = subjectPost.SubjectDuration,
                students = subjectPost.Students.Select(x => new Student
                {

                    grads = x.Grads.Select(x => new Grad
                    {
                        GradeName = x.GradeName,
                        GradeYear = x.GradeYear
                    }).ToList()
                ,
                    Class = new Class
                    {
                        ClassName = x.Class.ClassName,
                        Teacher = new Teacher
                        {
                            TeacherEmail = x.Class.Teacherz.TeacherEmail,
                            TeacherPhone = x.Class.Teacherz.TeacherPhone,
                            TeacherName = x.Class.Teacherz.TeacherName,
                        }
                    }
                }).ToList(),

            };
            _context.Add(subject);
            _context.SaveChanges();
        }
    }
}
