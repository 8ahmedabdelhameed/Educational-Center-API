using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Dtos;
using WebApplication2.Interface;
using WebApplication2.Repos;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _StudentRepo;
        public StudentController(IStudentRepo StudentRepo)
        {
            _StudentRepo = StudentRepo;
        }

        [HttpPost]
      public  IActionResult PostStudent(StudentPostss StudentPostss)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _StudentRepo.postdtudent(StudentPostss);
            return Created();
        }
        [HttpPut]
        public IActionResult PutStudent(int id,updateStudent updateStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _StudentRepo.putstudent( id,updateStudent);
            return Created();
        }
        [HttpGet]
        public IActionResult GetStudentWithId(int id)
        {
            var sub = _StudentRepo.StudentGetById(id);
            if (sub != null)
            {
                return Accepted(sub);

            }
            return BadRequest();
        }
        [HttpGet("all")]
        public IActionResult GetAllStudent()
        {
            var sub = _StudentRepo.StudentGetAll();
            if (sub != null)
            {
                return Accepted(sub);

            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
             _StudentRepo.deletedtudent(id);
            return Accepted();
        }
    }
}
