using API.DTOs;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth/staff")]
public class StaffController : ControllerBase
{
    private readonly IStaffService _authService;

    public StaffController(IStaffService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterStaffDto dto)
    {
       
        var result = await _authService.RegisterStaffAsync(dto.FirstName, dto.LastName, dto.Username, dto.Password, dto.Role);

        if (!result)
            return BadRequest("Username already in use.");

        return Ok("Staff registered.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(StaffLoginDto dto)
    {
        var token = await _authService.LoginAsync(dto.Username, dto.Password);

        if (token == null)
            return Unauthorized("Invalid credentials");

        return Ok(new { Token = token });
    }
    

}

