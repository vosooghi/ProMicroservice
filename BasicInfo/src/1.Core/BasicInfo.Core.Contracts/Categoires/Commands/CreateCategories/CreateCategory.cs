using Ground.Core.RequestResponse.Commands;

namespace BasicInfo.Core.Contracts.Categoires.Commands.CreateCategories
{
    public class CreateCategory : ICommand<long>
    {
        public  string Title { get; set; }
        public  string Name { get; set; }

    }
}
