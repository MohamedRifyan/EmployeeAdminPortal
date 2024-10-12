
using Microsoft.AspNetCore.Mvc;
using WebApplication5.DTO.RequestDTO;
using WebApplication5.DTO.ResponseDTO;

using WebApplication5.Services.IServices;

namespace WebApplication5.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Save")]
        public Task<ResponseDTO> Save(UserReqDTO req)
        {
            return  _userService.SaveUser(req);
        }

        [HttpPost("Update/{id}")]
        public Task<ResponseDTO> Update(long id,UserReqDTO req)
        {
            return _userService.UpdateUser(id, req);
        }

        [HttpGet("delete/{id}")]
        public Task<ResponseDTO> delete(long id)
        {
            return _userService.DeleteUser(id);
        }

        [HttpGet("GetUserByID/{id}")]
        public Task<ResponseDTO> GetUserByID(long id)
        {
            return _userService.GetByID(id);
        }

        [HttpGet("GetAllUsers")]
        public Task<ResponseDTO> GetAllUsers()
        {
            return _userService.GetAllUser();
        }

    }
}
