using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TaskContext _context;

        public AuthController(TaskContext context)
        {
            _context = context;
        }

        public static User user = new User();

        [HttpPost("register)")]

        public async Task<ActionResult<User>> Register(UserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.Username = request.Username;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            return Ok(user);
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using ( var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUserDto(UserDto userDto)
        {
            if (_context.Users_Table == null)
            {
                return Problem("Entity set 'TaskContext.TaskItems'  is null.");
            }
            _context.Users_Table.Add(userDto);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTaskItem", new { id = taskItem.Id }, taskItem);
            return CreatedAtAction(nameof(GetUserDto), new { id = userDto.Username }, userDto);
        }

        private object GetUserDto()
        {
            throw new NotImplementedException();
        }
    }
}
