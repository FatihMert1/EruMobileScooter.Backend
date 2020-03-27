using System;
using System.Threading.Tasks;
using EruMobileScooter.Service.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EruMobileScooter.Service
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository {get;}
        DbContext Context {get;}
        bool Commit();
        Task<bool> CommitAsync();

        void Rollback();
    }
}
