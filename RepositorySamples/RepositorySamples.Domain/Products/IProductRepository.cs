using RepositorySamples.Domain.Products.Entities;
using RepositorySamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySamples.Domain.Products
{
    public interface IProductRepository:IRepository<Product>
    {
        public void Add(Product product);
    }
}
