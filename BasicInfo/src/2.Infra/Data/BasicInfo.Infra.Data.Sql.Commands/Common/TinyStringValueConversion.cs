using BasicInfo.Core.Domain.Keywords.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BasicInfo.Infra.Data.Sql.Commands.Common
{
    public class TinyStringValueConversion : ValueConverter<TinyString, string>
    {
        public TinyStringValueConversion() : base(c => c.Value, c => TinyString.FromString(c))
        {

        }
    }
}
