using BasicInfo.Core.Contracts.Keywords.Commands.ChangeTitles;
using BasicInfo.Core.Contracts.Keywords.Commands.CreateKeywords;
using BasicInfo.Core.Contracts.Keywords.Dal;
using BasicInfo.Core.Domain.Keywords.Entities;
using Ground.Core.ApplicationServices.Commands;
using Ground.Core.RequestResponse.Commands;
using Ground.Utilities;

namespace BasicInfo.Core.ApplicationServices.Keywords.Commands.CreateKeywords
{
    public class ChangeTitleCommandHandler : CommandHandler<ChangeTitle>
    {
        private readonly IKeywordCommandRepository _repository;

        public ChangeTitleCommandHandler(GroundServices groundServices,IKeywordCommandRepository repository) : base(groundServices)
        {
            _repository = repository;
        }

        public override async Task<CommandResult> Handle(ChangeTitle command)
        {
            Keyword keyword =await _repository.GetGraphAsync(command.Id);
            if(keyword==null)
            {
                AddMessage("Object Not Found", nameof(keyword));
                return Result(Ground.Core.RequestResponse.Common.ApplicationServiceStatus.NotFound);
            }
            keyword.ChangeTitle(command.Title);            
            await _repository.CommitAsync();
            return Ok();
        }
    }
}
