﻿using JobPortal.Models;
using JobPortal.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository) {
            this.userRepository = userRepository;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserModel userModel)
        {
            try
            {
                Object tk = await userRepository.InsertUser(userModel);
                if (tk != null)
                {
                    return Ok(tk);
                }
                else { return BadRequest(); }
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody]LoginModel loginModel)
            {
            Object tk= await userRepository.LoginUser(loginModel);
            if(tk != null)
            {
                return Ok(tk);
            }
            else
            {
                return BadRequest();
            }
        }
       
    
    }
}
