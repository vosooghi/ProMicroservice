using RepositorySamples.Domain.Categories;
using RepositorySamples.Domain.Categories.Entities;
using RepositorySamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySamples.DAL.Categories
{
    public class EfCategoryRepository : EfRepository<Category, RepoSampleDbContext>, ICategoryRepository
    {
        public EfCategoryRepository(RepoSampleDbContext context) : base(context)
        {
        }

        public void Add(Category category)
        {
            _dbContext.Categories.Add(category);            
        }
      
    }
}
