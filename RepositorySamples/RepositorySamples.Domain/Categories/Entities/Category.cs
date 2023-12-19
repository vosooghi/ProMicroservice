using RepositorySamples.Domain.Categories.Events;
using RepositorySamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySamples.Domain.Categories.Entities
{
    public class Category : AggregateRoot
    {
        public string Title { get; private set; }
        public Category(string title)
        {
            Title = title;
            AddEvent(new CategoryCreated(title));
        }

        public void SetTitle(string title)
        {
            Title = title;
            AddEvent(new CategoryNameChanged(Id,title));
        }
    }
}
