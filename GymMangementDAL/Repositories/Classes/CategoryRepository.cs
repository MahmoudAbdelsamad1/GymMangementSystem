using GymMangementDAL.Data.Contextes;
using GymMangementDAL.Models;
using GymMangementDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Classes
{
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly GymMangementDbContext _dbContext;
        public CategoryRepository(GymMangementDbContext dbContext)
        {

            _dbContext = dbContext;
        }

        public int AddCategory(Category category)
        {

            _dbContext.Categories.Add(category);
            return _dbContext.SaveChanges();
        }

        public int DeleteCategory(Category category)
        {

            _dbContext.Categories.Remove(category);
            return _dbContext.SaveChanges();


        }

        public IEnumerable<Category> GetAllCategories()
        {

            return _dbContext.Categories.ToList();

        }

        public Category? GetById(int id)
        {

            return _dbContext.Categories.Find(id);
        }

        public int UpdateCategory(Category category)
        {

            _dbContext.Categories.Update(category);
            return _dbContext.SaveChanges();
        }
    }
}
