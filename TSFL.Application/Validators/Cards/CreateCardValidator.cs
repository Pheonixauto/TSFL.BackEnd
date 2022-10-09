using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSFL.Application.ViewModels.CardModel;

namespace TSFL.Application.Validators.Cards
{
    public class CreateCardValidator : AbstractValidator<VM_Create_Card>
    {
        public CreateCardValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                     .WithMessage("Fiel Name must not empty")
                .MinimumLength(1)
                .MaximumLength(10)
                    .WithMessage("Name must be between 1 and 10 character");
        }
    }
}
