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

        public async Task<List<User>> GetUsers()
        {
            return await this.mContext.Users.FromSql($"EXEC dbo.GetVerifiedUsers").ToListAsync();
        }
    }

    public interface IUsers
    {
        Task<List<User>> GetUsers();
    }
}
