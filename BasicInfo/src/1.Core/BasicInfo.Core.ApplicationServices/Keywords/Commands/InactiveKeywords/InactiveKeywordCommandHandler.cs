using BasicInfo.Core.Contracts.Keywords.Commands.InactiveKeywords;
using BasicInfo.Core.Contracts.Keywords.Dal;
using BasicInfo.Core.Domain.Keywords.Entities;
using Ground.Core.ApplicationServices.Commands;
using Ground.Core.RequestResponse.Commands;
using Ground.Utilities;

namespace BasicInfo.Core.ApplicationServices.Keywords.Commands.CreateKeywords
{
    public class InactiveKeywordCommandHandler : CommandHandler<InactiveKeyword>
    {
        private readonly IKeywordCommandRepository _repository;

        public InactiveKeywordCommandHandler(GroundServices groundServices,IKeywordCommandRepository repository) : base(groundServices)
        {
            _repository = repository;
        }

        public override async Task<CommandResult> Handle(InactiveKeyword command)
        {
            Keyword keyword = await _repository.GetGraphAsync(command.Id);
            if (keyword == null)
            {
                AddMessage("Object Not Found", nameof(keyword));
                return Result(Ground.Core.RequestResponse.Common.ApplicationServiceStatus.NotFound);
            }
            keyword.Inactive();
            await _repository.CommitAsync();
            return Ok();
        }
    }
}
