using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.DbContextLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Implentation
{
    public class ProductRepository:IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public string Add(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return "Successfull Add Customer";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }

        public int Count(string searchValue)
        {
            return _context.Products.Where(c => c.Name.Contains(searchValue)).Count();
        }

        public string Delete(Product product)
        {
            try
            {
                _context.Products.Remove(product);
                _context.SaveChanges(true);
                return "Successfully delete record";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Product FindById(int id)
        {
            var result = from product in _context.Products
                         where product.Id == id
                         select product;
            return result.FirstOrDefault();
            /*return applicationDbContext.Products.Where(x=>x.Id==id).FirstOrDefault();*/
        }

        public IList<Product> ListOfProduct(int page, int pageSize, string searchValue)
        {
            var result = from product in _context.Products
                         where product.Name.Contains(searchValue)
                         orderby product.Name
                         select product;
            return result.Include(c=>c.Category).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            /*var data = _context.Products.Include(c=>c.Category).Where((c) => c.Name.Contains(searchValue)).ToList();
            return data.Skip((page - 1) * pageSize).Take(pageSize).ToList();*/
        }

        public string Update(Product product)
        {
            try
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return "Successfully Update Customer";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
