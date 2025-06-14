using WebApplication2.Dtos;
using WebApplication2.Interface;
using WebApplication2.Models;

namespace WebApplication2.Repos
{
    public class ClassRepo : IClassRepo
    {
        private readonly AppDbContext _context;

        public ClassRepo(AppDbContext context)
        {
            _context = context;
        }

        public void postclass(ClassPost classPost)
        {
            Class @class = new Class()
            {
                ClassName = classPost.ClassName,
                TeacherId = classPost.TeacherId,    
            };
            @class.students.AddRange(classPost.Students.Select(obj => _context.students.Find(obj)).Where(student => student != null));
        }
    }
}
