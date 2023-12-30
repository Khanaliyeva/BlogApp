using BlogApp.Business.DTOs;
using BlogApp.Business.Services.Implimentations;
using BlogApp.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IUserService _accountService;

        public AccountController(IUserService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] AppUserDto registerDto)
        {
            await _accountService.Register(registerDto);
            return StatusCode(StatusCodes.Status200OK);
        }

    }

}
