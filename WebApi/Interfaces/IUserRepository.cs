using hspaApi2.Dtos;
using hspaApi2.Models;

namespace hspaApi2.Interfaces
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