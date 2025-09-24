using server.Data;
using server.Entities;
using Microsoft.EntityFrameworkCore;

namespace server.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthContex contex;

        public UserRepository(AuthContex contex)
        {
            this.contex = contex;
        }

        public async Task<bool> AddUser(User user)
        {
            await this.contex.AddAsync(user);
            return await this.contex.SaveChangesAsync() > 0 ? true:false;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await this.contex.users
                .Where(u => u.Email == email)
                .SingleOrDefaultAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await this.contex.users.ToListAsync();
        }
    }
}
