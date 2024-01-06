using FluentValidation;
using Ground.Samples.Core.Contracts.People.Commands;
using Ground.Samples.Core.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.Translations.Abstractions;

namespace Ground.Samples.Core.ApplicationServices.People.Commands.CreatePersonHandlers
{
    public class CreatePersonValidator:AbstractValidator<CreatePerson>
    {
        private readonly ITranslator _translator;

        public CreatePersonValidator(ITranslator translator)
        {
            RuleFor(w => w.FirstName).NotEmpty().WithMessage(translator[Messages.InvalidNullValue, Messages.FirstName]);
            
        }
    }
}
