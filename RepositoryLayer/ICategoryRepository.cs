using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public interface ICategoryRepository
    {
        IList<Category> ListOfCategories(int page, int pageSize, string searchValue);
        IList<Category> GetAll();
        Category FindById(int id);
        bool Add(Category category);
        bool Update(Category category); 
        bool Delete(Category category);
        int Count(string searchValue);
        bool InUsed(int categoryID);

    }
}
