using RepositorySamples.Framework;

namespace RepositorySamples.Domain.Categories.Events
{
    public class CategoryCreated : IDomainEvent
    {
        public string Title { get; }
        public CategoryCreated(string title)
        {
            Title = title;
        }
    }
}
