using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ground.Core.Contracts.ApplicationServices.Common
{
    /// <summary>
    /// A super type.
    /// any data that is going to be passed to out of Application service, must be an instance of ApplicationServiceResult.
    /// </summary>
    public class ApplicationServiceResult : IApplicationServiceResult
    {
        protected readonly List<string> _messages = new();
        public IEnumerable<string> Messages => _messages;


        public ApplicationServiceStatus Status { get; set; }
        public void AddMessage(string error)=>_messages.Add(error);
        public void AddMessages(IEnumerable<string> errors)=>_messages.AddRange(errors);  
        public void ClearMessages()=>_messages.Clear(); 
    }
}
