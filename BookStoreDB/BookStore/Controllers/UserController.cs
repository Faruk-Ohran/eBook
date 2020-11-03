﻿using BookStore.Dal.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var users = await _userRepository.GetTopTen();
        //    return Ok(users);
        //}

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserDto user)
        {
            var newUser = await _userRepository.AddUser(user);
            return Ok(newUser);
        }
        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody] UserLoginDto user)
        {
            var User = await _userRepository.LogInUser(user);
            return Ok(User);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserDto user)
        {
            var User = await _userRepository.UpdateUser(user);
            return Ok(User);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateImg([FromBody] UserDto user)
        {
            var User = await _userRepository.UpdateImage(user);
            return Ok(User);
        }

        [HttpPut, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }

}
