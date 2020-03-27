using System;
using System.Collections.Generic;
using System.Linq;
using EruMobileScooter.Data;
using EruMobileScooter.Service.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EruMobileScooter.Service.Repositories.Concreate
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {

        private readonly ApplicationContext _context;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        /**
        * Marks As Deleted
        */
        public bool Delete(T entity)
        {
            _context.Remove<T>(entity);
            return _context.Entry<T>(entity).State == EntityState.Deleted;
        }
        /**
        * Marks As Deleted, Given Entity Id
        */
        public bool Delete(string id)
        {
            if(id.Trim().Equals("") || id == null) throw new ArgumentException($"Given Id Can Not Be Null Or Empty. Id Is {id} ");
            var entity = _context.Find(typeof(T),id) as T;
            _context.Remove<T>(entity);
            return _context.Entry<T>(entity).State == EntityState.Deleted;
        }
        /**
        * Gets Entity given id. @returns type as T
        */
        public T Get(string id)
        {
            if(id.Trim().Equals("") || id == null) return null;
            return _context.Find<T>(id);
        }
        /**
        *  exception ClassCastException
        */
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        /**
        *  Inserting Database for given entity
        */
        public T Insert(T entity)
        {
            if(entity == null)  return null;
            _context.Add<T>(entity);
            if(_context.Entry<T>(entity).State == EntityState.Added)
                return entity;
            else
                return null;
        }

        public T Update(T entity)
        {
            if(entity == null) return null;
            _context.Set<T>().Update(entity);
             if(_context.Entry(entity).State == EntityState.Modified)
                return entity;
            else
                return null;
        }
    }
}