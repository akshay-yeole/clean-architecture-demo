using application.Dtos;
using application.Features.Product.Commands;
using application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AuthController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(RegisterRequest createUser, CancellationToken cancellationToken)
        {
            var result = await _accountService.RegisterUser(createUser);
            return Ok(result);
        }
    }
}
