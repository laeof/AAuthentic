using AAuthentic.API.DTOs;
using AAuthentic.API.Requests;
using Microsoft.AspNetCore.Mvc;

namespace AAuthentic.API.Controllers;

[Route("controller")]
[ApiController]
public class AuthController : ControllerBase
{
    public AuthController()
    {
    }

    public async Task<IActionResult> Register(RegisterRequest request)
    {
        return Ok();
    }

    public async Task<IActionResult> Login(LoginRequest request)
    {
        return Ok();
    }
}
