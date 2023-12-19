using RepositorySamples.Domain.Categories.Entities;
using RepositorySamples.Domain.Products;
using RepositorySamples.Domain.Products.Entities;
using RepositorySamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySamples.DAL.Products
{
    public class EfProductRepository : EfRepository<Product, RepoSampleDbContext>, IProductRepository
    {
        public EfProductRepository(RepoSampleDbContext context) : base(context)
        {
        }

        public async void Add(Product product)
        {
            _dbContext.Add(product);            
        }
    }
}
