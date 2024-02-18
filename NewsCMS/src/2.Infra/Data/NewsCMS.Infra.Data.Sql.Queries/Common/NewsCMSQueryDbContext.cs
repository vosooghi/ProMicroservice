using Ground.Infra.Data.Sql.Queries;
using Microsoft.EntityFrameworkCore;

namespace NewsCMS.Infra.Data.Sql.Queries.Common
{
    public class NewsCMSQueryDbContext : BaseQueryDbContext
    {
        public DbSet<NewsCMS.Infra.Data.Sql.Queries.News.Entities.News> News { get; set; }
        public NewsCMSQueryDbContext(DbContextOptions<NewsCMSQueryDbContext> options) : base(options)
        {
        }
    }
}
