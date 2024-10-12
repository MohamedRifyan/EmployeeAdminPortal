using Microsoft.AspNetCore.Components.Forms;
using WebApplication5.Data;
using WebApplication5.DTO.RequestDTO;
using WebApplication5.DTO.ResponseDTO;
using WebApplication5.Helper;
using WebApplication5.Models.Entities;
using WebApplication5.Services.IServices;

namespace WebApplication5.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDTO> DeleteUser(long id)
        {
            try
            {
                var user = _context.UserMasters.Find(id);
                if (user != null)
                {
                    _context.UserMasters.Remove(user);
                    _context.SaveChanges();
                    return new ResponseDTO(true, "User deleted successfully");
                }
                return new ResponseDTO(false, "No user found");
            }
            catch (Exception ex)
            {
                return new ResponseDTO(false, $"Error deleting user: {ex.Message}");
            }

        }

        public async Task<ResponseDTO> GetAllUser()
        {
            try
            {
                var users = _context.UserMasters.ToList();
                return new ResponseDTO(users);

            }
            catch (Exception ex)
            {

                return new ResponseDTO(false, $"Error retrieving users: {ex.Message}");

            }

        }

        public async Task<ResponseDTO> GetByID(long id)
        {
            try
            {

                var user = _context.UserMasters.Find(id);
                if (user != null)
                {
                    return new ResponseDTO(user);
                }

                return new ResponseDTO(false, "No user found");

            }
            catch (Exception ex)
            {

                return new ResponseDTO(false, $"Error retrieving user: {ex.Message}");
            }
        }

        public async Task<ResponseDTO> SaveUser(UserReqDTO req)
        {
            string ErrMsg = ValidationHelperServices.UserValidator(req);
            try
            {
                if (string.IsNullOrEmpty(ErrMsg)) {
                    var user = new UserMaster
                    {
                        Name = req.Name,
                        Email = req.Email,
                        Password = req.Password,
                        Phone = req.Phone
                    };
                    _context.UserMasters.Add(user);
                    _context.SaveChanges();
                    return new ResponseDTO(true, "User Saved Successfully");
                }
                return new ResponseDTO(false, ErrMsg);

            }
            catch (Exception ex)
            {
                return new ResponseDTO(false, $"Error saving user: {ex.Message}");
            }


        }

        public async Task<ResponseDTO> UpdateUser(long id, UserReqDTO req)
        {
            string ErrMsg = ValidationHelperServices.UserValidator(req);
            try
            {
                if (string.IsNullOrEmpty(ErrMsg))
                {
                    var user = _context.UserMasters.Find(id);
                    if (user != null)
                    {
                        user.Name = req.Name;
                        user.Email = req.Email;
                        user.Password = req.Password;
                        user.Phone = req.Phone;
                        _context.SaveChanges();
                        return new ResponseDTO(true, "User updated successfully");
                    }
                    return new ResponseDTO(false, "No user found");
                }
                return new ResponseDTO(false, ErrMsg);
            }
            catch (Exception ex)
            {

                return new ResponseDTO(false, $"Error updating user: {ex.Message}"); 
            }
        }
    }
}
