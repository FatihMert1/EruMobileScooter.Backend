using System;
using System.Threading.Tasks;
using EruMobileScooter.Data;
using EruMobileScooter.Service.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EruMobileScooter.Service
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository {get;}
        ApplicationContext Context {get;}
        bool Commit();
        Task<bool> CommitAsync();

        void Rollback();
    }
}
