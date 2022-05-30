using DomainLayer.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Interfaces
{
    public interface ICustomerService
    {
        //GetAll record
        IList<Customer> GetAll(int page, int pageSize, string searchValue = "");
        //Get Single record
        Customer FindById(int id);
        //Add record
        string Add(Customer customer);
        //Update or edit record
        string Update(Customer customer);
        //Delete or remove
        string Delete(int id);
        int Count(string searchValue);

    }
}
