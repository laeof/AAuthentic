using AAuthentic.Application.Users;
using AAuthentic.Application.Validation;
using Microsoft.AspNetCore.Mvc;

namespace AAuthentic.API.Controllers;

[Route("controller")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IValidationService validationService;
    public AuthController(
        IValidationService validationService)
    {
        this.userService = userService;
        this.validationService = validationService;
    }

    public async Task<IActionResult> Register(RegisterDto dto)
    {
        
    }

    public async Task<IActionResult> Login(LoginDto dto)
    {
        return Ok();
    }
}
