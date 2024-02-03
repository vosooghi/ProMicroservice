using BasicInfo.Core.Contracts.Keywords.Commands.CreateKeywords;
using BasicInfo.Core.Contracts.Keywords.Dal;
using BasicInfo.Core.Domain.Keywords.Entities;
using Ground.Core.ApplicationServices.Commands;
using Ground.Core.RequestResponse.Commands;
using Ground.Utilities;

namespace BasicInfo.Core.ApplicationServices.Keywords.Commands.CreateKeywords
{
    public class CreateKeywordCommandHandler : CommandHandler<CreateKeyword,long>
    {
        private readonly IKeywordCommandRepository _repository;

        public CreateKeywordCommandHandler(GroundServices groundServices,IKeywordCommandRepository repository) : base(groundServices)
        {
            _repository = repository;
        }

        public override async Task<CommandResult<long>> Handle(CreateKeyword command)
        {
            Keyword keyword = new (command.Title);
            await _repository.InsertAsync(keyword);
            await _repository.CommitAsync();
            return Ok(keyword.Id);
        }
    }
}
