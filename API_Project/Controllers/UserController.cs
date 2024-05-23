using ECommerce.BL.DTOS.Cart;
using ECommerce.BL.DTOS.User;
using ECommerce.BL.Managers.Carts;
using ECommerce.BL.Managers.Users;
using ECommerce.DAL.Data.Context;
using ECommerce.DAL.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly EcommerceContext ecommerceContext;
        private readonly UserManager<User> userManager;
        private readonly ICustomUserManager customUserManager;
        private readonly ICartManager cartManager;

        public UserController(IConfiguration configuration, EcommerceContext ecommerceContext, UserManager<User> userManager, ICustomUserManager customUserManager,ICartManager cartManager)
        {
            this.configuration = configuration;
            this.ecommerceContext = ecommerceContext;
            this.userManager = userManager;
            this.customUserManager = customUserManager;
            this.cartManager = cartManager;
        }
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(RegisterDto registerDto) {
            var user = new User {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
            };
            var result = await userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);
            var claims = new List<Claim>
            {
            new (ClaimTypes.NameIdentifier,user.Id),
            new (ClaimTypes.Name,registerDto.UserName),
            new (ClaimTypes.Email,registerDto.Email),
            new (ClaimTypes.Role,registerDto.Role),
            };
            await userManager.AddClaimsAsync(user, claims);
            var cart = new AddCartDto { 
            UserId= user.Id,
            };
            cartManager.AddCart(cart);
            return Ok(new {Message="User Registered Successfully ",UserId=user.Id});
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto loginDto) {
            var user = await userManager.FindByNameAsync(loginDto.UserName);
            if (user is null)
                return Unauthorized();
            bool Authenticated = await userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!Authenticated)
                return Unauthorized();
            var userClaims = await userManager.GetClaimsAsync(user);
            return GenerateToken(userClaims);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadUserDto>>> GetAllUsers() {
           var users= await customUserManager.GetAll();
            if (users is null)
                return NotFound();
            return Ok(users);
        }
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        [Route("{Name}")]
        public async Task<ActionResult<ReadUserDto>> GetUserByName(string Name)
        {
            var user = await userManager.FindByNameAsync(Name);
            if(user is null)
                return NotFound();
            return Ok(user);
        }

            private ActionResult<TokenDto> GenerateToken(IEnumerable<Claim> userClaims)
        {
            var keyConfig = configuration.GetValue<string>(Constants.AppSettings.SecretKey)!;
            var keyInBytes=Encoding.ASCII.GetBytes(keyConfig);
            var key=new SymmetricSecurityKey(keyInBytes);

            var signingCreds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var expiryDate = DateTime.Now.AddMinutes(60);

            var jwt = new JwtSecurityToken(
                claims:userClaims,
                expires:expiryDate,
                signingCredentials:signingCreds
                );
            var jwtAsString = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new TokenDto { JwtToken= jwtAsString, ExpairyDate= expiryDate.ToString() };
        }
    }
}
