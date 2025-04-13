using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using OnRideApp.Models.Dtos.AuthDto;

namespace TaskDoner.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> userManager;

    private readonly ITokenService tokenService;

    public AuthController(UserManager<IdentityUser> userManager,
        ITokenService tokenService)
    {
        this.userManager = userManager;
        this.tokenService = tokenService;
    }

    //[HttpGet]
    //[Authorize]
    //public IActionResult Get()
    //{
    //    return Ok(new { message = "Hello" });
    //}

    // Post : /api/Auth/Register
    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
    {
        var identityUser = new IdentityUser
        {
            UserName = registerRequestDto.Username,
            Email = registerRequestDto.Username
        };

        var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

        if (identityResult.Succeeded)
        {
            // add roles to this user
            if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
            {
                identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                if (identityResult.Succeeded)
                {
                    return Ok(new { message = "User was registered ! please login." } );
                }
            }
        }

        return BadRequest(new { message = "Something went wrong" } );
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
    {
        var user = await userManager.FindByEmailAsync(loginRequestDto.Username);

        if (user != null)
        {
            var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if (checkPasswordResult)
            {
                // Get the roles for this user
                var roles = await userManager.GetRolesAsync(user);
                if (roles != null)
                {
                    var jwtToken = tokenService.CreateJwtToken(user, roles.ToList());

                    var response = new LoginResponseDto
                    {
                        JwtToken = jwtToken
                    };

                    // create token
                    return Ok(response);
                }
            }
        }

        return BadRequest(new { message = "Username or password incorrect!" });
    }
}