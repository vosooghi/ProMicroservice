using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NewsCMS.Infra.Data.Sql.Commands.Common
{
    public class NewsCMSCommandDbContextFactory : IDesignTimeDbContextFactory<NewsCMSCommandDbContext>
    {
        public NewsCMSCommandDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<NewsCMSCommandDbContext>();

            builder.UseSqlServer("Server =.; Database=NewsCMSDb;User Id = sa;Password = P@ssw0rd; MultipleActiveResultSets = true; Encrypt = false");

            return new NewsCMSCommandDbContext(builder.Options);
        }
    }
}
