using Azami.Data;
using Azami.Models;
using Azami.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Azami.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AzamiDbContext _dbContext;
        public UserRepository(AzamiDbContext azamiDbContext) { 
            this._dbContext = azamiDbContext;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetById(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel user = await _dbContext.Users.FindAsync(id);

            if (user == null) {
                throw new Exception("User not found.");
            }
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userToUpdate = await _dbContext.Users.FindAsync(id);

            if (userToUpdate == null)
            {
                throw new Exception("User not found.");
            }
            userToUpdate.Name = user.Name;
            userToUpdate.Email = user.Email;
            userToUpdate.MasterPassword = user.MasterPassword;

            _dbContext.Update(userToUpdate);
            await _dbContext.SaveChangesAsync();
            return userToUpdate;
        }
    }
}
