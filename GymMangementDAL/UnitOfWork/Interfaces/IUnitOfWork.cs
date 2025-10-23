using GymMangementDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public ISessionRepository SessionRepository { get; }

        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseModel , new();

        int SaveChanges();

    }
}
