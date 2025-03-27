using AAuthentic.Application.Users;
using AAuthentic.Application.Validation;
using AAuthentic.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AAuthentic.API.Controllers;

[Route("controller")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService userService;
    private readonly IValidationService validationService;
    public AuthController(IUserService userService,
        IValidationService validationService)
    {
        this.userService = userService;
        this.validationService = validationService;
    }

    public async Task<IActionResult> Register()
    {
        return Ok();
    }

    public async Task<IActionResult> Login()
    {
        return Ok();
    }
}
