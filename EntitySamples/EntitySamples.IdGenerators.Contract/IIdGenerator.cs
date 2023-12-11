using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitySamples.IdGenerators.Contract
{
    public  interface IIdGenerator
    {
        long Next();
    }
}
