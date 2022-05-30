using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Interfaces
{
    public interface IProductService
    {
        //GetAll record
        IList<Product> GetAll(int page, int pageSize, string searchValue = "");
        //Get Single record
        Product FindById(int id);
        //Add record
        string Add(Product product);
        //Update or edit record
        string Update(Product product);
        //Delete or remove
        string Delete(int id);
        int Count(string searchValue);
    }
}
