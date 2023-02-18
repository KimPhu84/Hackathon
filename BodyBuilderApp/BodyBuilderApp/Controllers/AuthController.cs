using Microsoft.AspNetCore.Mvc;
using BodyBuilderApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BodyBuilderApp.Modules.CustomerModule.Interface;
using BodyBuilderApp.Modules.CustomerModule.Request;

namespace Traibanhoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly ICustomerService _AuthService;
        private readonly ITokenHandler _tokenHandler;

        public AuthsController(ICustomerService AuthService, ITokenHandler tokenHandler)
        {
            _AuthService = AuthService;
            _tokenHandler = tokenHandler;
        }

        // GET: api/Auths
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginCustomerRequest loginCustomerRequest)
        {
            var user = await _AuthService.AuthencationAsync(loginCustomerRequest.Email, loginCustomerRequest.Password);
            if (user != null)
            {
                var token = await _tokenHandler.CreateTokenAsync(user);
                return Ok(token);
            }
            return BadRequest("UserName or Password is not Correct ");
        }

    }
}
