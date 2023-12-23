using EventSourcingSample.Domain.Prdocuts.Entities;
using EventSourcingSample.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingSample.Domain.Prdocuts
{
    public interface IProductRepository:IRepository<Product>
    {

    }
}
