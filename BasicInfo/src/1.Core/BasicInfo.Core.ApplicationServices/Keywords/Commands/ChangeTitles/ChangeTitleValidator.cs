﻿using BasicInfo.Core.Contracts.Keywords.Commands.ChangeTitles;
using FluentValidation;
using Ground.Extensions.Translations.Abstractions;

namespace BasicInfo.Core.ApplicationServices.Keywords.Commands.CreateKeywords
{
    public class ChangeTitleValidator : AbstractValidator<ChangeTitle>
    {
        public ChangeTitleValidator(ITranslator translator)
        {
            RuleFor(c => c.Title)
             .NotNull().WithMessage(translator["Required", "Title"])
             .MinimumLength(5).WithMessage(translator["MinimumLength", "Title", "5"])
             .MaximumLength(50).WithMessage(translator["MaximumLength", "Title", "50"]);
        }
    }
}
