using System;
using System.Threading.Tasks;
using EruMobileScooter.Data;
using EruMobileScooter.Service.Repositories.Abstract;
using EruMobileScooter.Service.Repositories.Concreate;
using Microsoft.EntityFrameworkCore;

namespace EruMobileScooter.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ApplicationContext context)
        {
            Context = context;
        }
        public ApplicationContext Context {get;}

        private UserRepository _userRepository;
        public IUserRepository UserRepository {
            get {
                if(_userRepository == null)
                    _userRepository = new UserRepository(Context);
                return _userRepository;
            }
        }

        public bool Commit()
        {
           using(var transaction = Context.Database.BeginTransaction()){
               try{
                    Context.SaveChanges();
                    transaction.Commit(); 
                    return true;
               }catch (System.Exception)
               {
                   transaction.Rollback();
                   return false;
               }
           }
        }

        public async Task<bool> CommitAsync()
        {
            using(var transaction = await Context.Database.BeginTransactionAsync()){
               try{
                    await Context.SaveChangesAsync();
                    await transaction.CommitAsync(); 
                    return true;
               }catch (System.Exception)
               {
                   await transaction.RollbackAsync();
                   return false;
               }
           }
        }

        public void Rollback()
        {
           Context.Database.RollbackTransaction();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}