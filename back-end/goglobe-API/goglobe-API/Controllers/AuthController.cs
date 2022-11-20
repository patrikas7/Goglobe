using AutoMapper;
using goglobe_API.Auth;
using goglobe_API.Auth.Model;
using goglobe_API.Data.DTOs.Auth;
using goglobe_API.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace goglobe_API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("/api")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenManager _tokenManager;

        public AuthController(UserManager<User> userManager, IMapper mapper, ITokenManager tokenManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenManager = tokenManager;
        }

        [HttpPost]
        [Route("user/register")]
        public async Task<IActionResult> RegisterUser(RegisterUserDto registerUserDto)
        {
            var user = await _userManager.FindByEmailAsync(registerUserDto.Email);
            if(user != null) 
                return BadRequest("Request invalid");

            var newUser = new Client
            {
                Email = registerUserDto.Email,
                Name = registerUserDto.Name,
                Surname = registerUserDto.Surname,
                BirthDate = registerUserDto.BirthDate,
                UserName = registerUserDto.Name
            };

            var createUserResult = await _userManager.CreateAsync(newUser, registerUserDto.Password);
            if (!createUserResult.Succeeded)
                return BadRequest("Could not create a user");

            await _userManager.AddToRoleAsync(newUser, UserRoles.Client);
            return CreatedAtAction(nameof(RegisterUser), _mapper.Map<UserDTO>(newUser));
        }

        [HttpPost]
        [Route("admin/register")]
        public async Task<IActionResult> RegisterAdmin(RegisterAdminDto registerAdminDto)
        {
            var user = await _userManager.FindByEmailAsync(registerAdminDto.Email);
            if (user != null)
                return BadRequest("Request invalid");

            var newUser = new Administrator
            {
                Email = registerAdminDto.Email,
                Name = registerAdminDto.Name,
                Surname = registerAdminDto.Surname,
                UserName = registerAdminDto.Name
            };

            var createUserResult = await _userManager.CreateAsync(newUser, registerAdminDto.Password);
            if (!createUserResult.Succeeded)
                return BadRequest("Could not create admin");

            await _userManager.AddToRoleAsync(newUser, UserRoles.Admin);
            return CreatedAtAction(nameof(RegisterAdmin), _mapper.Map<UserDTO>(newUser));
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null)
                return BadRequest("User name or password is invalid");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            if (!isPasswordValid)
                return BadRequest("User name or password is invalid");

            var accessToken = await _tokenManager.CreateAccessTokenAsync(user);

            return Ok(new SuccessfullLoginDTO(accessToken, user.Name));
        }
    }
}
