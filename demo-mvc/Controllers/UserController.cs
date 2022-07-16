using demo_mvc.Repositories;
using demo_mvc.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace demo_mvc.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(userRepository.Index());
        }

        [HttpGet]
        public IActionResult GetDetail([FromQuery] string id)
        {
            return Ok(userRepository.Get(id));
        }

        [HttpPost]
        public IActionResult InsertOrUpdate([FromBody] InsertOrUpdateParam param)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(userRepository.InsertOrUpdate(param));
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] string id)
        {
            return Ok(userRepository.Delete(id));
        }
    }
}
