using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BasicInfo.Infra.Data.Sql.Commands.Common
{
    public class BasicInfoCommandDbContextFactory : IDesignTimeDbContextFactory<BasicInfoCommandDbContext>
    {
        public BasicInfoCommandDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BasicInfoCommandDbContext>();

            builder.UseSqlServer("Server =.; Database=BasicInfoDb;User Id = sa;Password = P@ssw0rd; MultipleActiveResultSets = true; Encrypt = false");

            return new BasicInfoCommandDbContext(builder.Options);
        }
    }
}
