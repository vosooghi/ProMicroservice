using CQRSSamples.Domain.Products.Entities;
using CQRSSamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSSamples.Domain.Products
{
    public interface IProductRepository : ICommandRepository<Product>
    {
        public void Add(Product product);
    }
}
