using Ground.Core.RequestResponse.Commands;

namespace BasicInfo.Core.Contracts.Keywords.Commands.ActiveKeywords
{
    public class ActiveKeyword:ICommand
    {
        public long Id { get; set; }        
    }
}
