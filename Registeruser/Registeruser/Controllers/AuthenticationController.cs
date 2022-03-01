using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Registeruser.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Registeruser.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<ApplicationUser> userManager, IConfiguration configuration) {
            this.userManager = userManager;
            _configuration = configuration;
        
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {


            var userExist = await userManager.FindByNameAsync(model.UserName);


            //if (userExist! = null)

            //    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "error", Message = "User" });

            ApplicationUser user = new ApplicationUser()
                {

                    Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
                        };


                var result = await userManager.CreateAsync(user, model.Password);


                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "error", Message = "User" });

            }

            return Ok(new Response { Status = "success", Message = "User Created Successfully" });
            }
            
            }

           
        }

    

