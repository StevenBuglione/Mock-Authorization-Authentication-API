using System;
using System.Threading.Tasks;
using API.Data.Interfaces;
using API.Extentions;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class AppUserRepo : IAppUserRepo
    {
        private readonly DataContext _context;

        public AppUserRepo(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<PagedList<AppUser>> GetAppUsers(AppUserParams appUserParams)
        {
            var appUsers = _context.Users.AsQueryable();

            // Add Queryable definitions to the GetAppUsers Methods to act a a filter for what ever you need
            // This method will return all users depending on the pagination settings

            return await PagedList<AppUser>.CreateAsync(appUsers, appUserParams.PageNumber, appUserParams.PageSize);
        }

        public async Task<AppUser> GetAppUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
            
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
