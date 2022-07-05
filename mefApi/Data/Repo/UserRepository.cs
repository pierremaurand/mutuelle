using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Data.Repo
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext dc;
        public UserRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public async Task<User?> Authenticate(string email, string passwordText)
        {
            if(dc.Users is null)
                return null;

            var user = await dc.Users.FirstOrDefaultAsync(x => x.Email == email);
        

            if (user is null || !MatchPasswordHash(passwordText, user.Password, user.PasswordKey))
                return null;
            
            return user;
        }

        private bool MatchPasswordHash(string passwordText, byte[] password, byte[] passwordKey)
        {
            using (var hmac = new HMACSHA512(passwordKey))
            {
                var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwordText));

                for (int i=0; i<passwordHash.Length; i++) 
                {
                    if(passwordHash[i] != password[i])
                        return false;
                }

                return true;
            }
        }

        public void Register(UserReqDto userDto, string password)
        {
            byte[] passwordHash, passwordKey;

            using (var hmac = new HMACSHA512())
            {
                passwordKey = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

            User user = new User();
            user.UserName = userDto.UserName;
            user.Email = userDto.Email;
            user.Password = passwordHash;
            user.PasswordKey = passwordKey;
            user.Mobile = userDto.Mobile;

            if(dc.Users is not null) {
              dc.Users.Add(user);  
            }
        }

        public async Task<bool> UserAlreadyExists(string email)
        {
            if(dc.Users is not null) {
                return await dc.Users.AnyAsync(x => x.Email == email);
            }
            return false;
        }

        public User FindById(int id)
        {
            if(dc.Users is not null) {
                var user = dc.Users.Find(id);
                if(user is not null) {
                    return user;
                }
            }
            
            return new User{};
        }

        public async Task<User> FindByIdAsync(int id)
        {
            if(dc.Users is not null) {
                var user = await dc.Users.FindAsync(id);
                if(user is not null) {
                    return user;
                }
            }
            
            return new User{};
        }
    }
}