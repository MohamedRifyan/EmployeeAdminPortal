using WebApplication5.DTO.RequestDTO;
using WebApplication5.DTO.ResponseDTO;

namespace WebApplication5.Services.IServices
{
    public interface IUserService
    {
        Task<ResponseDTO> SaveUser(UserReqDTO req);
        Task<ResponseDTO> UpdateUser(long id,UserReqDTO req);
        Task<ResponseDTO> GetAllUser();
        Task<ResponseDTO> GetByID(long id);
        Task<ResponseDTO> DeleteUser(long id);
    }
}
