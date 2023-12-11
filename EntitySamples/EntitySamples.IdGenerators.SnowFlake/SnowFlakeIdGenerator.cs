using EntitySamples.IdGenerators.Contract;
using Microsoft.Extensions.Configuration;
using Snowflake.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitySamples.IdGenerators.SnowFlake
{
    public class SnowFlakeIdGenerator : IIdGenerator
    {
        public readonly IdWorker _idWorker;
        public SnowFlakeIdGenerator(IConfiguration configuration)
        {
            int datacenterId = int.Parse(configuration["datacenterId"]);
            _idWorker = new IdWorker(datacenterId,1);
            long id = _idWorker.NextId();
        }
        public long Next()
        {
          return _idWorker.NextId();
        }
    }
}
