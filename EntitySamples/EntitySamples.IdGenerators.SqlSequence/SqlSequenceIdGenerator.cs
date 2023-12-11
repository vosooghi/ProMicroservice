using EntitySamples.IdGenerators.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace EntitySamples.IdGenerators.SqlSequence
{
    
    public class SqlSequenceIdGenerator : IIdGenerator
    {
        private readonly IIdGenerator _idGenerator;
        private readonly IDbConnection _connection;
        public SqlSequenceIdGenerator()
        {
            _connection = new SqlConnection("Server=.;initial catalog=EntitySampleDb;user=sa;password=P@ssw0rd;encrypt=false");            

        }
        public long Next()
        {
            
            using (_connection)
            {
                var result = _connection.ExecuteScalar<long>("select next value for MyIdSequence");
                return result;
            }            
            
        }
    }
}
