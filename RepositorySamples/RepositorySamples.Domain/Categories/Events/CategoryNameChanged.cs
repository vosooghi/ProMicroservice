using RepositorySamples.Framework;

namespace RepositorySamples.Domain.Categories.Events
{
    public class CategoryNameChanged : IDomainEvent
    {
        public string Title { get; }
        public long Id { get; }
        public CategoryNameChanged(long id,string title)
        {
            Title = title;
            Id = id;
        }
    }
}
