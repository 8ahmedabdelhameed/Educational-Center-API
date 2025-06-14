using Microsoft.EntityFrameworkCore;
using WebApplication2.Dtos;
using WebApplication2.Interface;
using WebApplication2.Models;

namespace WebApplication2.Repos
{
    public class TeacherRepo : ITeacherRepo
    {
        private readonly AppDbContext _context;

        public TeacherRepo(AppDbContext context)
        {
            _context = context;
        }

        public void postteacher(Teacherpost teacherpost)
        {
            Teacher t1 = new Teacher
            {
                TeacherEmail = teacherpost.TeacherEmail,
                TeacherName = teacherpost.TeacherName,
                TeacherPhone = teacherpost.TeacherPhone,
            };
            _context.Add(t1);
            _context.SaveChanges();
        }

        public List<TeacherGetAll> TeacherGetAll()
        {
            return _context.teachers.Include(x=>x.Class).ThenInclude(x=>x.students).ThenInclude(x=>x.grads).Select(teacher => new TeacherGetAll
            {
                TeacherEmail = teacher.TeacherEmail,
                TeacherName = teacher.TeacherName,  
                TeacherPhone = teacher.TeacherPhone,
                Class = teacher.Class == null ? new ClassGetAll() : new ClassGetAll
                {
                    ClassName = teacher.Class.ClassName,
                    Students = teacher.Class.students == null ? new List<StudentGet>() : teacher.Class.students.Select(x=> new StudentGet
                    {
                        StudentEmail = x.StudentEmail,  
                        StudentName = x.StudentName,
                        Subjects = x.Subjects == null ? new List<SubjectGet>() :  x.Subjects.Select(x=> new SubjectGet
                        {
                            SubjectDuration = x.SubjectDuration,
                            SubjectName = x.SubjectName,
                            SubjectId = x.SubjectId,
                        }).ToList()
                        
                    }).ToList()
                }
            }).ToList();
        }

       public TeacherGetById? TeacherGetById(int id)
{
    var result = _context.teachers
        .Include(x => x.Class)
            .ThenInclude(c => c.students)
                .ThenInclude(s => s.grads)
        .FirstOrDefault(x => x.TeacherId == id);

    if (result == null)
    {
        return null;
    }

    return new TeacherGetById
    {
        TeacherEmail = result.TeacherEmail,
        TeacherName = result.TeacherName,
        TeacherPhone = result.TeacherPhone,
        Class = result.Class == null ? null : new ClassGetTeacher
        {
            ClassName = result.Class.ClassName
        }
    };
}

    }
}
