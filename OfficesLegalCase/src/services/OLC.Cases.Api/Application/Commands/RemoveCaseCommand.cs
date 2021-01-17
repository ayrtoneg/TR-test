using FluentValidation;
using OLC.Cases.Api.Util;
using OLC.Core.Messages;
using System;

namespace OLC.Cases.Api.Application.Commands
{
    public class RemoveCaseCommand : Command
    {
        public string CaseNumber { get; private set; }

        public RemoveCaseCommand(string caseNumber)
        {
            AggregateId = Guid.NewGuid();
            CaseNumber = caseNumber;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveCaseValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class RemoveCaseValidation : AbstractValidator<RemoveCaseCommand>
    {
        public RemoveCaseValidation()
        {
            RuleFor(c => c.CaseNumber)
                .NotEmpty()
                .NotNull()
                .WithMessage("Case Number is required");

            RuleFor(c => c.CaseNumber)
                .Must(ValidCaseNumber)
                .WithMessage("Invalid Case Number. Use the following format: NNNNNNNNN.NNNN.N.NN.NNNN where N can be any positive integer");


            RuleFor(c => c.CaseNumber)
                .Length(24)
                .WithMessage("Case number must have 24 characters");
        }

        protected static bool ValidCaseNumber(string caseNumber)
        {
            return caseNumber.IsValidCaseNumber();
        }
    }
}
