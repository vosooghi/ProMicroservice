using BasicInfo.Infra.Data.Sql.Queries.Keywords.Entities;
using Ground.Infra.Data.Sql.Queries;
using Microsoft.EntityFrameworkCore;

namespace BasicInfo.Infra.Data.Sql.Queries.Common
{
    public class BasicInfoQueryDbContext : BaseQueryDbContext
    {
        public DbSet<Keyword> keywords { get; set; }
        public BasicInfoQueryDbContext(DbContextOptions<BasicInfoQueryDbContext> options) : base(options)
        {
        }
    }
}
