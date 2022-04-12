
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> Authenticate(string userName, string password);
        void Register(UserReqDto userDto, string password);
        Task<bool> UserAlreadyExists(string userName);
        User FindById(int id);
        Task<User> FindByIdAsync(int id);
    }
}