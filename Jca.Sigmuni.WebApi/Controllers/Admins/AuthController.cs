using Jca.Sigmuni.Application.Dtos.Admins.Users;
using Jca.Sigmuni.Application.Services.Admins.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.Admins
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUserService _userService;
        public AuthController(ILogger<AuthController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioTokenDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<UsuarioTokenDto>>> Post([FromBody] UsuarioLoginDto request)
        {
            var response = await _userService.LoginAsync(request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }

    }
}
