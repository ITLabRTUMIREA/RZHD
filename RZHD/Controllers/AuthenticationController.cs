using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RZHD.Models;
using RZHD.Models.Requests.Auth;
using RZHD.Models.Responses.Auth;
using RZHD.Services.Authorize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZHD.Controllers
{
    [Route("api/auth")]
    public class AuthenticationController : MainController
    {
        private readonly UserManager<User> userManager;
        private readonly IJwtFactory jwtFactory;

        public AuthenticationController(UserManager<User> userManager, IJwtFactory jwtFactory)
        {
            this.userManager = userManager;
            this.jwtFactory = jwtFactory;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<LoginView>> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(loginRequest.Email)
                    ?? throw new ArgumentNullException();

                if (!await userManager.CheckPasswordAsync(user, loginRequest.Password))
                    return Forbid(JwtBearerDefaults.AuthenticationScheme);

                return Ok(new LoginView
                {
                    AccessToken = jwtFactory.GenerateAccessToken(user.Id)
                });
            }
            catch (ArgumentNullException ane)
            {
                return NotFound("Can't find user");
            }
        }
    }
}
