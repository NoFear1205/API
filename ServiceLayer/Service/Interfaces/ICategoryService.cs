using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Interfaces
{
    public interface ICategoryService
    {
        IList<Category> List(int page, int pageSize, string searchValue);
        IList<Category> GetAll();
        Category GetById(int id);
        bool   Add(Category category);
        bool Delete(Category category);
        bool Update(Category category);
        int Count(string searchValue);
        bool InUsed(int categoryID);
    }
}
