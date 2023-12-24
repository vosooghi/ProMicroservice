using CQRSSamples.Domain.Categories.Entities;
using CQRSSamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSSamples.Domain.Categories
{
    public interface ICategoryRepository : ICommandRepository<Category>
    {
        public void Add(Category category);
    }
}
