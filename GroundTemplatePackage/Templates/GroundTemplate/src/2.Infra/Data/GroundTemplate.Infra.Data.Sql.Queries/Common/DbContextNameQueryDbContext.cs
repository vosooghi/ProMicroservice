using Ground.Infra.Data.Sql.Queries;
using Microsoft.EntityFrameworkCore;

namespace GroundTemplate.Infra.Data.Sql.Queries.Common
{
    public class DbContextNameQueryDbContext : BaseQueryDbContext
    {
        public DbContextNameQueryDbContext(DbContextOptions<DbContextNameQueryDbContext> options) : base(options)
        {
        }
    }
}
