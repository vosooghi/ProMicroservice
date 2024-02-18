using Ground.Core.ApplicationServices.Commands;
using Ground.Core.Domain.ValueObjects;
using Ground.Core.RequestResponse.Commands;
using Ground.Utilities;
using NewsCMS.Core.Contracts.News.Commands.CreateNews;
using NewsCMS.Core.Contracts.News.DAL;
using NewsCMS.Core.Domain.News.Entities;

namespace NewsCMS.Core.ApplicationServices.News.Commands.CreateNews
{
    public class CreateNewsCommandHandler : CommandHandler<CreateNewsCommand, long>
    {
        private readonly INewsCommandRepository _repository;

        public CreateNewsCommandHandler(GroundServices groundServices,INewsCommandRepository repository) : base(groundServices)
        {
            _repository = repository;
        }

        public override async Task<CommandResult<long>> Handle(CreateNewsCommand command)
        {
            Domain.News.Entities.News news = new Domain.News.Entities.News(command.Title, command.Description, command.Body,
                command.KeywordsId.Select(w=> new NewsKeywords
                {
                      KeywordBusinessId=BusinessId.FromGuid(w)
                }).ToList());
            await _repository.InsertAsync(news);
            await _repository.CommitAsync();
            return Ok(news.Id);
        }
    }
}
