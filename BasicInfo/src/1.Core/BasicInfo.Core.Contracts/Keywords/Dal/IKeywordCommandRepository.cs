using BasicInfo.Core.Domain.Keywords.Entities;
using Ground.Core.Contracts.Data.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInfo.Core.Contracts.Keywords.Dal
{
    public interface IKeywordCommandRepository:ICommandRepository<Keyword,long>
    {

    }
}
