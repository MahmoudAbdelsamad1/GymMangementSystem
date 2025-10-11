using GymMangementDAL.Data.Contextes;
using GymMangementDAL.Models;
using GymMangementDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Classes
{
    internal class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseModel, new()
    {
        private readonly GymMangementDbContext _dbContext;

        public GenericRepository(GymMangementDbContext dbContext) {
               _dbContext = dbContext;
        }

        int IGenericRepository<TEntity>.Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return _dbContext.SaveChanges();
        }

        int IGenericRepository<TEntity>.Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return _dbContext.SaveChanges();
        }

        IEnumerable<TEntity> IGenericRepository<TEntity>.GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking().ToList();
        }

        TEntity? IGenericRepository<TEntity>.GetById(int id)
        {

            return _dbContext.Set<TEntity>().Find(id);
            
        }

        int IGenericRepository<TEntity>.Update(TEntity entity)
        {
                _dbContext.Set<TEntity>().Update(entity);
            return _dbContext.SaveChanges();
        }
    }
}
