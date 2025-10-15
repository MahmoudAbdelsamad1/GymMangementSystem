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

        int Delete(TEntity entity);

        int Add(TEntity entity);

        int Update(TEntity entity);
    }

}