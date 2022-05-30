using DomainLayer.Model;
using RepositoryLayer.DbContextLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Implentation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Category category)
        {
            _context.Categories.Add(category);
            int row_Column = _context.SaveChanges();
            return row_Column > 0;
        }

        public int Count(string searchValue)
        {
            return _context.Categories.Where(c=>c.CategoryName.Contains(searchValue)).Count();
        }

        public bool Delete(Category category)
        {
            _context.Categories.Remove(category);
            int row_Count = _context.SaveChanges(); 
            return row_Count > 0;
        }

        public Category FindById(int id)
        {   
            var query = from st in _context.Categories
                        where st.CategoryID == id
                        select st;
            var cate = query.FirstOrDefault<Category>();
           
            return cate;
            //return _context.Categories.Find(id);
        }

        public IList<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public bool InUsed(int categoryID)
        {
            var result = from product in _context.Products
                         where product.CategoryID == categoryID
                         select product;
            if (result.FirstOrDefault() == null)
                return true;
            else return false;
        }

        public IList<Category> ListOfCategories(int page, int pageSize, string searchValue)
        {
            var result = from category in _context.Categories
                         where category.CategoryName.Contains(searchValue)
                         select category;
            return result.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            /*var data = _context.Categories.Where(c => c.CategoryName.Contains(searchValue)).ToList();
            return data.Skip((page - 1) * pageSize).Take(pageSize).ToList();*/
        }

        public bool Update(Category category)
        {
            _context.Categories.Update(category);
            int row_count = _context.SaveChanges();
            return (row_count > 0);
        }
    }
}
