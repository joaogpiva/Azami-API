using Azami.Models;
using Azami.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Azami.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            List<UserModel> users = await _userRepository.GetAllUsers();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetById(int id)
        {
            UserModel user = await _userRepository.GetById(id);

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> AddUser([FromBody] UserModel user)
        {
            UserModel addedUser = await _userRepository.AddUser(user);

            return Ok(addedUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel user, int id)
        {
            user.Id = id;
            UserModel updatedUser = await _userRepository.UpdateUser(user, id);

            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> DeleteUser(int id)
        {
            bool wasDeleted = await _userRepository.DeleteUser(id);
            return Ok(wasDeleted);
        }
        [HttpGet("login")]
        public async Task<ActionResult<UserModel>> Login(string email, string password)
        {
            UserModel foundUser = await _userRepository.Login(email, password);
            if (foundUser == null)
            {
                return NotFound("User not found in database");
            }
            return Ok(foundUser);
        }
    }
}
