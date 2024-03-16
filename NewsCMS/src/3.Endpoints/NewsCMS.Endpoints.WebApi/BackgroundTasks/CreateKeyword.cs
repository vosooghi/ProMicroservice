using Ground.Core.RequestResponse.Commands;

namespace NewsCMS.Endpoints.WebApi.BackgroundTasks
{
    public class CreateKeyword : ICommand<long>
    {
        public string Title { get; set; }
        public Guid BusinessId { get; set; }

    }
}
