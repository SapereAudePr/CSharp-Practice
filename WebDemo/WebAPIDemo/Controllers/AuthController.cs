using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Models.DTO;
using WebAPIDemo.Repositories;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] AuthRegisterDto registerDto)
        {
            var identityUser = new IdentityUser()
            {
                UserName = registerDto.UserName,
                Email = registerDto.UserName,
            };


            var identityResult = await userManager.CreateAsync(identityUser, registerDto.Password);

            if (identityResult.Succeeded)
            {
                if (registerDto.Roles != null && registerDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerDto.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok();
                    }
                }
            }

            return BadRequest(identityResult.Errors);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto requestDto)
        {
            var user = await userManager.FindByEmailAsync(requestDto.UserName);

            if (user is not null)
            {
                var passwordResult = await userManager.CheckPasswordAsync(user, requestDto.Password);

                if (passwordResult)
                {
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles is not null)
                    {
                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        var loginResponse = new LoginResponseDto()
                        {
                            JWTToken = jwtToken
                        };

                        return Ok(loginResponse);
                    }
                }
                else
                {
                    return BadRequest("Password is wrong!");
                }
            }

            return BadRequest();
        }
    }
}
