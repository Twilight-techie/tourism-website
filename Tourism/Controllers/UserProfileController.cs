namespace Tourism.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using Tourism.Model;

    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly UserProfileRepository _userRepository;

        public UserProfileController(UserProfileRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserProfile(Guid userId)
        {
            var userProfile = await _userRepository.GetUserProfile(userId);

            if (userProfile == null)
            {
                return NotFound();
            }

            return Ok(userProfile);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserProfile([FromBody] UserProfile model)
        {
            if (ModelState.IsValid)
            {
                Guid userId = Guid.NewGuid(); 
                await _userRepository.InsertUserProfile(userId, model.Username, model.Firstname, model.Lastname, model.Password, model.Email);
                return Ok($"User profile with UserId {userId} created successfully.");
            }

            return BadRequest(ModelState);
        }
    }
}
