using RepositorySamples.Domain.Common;
using RepositorySamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySamples.DAL.Common
{
    public class EfRepositorySampleDomainUnitOfWork :BaseEfUnitOfWork<RepoSampleDbContext>, IRepositorySampleDomainUnitOfWork
    {
        public EfRepositorySampleDomainUnitOfWork(RepoSampleDbContext context) : base(context)
        {
        }

    }
}
