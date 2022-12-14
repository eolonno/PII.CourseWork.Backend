using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getuserdetaildtobyuserid")]
        public IActionResult GetUserDetailDtoByUserId(int id)
        {
            var result = _userService.GetUserDetailDtoByUserId(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getuserdetailbyemail")]
        public IActionResult GetUserDetailByMail(string email)
        {
            var result = _userService.GetByMail(email);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("updateuserdetails")]
        public IActionResult UpdateUserDetails(UserDetailForUpdateDto userDetailForUpdate)
        {
            var result = _userService.UpdateUserDetails(userDetailForUpdate);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPut("toggle-user-status/{userId}")]
        public IActionResult ToggleUserStatus([FromRoute] int userId)
        {
            var result = _userService.ToggleUserStatus(userId);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}