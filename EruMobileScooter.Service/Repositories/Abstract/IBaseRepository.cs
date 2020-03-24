using System.Collections.Generic;
using EruMobileScooter.Data;

namespace EruMobileScooter.Service.Repositories.Abstract{

    public interface IBaseRepository<T> where T : BaseEntity
    {
        T Get(string id);
        IEnumerable<T> GetAll();
        T Insert(T entity);
        bool Delete(T entity);
        bool Delete(string id);
        T Update(T entity);
    }
}