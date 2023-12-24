using CQRSSamples.Command.DAL;
using CQRSSamples.Domain.Categories.Entities;
using CQRSSamples.Domain.Products;
using CQRSSamples.Domain.Products.Entities;
using CQRSSamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSSamples.Command.DAL.Products
{
    public class EfProductRepository : EfCommandRepository<Product, RepoSampleCommandDbContext>, IProductRepository
    {
        public EfProductRepository(RepoSampleCommandDbContext context) : base(context)
        {
        }

        public async void Add(Product product)
        {
            _dbContext.Add(product);
        }
    }
}
