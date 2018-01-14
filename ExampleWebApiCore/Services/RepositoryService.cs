using System;
using System.Linq;
using System.Linq.Expressions;
using ExampleWebApiCore.Models.General;
using ExampleWebApiCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExampleWebApiCore.Services
{
    public class RepositoryService<TEntity> : IRepositoryService<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext _context;

        public RepositoryService(DbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAllNoFilteredEntities()
        {
//            return _context.Set<TEntity>().AsNoFilter();
            throw new NotImplementedException();
        }

        public void HardDelete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public TEntity AddOrUpdate(Expression<Func<TEntity, object>> e, TEntity entity)
        {
            throw new NotImplementedException();

//            _context.Set<TEntity>().AddOrUpdate(e, entity);
//            _context.SaveChanges();
//            return entity;
        }

        public TEntity Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }
        public void Update(TEntity entity)
        {
            _context.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            _context.SaveChanges();
        }
        public TEntity Find(params object[] keyValues)
        {
            return _context.Set<TEntity>().Find(keyValues);
        }

    }
}