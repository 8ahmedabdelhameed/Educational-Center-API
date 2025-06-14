using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Dtos;
using WebApplication2.Interface;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassRepo _classRepo;
        public ClassController(IClassRepo classRepo)
        {
            _classRepo = classRepo;
        }
        [HttpPost]
        public IActionResult PostClass (ClassPost classPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _classRepo.postclass(classPost);
            return Created();
        }
    }
}
