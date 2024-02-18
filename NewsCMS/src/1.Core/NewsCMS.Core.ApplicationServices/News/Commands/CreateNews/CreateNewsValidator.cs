using FluentValidation;
using Ground.Core.Domain.Toolkits.ValueObjects;
using Ground.Extensions.Translations.Abstractions;
using NewsCMS.Core.Contracts.News.Commands.CreateNews;

namespace NewsCMS.Core.ApplicationServices.News.Commands.CreateNews
{
    public class CreateNewsCommandValidator:AbstractValidator<CreateNewsCommand>
    {
        public CreateNewsCommandValidator(ITranslator translator)
        {
            RuleFor(c => c.Title)
                .NotNull().WithMessage(translator["Required", nameof(Title)])
                .MinimumLength(10).WithMessage(translator["MinimumLength", "Title", "10"])
                .MaximumLength(100).WithMessage(translator["MaximumLength", nameof(Title), "100"]);

            RuleFor(c => c.Description)
                .NotNull().WithMessage(translator["Required", nameof(Description)])
                .MinimumLength(50).WithMessage(translator["MinimumLength", nameof(Description), "50"])
                .MaximumLength(500).WithMessage(translator["MaximumLength", nameof(Description), "500"]);
        }
    }
}
