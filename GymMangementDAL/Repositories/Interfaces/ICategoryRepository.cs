using GymMangementDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();

        Category? GetById(int id);

        int DeleteCategory(Category category);

        int AddCategory(Category category);

        int UpdateCategory(Category category);
    }
}

