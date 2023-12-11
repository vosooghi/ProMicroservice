using EntitySamples.IdGenerators.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitySamples.IdGenerators.StaticClass
{
    public class StaticIdGenerator : IIdGenerator

    {
        private long _id=0;
        public long Next()
        {
            return ++_id;
        }
    }
}
