using GymMangementDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseModel, new()
    {
        IEnumerable<TEntity> GetAll(Func<TEntity,bool>? condition = null);

        TEntity? GetById(int id);

        void Delete(TEntity entity);

        void Add(TEntity entity);

        void Update(TEntity entity);
    }

}