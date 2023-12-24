using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSSamples.Framework
{
    public class EfQueryRepository<TDbContext>:IQueryRepository    
         where TDbContext : BaseQueryDbContext
    {
        protected readonly TDbContext _dbContext;
        public EfQueryRepository(TDbContext context)
        {
            _dbContext = context;
        }

    }
}
