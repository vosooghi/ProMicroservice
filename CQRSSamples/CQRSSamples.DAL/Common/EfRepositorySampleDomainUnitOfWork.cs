using CQRSSamples.Domain.Common;
using CQRSSamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSSamples.Command.DAL.Common
{
    public class EfRepositorySampleDomainUnitOfWork : BaseEfUnitOfWork<RepoSampleCommandDbContext>, IRepositorySampleDomainUnitOfWork
    {
        public EfRepositorySampleDomainUnitOfWork(RepoSampleCommandDbContext context) : base(context)
        {
        }

    }
}
