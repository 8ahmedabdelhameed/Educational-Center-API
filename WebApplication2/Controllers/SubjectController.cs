using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Dtos;
using WebApplication2.Interface;
using WebApplication2.Repos;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepo _SubjectRepo;
        public SubjectController(ISubjectRepo SubjectRepo)
        {
            _SubjectRepo = SubjectRepo;
        }

        [HttpPost]
        public IActionResult PostSubject(SubjectPost SubjectPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _SubjectRepo.postSub(SubjectPost);
            return Created();
        }
        [HttpGet]
        public IActionResult GetSubjectWithId(int id)
        {
            var sub = _SubjectRepo.getSubbyid(id);
            if (sub != null)
            {
                return Accepted(sub);

            }
            return BadRequest();
        }
        [HttpGet("GetAll")]
        public IActionResult GetAllSubjects()
        {
            var sub = _SubjectRepo.getAllSub();
            if (sub != null)
            {
                return Accepted(sub);

            }
            return BadRequest();
        }
    }
}
