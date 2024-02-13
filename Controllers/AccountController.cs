using backend_resell_app.Data.Dto;
using backend_resell_app.Interfaces;
using backend_resell_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_resell_app.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountController(IUnitOfWork uow)
        {
            this._unitOfWork = uow;
        }

        // api/account/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginReqDto loginReq)
        {
            var user = await _unitOfWork.UserRepository.Authenticate(loginReq.Username, loginReq.Password);
            if(user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }
    }
}
