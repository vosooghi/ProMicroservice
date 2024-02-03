using BasicInfo.Core.Contracts.Keywords.Commands.ActiveKeywords;
using BasicInfo.Core.Contracts.Keywords.Commands.ChangeTitles;
using BasicInfo.Core.Contracts.Keywords.Commands.CreateKeywords;
using BasicInfo.Core.Contracts.Keywords.Dal;
using BasicInfo.Core.Domain.Keywords.Entities;
using Ground.Core.ApplicationServices.Commands;
using Ground.Core.RequestResponse.Commands;
using Ground.Utilities;

namespace BasicInfo.Core.ApplicationServices.Keywords.Commands.CreateKeywords
{
    public class ActiveKeywordCommandHandler : CommandHandler<ActiveKeyword>
    {
        private readonly IKeywordCommandRepository _repository;

        public ActiveKeywordCommandHandler(GroundServices groundServices,IKeywordCommandRepository repository) : base(groundServices)
        {
            _repository = repository;
        }

        public override async Task<CommandResult> Handle(ActiveKeyword command)
        {
            Keyword keyword = await _repository.GetGraphAsync(command.Id);
            if (keyword == null)
            {
                AddMessage("Object Not Found", nameof(keyword));
                return Result(Ground.Core.RequestResponse.Common.ApplicationServiceStatus.NotFound);
            }
            keyword.Active();
            await _repository.CommitAsync();
            return Ok();
        }
    }
}
