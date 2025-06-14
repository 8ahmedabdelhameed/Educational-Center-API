using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplication2.Dtos;
using WebApplication2.Interface;
using WebApplication2.Models;

namespace WebApplication2.Repos
{
    public class StudentRepo : IStudentRepo
    {
        private readonly AppDbContext _context;

        public StudentRepo(AppDbContext context)
        {
            _context = context;
        }

        public void deletedtudent(int id)
        {
            var student = _context.students.Find(id);
            if (student != null)
            {
                foreach (var grad in student.grads)
                {
                    if (grad != null)
                    {
                        _context.Grad.Remove(grad);
                        _context.SaveChanges();
                    }
                }
                _context.Remove(student);
            }
        }

        public void postdtudent(StudentPostss x)
        {
            Student student = new Student
            {
                StudentEmail = x.StudentEmail,
                StudentName = x.StudentName,
                Class = new Class
                {
                    ClassName = x.Class.ClassName,
                    Teacher = new Teacher
                    {
                        TeacherEmail = x.Class.Teacherz.TeacherEmail,
                        TeacherName = x.Class.Teacherz.TeacherName,
                        TeacherPhone = x.Class.Teacherz.TeacherPhone,
                    }
                },
            };
            _context.Add(student);
            _context.SaveChanges();
        }

        public void putstudent(int id, updateStudent studentPost)
        {
            var student = _context.students.Find(id);
            if (student != null)
            {
                student.StudentEmail = studentPost.StudentEmail;
                student.StudentName = studentPost.StudentName;

                List<Grad> grads = new List<Grad>();
                foreach (var grad in studentPost.Grads)
                {
                    if (grad != null)
                    {
                        grads.Add(new Grad
                        {
                            GradeName = grad.GradeName,
                            GradeYear = grad.GradeYear,
                        });
                    }
                }
                student.grads = grads;
                if (student.Class != null)
                {
                    student.Class.ClassName = studentPost.ClassName;
                }
                else
                {
                    student.Class = new Class
                    {
                        ClassName = studentPost.ClassName
                    };
                }
                _context.Update(student);
                _context.SaveChanges();
            }
        }

        public List<StudentPostss> StudentGetAll()
        {
            return _context.students.Include(x=>x.grads).Include(x => x.Class).ThenInclude(x=>x.Teacher).Select(x => new StudentPostss
            {
                StudentEmail = x.StudentEmail,
                StudentName = x.StudentName,
                Class = new ClassGetWithTeacher
                {
                    ClassName = x.Class.ClassName,
                    Teacherz = new Teacherpost
                    {
                        TeacherEmail = x.Class.Teacher.TeacherEmail,
                        TeacherName = x.Class.Teacher.TeacherName,
                        TeacherPhone =x.Class.Teacher.TeacherPhone,
                    }
                },
                Grads = x.grads.Select(x=> new GradDtos
                {
                    GradeName =x.GradeName,
                    GradeYear =x.GradeYear,
                }).ToList()
            }).ToList();
        }
        public StudentPostsss StudentGetById(int id)
        {
            var x = _context.students.Include(x => x.grads).Include(x => x.Class).ThenInclude(x => x.Teacher).FirstOrDefault(x=> x.StudentId == id);
            if(x == null)
            {
                return null;
            }
            return new StudentPostsss
            {
                StudentEmail = x.StudentEmail,
                StudentName = x.StudentName,
                ClassName = x.Class.ClassName,
                Grads = x.grads.Select(x => new GradDtos
                {
                    GradeName = x.GradeName,
                    GradeYear = x.GradeYear,
                }).ToList()
            };

        }
        
    }
}

