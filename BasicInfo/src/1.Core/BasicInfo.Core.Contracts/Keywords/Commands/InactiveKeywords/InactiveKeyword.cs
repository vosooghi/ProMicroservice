using Ground.Core.RequestResponse.Commands;

namespace BasicInfo.Core.Contracts.Keywords.Commands.InactiveKeywords
{
    public class InactiveKeyword:ICommand
    {
        public long Id { get; set; }
    }
}
