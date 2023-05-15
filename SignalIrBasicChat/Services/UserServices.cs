using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SignalIrBasicChat.Models;

namespace SignalIrBasicChat.Services
{
    public class UserServices : IUsers
    {
        private readonly ChatApplicationContext mContext;

        public UserServices(ChatApplicationContext mContext)
        {
            this.mContext = mContext;
        }

        public async Task<List<User>> GetVerifiedUsers()
        {
            return await this.mContext.Users.Where(user => user.bVerifiedEmail == true).ToListAsync();
        }

        public async Task CreateUser(string Username, string Password, string Email)
        {
            await this.mContext.Database
                .ExecuteSqlAsync($"EXEC dbo.GSCreateUsersWithNonDuplicatedUsernames {Username}, {Password}, {Email}");
        }
    }

    public interface IUsers
    {
        Task CreateUser(string Username, string Password, string Email);
        Task<List<User>> GetVerifiedUsers();
    }
}
