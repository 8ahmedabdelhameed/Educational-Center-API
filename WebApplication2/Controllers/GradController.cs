using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Dtos;
using WebApplication2.Interface;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradController : ControllerBase
    {
        private readonly IGradRepo _gradRepo;
        public GradController(IGradRepo classRepo)
        {
            _gradRepo = classRepo;
        }

        [HttpPost]
        public IActionResult PostGrad(GradDtos grad,int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _gradRepo.postgrad(grad,id);
            return Created();
        }
    }
}
