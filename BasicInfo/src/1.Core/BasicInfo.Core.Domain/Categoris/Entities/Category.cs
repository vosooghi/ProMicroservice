using BasicInfo.Core.Domain.Categoris.Events;
using BasicInfo.Core.Domain.Keywords.ValueObjects;
using Ground.Core.Domain.Entities;

namespace BasicInfo.Core.Domain.Categoris.Entities
{
    public class Category : AggregateRoot
    {
        public Category(TinyString name, TinyString title)
        {
            Title = title;
            Name = name;
            AddEvent(new CategoryCreated(BusinessId.Value, title.Value, name.Value));
        }

        public TinyString Title { get; private set; }
        public TinyString Name { get; private set; }
    }
}
