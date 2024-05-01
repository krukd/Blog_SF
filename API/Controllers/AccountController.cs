using API.Contracts.Services.IServices;
using API.Data.Models.Request.Users;
using API.Data.Models.Response.Roles;
using API.Data.Models.Response.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        //private readonly UserManager<User> _userManager;
        //private readonly RoleManager<Role> _roleManager;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
           

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {

            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                throw new ArgumentNullException("Запрос не корректен");

            var result = await _accountService.Login(request);

            if (!result.Succeeded)
                throw new AuthenticationException("Введенный пароль не корректен или не найден аккаунт");

            return StatusCode(200);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {

            var result = await _accountService.Register(request);
            if (result.Succeeded)
                return StatusCode(201);
            else
                return StatusCode(204);
        }
    }
}
