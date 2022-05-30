using DomainLayer.Model;
using RepositoryLayer;
using ServiceLayer.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Implentation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _cate;

        public CategoryService(ICategoryRepository cate)
        {
            _cate = cate;
        }

        public bool Add(Category category)
        {
            return _cate.Add(category);
        }

        public int Count(string searchValue)
        {
            return _cate.Count(searchValue);
        }

        public bool Delete(Category category)
        {
            return _cate.Delete(category);
        }

        public IList<Category> List(int page, int pageSize, string searchValue)
        {
            return _cate.ListOfCategories(page, pageSize, searchValue);
        }

        public IList<Category> GetAll()
        {
            return _cate.GetAll();
        }

        public Category GetById(int id)
        {
           return _cate.FindById(id);
        }

        public bool InUsed(int categoryID)
        {
            return _cate.InUsed(categoryID);
        }

        public bool Update(Category category)
        {
            return _cate.Update(category);
        }
    }
}
