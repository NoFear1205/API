using DomainLayer.Model;
using RepositoryLayer.DbContextLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Implentation
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public string Add(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return "Successfull Add Customer";
            }catch (Exception ex)
            {
                return ex.Message;
            }
            
            
        }

        public int Count(string searchValue)
        {
            return _context.Customers.Where(c=>c.CustomerName.Contains(searchValue)).Count();
        }

        public string Delete(Customer customer)
        {
            try
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges(true);
                return "Successfully delete record";
            }   
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Customer FindById(int id)
        {
            var result = from customer in _context.Customers
                         where customer.CustomerID == id
                         select customer;
            return result.FirstOrDefault();
          /*  return applicationDbContext.Customers.Find(id);*/
        }

        public IList<Customer> ListOfCustomers(int page, int pageSize, string searchValue)
        {
            var result = from customer in _context.Customers
                         where customer.CustomerName.Contains(searchValue)
                         orderby customer.CustomerName
                         select customer;
            return result.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            /* var data= _context.Customers.Where((c)=>c.CustomerName.Contains(searchValue)).ToList();
             return data.Skip((page-1)*pageSize).Take(pageSize).ToList();*/
        }

        public string Update(Customer customer)
        {
            try
            {
                _context.Customers.Update(customer);
                return "Successfully Update Customer";
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
