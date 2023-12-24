using CQRSSamples.Command.DAL;
using CQRSSamples.Domain.Categories;
using CQRSSamples.Domain.Categories.Entities;
using CQRSSamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSSamples.Command.DAL.Categories
{
    public class EfCategoryRepository : EfCommandRepository<Category, RepoSampleCommandDbContext>, ICategoryRepository
    {
        public EfCategoryRepository(RepoSampleCommandDbContext context) : base(context)
        {
        }

        public void Add(Category category)
        {
            _dbContext.Categories.Add(category);
        }

    }
}
