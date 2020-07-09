using System;
using System.Threading.Tasks;
using API.Extentions;
using API.Models;

namespace API.Data.Interfaces
{
    public interface IAppUserRepo
    {
        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<PagedList<AppUser>> GetAppUsers(AppUserParams appUserParams);

        Task<AppUser> GetAppUser(int id);

        Task<bool> SaveAll();
    }
}
