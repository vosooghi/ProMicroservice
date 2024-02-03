using Ground.Core.RequestResponse.Commands;

namespace BasicInfo.Core.Contracts.Keywords.Commands.ChangeTitles
{
    public class ChangeTitle:ICommand
    {
        public  long Id { get; set; }
        public  string Title { get; set; }
    }
}
