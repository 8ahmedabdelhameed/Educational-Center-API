using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Dtos;
using WebApplication2.Interface;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {

        private readonly ITeacherRepo _TeacherRepo;
        public TeacherController(ITeacherRepo TeacherRepo)
        {
            _TeacherRepo = TeacherRepo;
        }

      [HttpPost]
        public IActionResult PostTeacher (Teacherpost teacherpost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _TeacherRepo.postteacher(teacherpost);
            return Created();
        }
        [HttpGet]
        public IActionResult GetTeacherWithId(int id)
        {
            var Teacher = _TeacherRepo.TeacherGetById(id);
            if (Teacher != null)
            {
                return Accepted(Teacher);

            }
            return BadRequest();
        }
        [HttpGet("GetAll")]
        public IActionResult GetAllTeacher()
        {
            var Teacher = _TeacherRepo.TeacherGetAll();
            if (Teacher != null)
            {
                return Accepted(Teacher);
            }
            return BadRequest();
        }
    }
}
