using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Data.EF;
using WebApi.Data.Models;
using WebApi.Helper;
using WebApi.Repository;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly QuanLyVatTuContext _context;
        private readonly IConfiguration _config;

        public UsersController(IUserRepository userRepository, QuanLyVatTuContext conext, IConfiguration config)
        {
            _userRepository = userRepository;
            _context = conext;
            _config = config;
            //_config = config;
        }

        [HttpGet]

        public IActionResult GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]

        public IActionResult GetUserById(int id)


        {
            var user = _userRepository.GetUserById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest(" không tìm thấy user ");
        }

        [HttpPost]

        public async Task<IActionResult> Add([FromForm] UserModel user)
        {
            return Ok(await _userRepository.Add(user));
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateUser(int id,[FromForm] UserModel user)
        {
            try
            {
                await _userRepository.UpdateUser(id, user);
                return Ok();
            }
            catch 
            {
                return BadRequest();
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
            return NoContent();
        }

        [HttpPost("Login")]

        public IActionResult Validate(LoginVM login)
        
        {
            login.MatKhau = CreateMD5.GetMD5(login.MatKhau);
            var user = _context.Users.FirstOrDefault(o => o.Username == login.Username && o.MatKhau == login.MatKhau);
            if (user == null)
            {
                return Ok(
                    new ApiResponse
                    {
                        Success = true,
                        Message = "chua co tai khoan"
                    });
            }
            return Ok(
                    new ApiResponse
                    {
                        Success = true,
                        Message = " dang nhap thanh cong",
                        Data = GenerateToken(user)
                    }
                );
        }
        private string GenerateToken(User user)
        {
            var jwtTokenHandle = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_config["JWT:SecretKey"]);

            var jwtTokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                        new[]
                        {
                            new Claim(ClaimTypes.Name, user.HoTen),
                             new Claim(ClaimTypes.Email, user.Email),

                            new Claim("TokenId",Guid.NewGuid().ToString())

                        }
                        ),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey
                (secretKeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = jwtTokenHandle.CreateToken(jwtTokenDescription);
            return jwtTokenHandle.WriteToken(token);
        }

    }
}
