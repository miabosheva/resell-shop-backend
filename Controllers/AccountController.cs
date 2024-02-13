using backend_resell_app.Data.Dto;
using backend_resell_app.Interfaces;
using backend_resell_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace backend_resell_app.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public AccountController(IUnitOfWork uow, IConfiguration configuration)
        {
            this._unitOfWork = uow;
            this._configuration = configuration;
        }

        // api/account/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginReqDto loginReq)
        {
            var user = await _unitOfWork.UserRepository.Authenticate(loginReq.Username, loginReq.Password);
            if(user == null)
            {
                return Unauthorized("Invalid Credentials.");
            }

            var loginResDto = new LoginResDto();
            loginResDto.UserName = user.Username;
            loginResDto.Token = CreateJWT(user);
            return Ok(loginResDto);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            var addedUser = await _unitOfWork.UserRepository.Register(user.Username, user.Password, user.Email, user.PhoneNumber);
            if (addedUser == null)
            {
                return Unauthorized("Registration failed.");
            }

            var loginResDto = new LoginResDto();
            loginResDto.UserName = addedUser.Username;
            loginResDto.Token = CreateJWT(addedUser);
            return Ok(loginResDto);
        }

        private string CreateJWT(User user)
        {
            var secretKey = _configuration.GetSection("AppSettings:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var signingCredentials = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
