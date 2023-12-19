using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySamples.Framework
{
    public class OutBoxEventItem
    {
        public  long OutBoxEventItemID { get; set; }
        public Guid EventId { get; set; }
        public string AccuredByUserID { get; set; }
        public DateTime AccuredOn { get; set; }
        public string AggregateName { get; set; }
        public string AggregateTypeName { get; set; }
        public string AggregateId { get; set; }
        public string EventName {  get; set; }
        public string EventTypeName { get; set; }
        public string EventPayLoad {  get; set; }
        public bool IsProcessed { get; set; }
    }
}
