using Ground.Core.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInfo.Core.Domain.Keywords.Events
{
    public class KeywordTitleChanged:IDomainEvent
    {
        public Guid BusinessId { get; set; }
        public string Title { get; set; }
        public KeywordTitleChanged(Guid businessId, string title)
        {
            //We don't need to store Status
            BusinessId = businessId;
            Title = title;
        }
    }
}
