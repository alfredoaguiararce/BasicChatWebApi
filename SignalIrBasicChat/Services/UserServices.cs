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

        public async Task CreateUser(string Username, string Password, string Email)
        {
            await this.mContext.Database
                .ExecuteSqlAsync($"EXEC dbo.GSCreateUsersWithNonDuplicatedUsernames {Username}, {Password}, {Email}");
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await this.mContext.Users.ToListAsync();
        }

        async Task<List<User>> IUsers.GetVerifiedUsers()
        {
            return await this.mContext.Users.Where(user => user.bVerifiedEmail == true).ToListAsync();
        }


        public async Task DeleteUserById(int nUserId)
        {
            User? UserToBeDeleted = await this.mContext.Users.Where(user => user.nUserId == nUserId).FirstOrDefaultAsync();
            if (UserToBeDeleted is null) throw new InvalidOperationException($"There's no user with id : {nUserId}");
            this.mContext.Remove<User>(UserToBeDeleted);
            await this.mContext.SaveChangesAsync();
        }



    }

    public interface IUsers
    {
        Task CreateUser(string Username, string Password, string Email);
        Task DeleteUserById(int nUserId);
        Task<List<User>> GetAllUsers();
        Task<List<User>> GetVerifiedUsers();
    }
}
