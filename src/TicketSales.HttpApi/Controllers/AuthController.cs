using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Business.Abstract;
using TicketSales.Core.Entities.Concrete;
using TicketSales.Core.Security.Jwt;
using TicketSales.Entities.Dtos.Users;
using TicketSales.HttpApi.Core;

namespace TicketSales.HttpApi.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);          

            var result = _authService.CreateAccessToken(userToLogin);
            if (result.Token != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email).Result;
            if (userExists == null)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
