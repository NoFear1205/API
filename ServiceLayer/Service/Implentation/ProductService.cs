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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _product;
        public ProductService(IProductRepository productRepository)
        {
            _product = productRepository;
        }
        /// <summary>
        /// Add Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string Add(Product product)
        {
                return _product.Add(product);
        }

        public string Delete(int id)
        {

                var data = _product.FindById(id);
                return _product.Delete(data);

        }
        /// <summary>
        /// Get All Customer record
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IList<Product> GetAll(int page, int pageSize, string searchValue)
        {
            if (page <= 0)
            {
                page = 1;
            }
            if (pageSize <= 0)
            {
                pageSize = 10;
            }
            if (searchValue == null)
            {
                searchValue = "";
            }
            return _product.ListOfProduct(page, pageSize, searchValue);
        }
        public int Count(string searchValue)
        {
            var data = _product.Count(searchValue);
            return data;
        }
        /// <summary>
        /// Get single record Customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Product FindById(int id)
        {
            //return _db.Customers.Where(c=>c.CustomerID==id).FirstOrDefault();
            return _product.FindById(id);
        }

        public string Update(Product product)
        {
                return _product.Update(product);
        }
    }
}
