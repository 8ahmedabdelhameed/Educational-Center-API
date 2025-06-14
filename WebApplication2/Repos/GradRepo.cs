using Microsoft.AspNetCore.Mvc.Routing;
using WebApplication2.Dtos;
using WebApplication2.Interface;
using WebApplication2.Models;

namespace WebApplication2.Repos
{
    public class GradRepo : IGradRepo
    {
        private readonly AppDbContext _context;

        public GradRepo(AppDbContext context)
        {
            _context = context;
        }

        public void postgrad(GradDtos grad, int sudentid)
        {
            var student = _context.students.Find(sudentid);
            Grad grad1 = new Grad
            {
                StudentId = sudentid,
                GradeName = grad.GradeName,
                GradeYear = grad.GradeYear,
            };
            _context.Grad.Add(grad1);
            _context.SaveChanges();
        }
    }
}
