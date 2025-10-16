using GymMangementDAL.Data.Contextes;
using GymMangementDAL.Models;
using GymMangementDAL.Repositories.Classes;
using GymMangementDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.UnitOfWork.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GymMangementDbContext _dbContext;

        public UnitOfWork(GymMangementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        Dictionary<Type,object> Repositories = new Dictionary<Type,object>();

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseModel, new()
        {
            var _TEntity = typeof(TEntity);

            if (Repositories.TryGetValue(_TEntity, out var repository)) return (IGenericRepository<TEntity>)repository;

            var newRepository = new GenericRepository<TEntity>(_dbContext);

            Repositories.Add(_TEntity, newRepository);
            return newRepository;
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
