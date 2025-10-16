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
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseModel, new()
    {
        private readonly GymMangementDbContext _dbContext;

        public GenericRepository(GymMangementDbContext dbContext) {
               _dbContext = dbContext;
        }

        void IGenericRepository<TEntity>.Add(TEntity entity) => _dbContext.Set<TEntity>().Add(entity);
        

        void IGenericRepository<TEntity>.Delete(TEntity entity) =>  _dbContext.Set<TEntity>().Remove(entity);
        

        IEnumerable<TEntity> IGenericRepository<TEntity>.GetAll(Func<TEntity, bool> condition)
        {
            if(condition is null)  return _dbContext.Set<TEntity>().AsNoTracking().ToList();
            else return _dbContext.Set<TEntity>().AsNoTracking().Where(condition).ToList();
                }

        TEntity? IGenericRepository<TEntity>.GetById(int id)
        {

            return _dbContext.Set<TEntity>().Find(id);
            
        }

        void IGenericRepository<TEntity>.Update(TEntity entity) => _dbContext.Set<TEntity>().Update(entity);

    }
}
