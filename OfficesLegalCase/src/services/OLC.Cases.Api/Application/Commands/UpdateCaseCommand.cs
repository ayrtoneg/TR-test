using FluentValidation;
using OLC.Cases.Api.Util;
using OLC.Core.Messages;
using System;

namespace OLC.Cases.Api.Application.Commands
{
    public class UpdateCaseCommand : Command
    {
        public string CaseNumber { get; private set; }
        public string CourtName { get; private set; }
        public string NameOfTheResponsible { get; private set; }

        public UpdateCaseCommand(string caseNumber, string courtName, string nameOfTheResponsible)
        {
            AggregateId = Guid.NewGuid();
            CaseNumber = caseNumber;
            CourtName = courtName;
            NameOfTheResponsible = nameOfTheResponsible;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCaseValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class UpdateCaseValidation : AbstractValidator<UpdateCaseCommand>
    {
        public UpdateCaseValidation()
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


            RuleFor(c => c.CourtName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Court Name is required");

            RuleFor(c => c.CourtName)
                .MaximumLength(100)
                .WithMessage("Maximum characters allowed for Court Name is 100");

            RuleFor(c => c.NameOfTheResponsible)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name of the responsible is required");

            RuleFor(c => c.NameOfTheResponsible)
                .MaximumLength(100)
                .WithMessage("Maximum characters allowed for Name Of The Responsible is 100");
        }

        protected static bool ValidCaseNumber(string caseNumber)
        {
            return caseNumber.IsValidCaseNumber();
        }
    }
}
