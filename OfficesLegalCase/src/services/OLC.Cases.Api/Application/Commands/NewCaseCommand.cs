﻿using FluentValidation;
using OLC.Cases.Api.Util;
using OLC.Core.Messages;
using System;

namespace OLC.Cases.Api.Application.Commands
{
    public class NewCaseCommand : Command
    {
        public string CaseNumber { get; private set; }
        public string CourtName { get; private set; }
        public string NameOfTheResponsible { get; private set; }

        public NewCaseCommand(string caseNumber, string courtName, string nameOfTheResponsible)
        {
            AggregateId = Guid.NewGuid();
            CaseNumber = caseNumber;
            CourtName = courtName;
            NameOfTheResponsible = nameOfTheResponsible;
        }

        public override bool IsValid()
        {
            ValidationResult = new NewCaseValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }

    public class NewCaseValidation : AbstractValidator<NewCaseCommand>
    {
        public NewCaseValidation()
        {
            RuleFor(c => c.CaseNumber)
                .NotEmpty()
                .WithMessage("Case Number is required")
                .Must(ValidCaseNumber)
                .WithMessage("Invalid Case Number. Use the following format: NNNNNNNNN.NNNN.N.NN.NNNN where N can be any positive integer");


            RuleFor(c => c.CourtName)
                .NotEmpty()
                .WithMessage("Court Name is required");

            RuleFor(c => c.NameOfTheResponsible)
                .NotEmpty()
                .WithMessage("Name of the responsible is required");
        }

        protected static bool ValidCaseNumber(string caseNumber)
        {
            return caseNumber.IsValidCaseNumber();
        }
    }
}