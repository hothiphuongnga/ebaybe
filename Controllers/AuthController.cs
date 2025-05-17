using ebaybe.Models;
using ebaybe.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoApiNet9.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _auth;

    public AuthController(IAuthService auth)
    {
        _auth = auth;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] User user)
    {
        var token = await _auth.Login(user.Email, user.Password);
        return new ResponseEntity(200, token, "Đăng nhập thành công");

    }
}
