using FluentValidation.Results;
using MediatR;
using OLC.Cases.Api.Models;
using OLC.Core.Messages;
using System.Threading;
using System.Threading.Tasks;

namespace OLC.Cases.Api.Application.Commands
{
    public class CaseCommandHandler : CommandHandler,
        IRequestHandler<NewCaseCommand, ValidationResult>,
        IRequestHandler<UpdateCaseCommand, ValidationResult>,
        IRequestHandler<RemoveCaseCommand, ValidationResult>
    {

        private readonly ICaseRepository _caseRepository;
        public CaseCommandHandler(ICaseRepository caseRepository)
        {
            _caseRepository = caseRepository;
        }

        public async Task<ValidationResult> Handle(NewCaseCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var model = new Case(request.CaseNumber, request.CourtName, request.NameOfTheResponsible);

            var verifiedCase = await _caseRepository.GetByCaseNumber(model.CaseNumber);

            if (verifiedCase != null)
            {
                AddError("The Case Number already exists");
                return ValidationResult;
            }

            await _caseRepository.Add(model);

            return await SaveChanges(_caseRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateCaseCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var model = new Case(request.CaseNumber, request.CourtName, request.NameOfTheResponsible);

            var verifiedCase = await _caseRepository.GetByCaseNumber(model.CaseNumber);

            if (verifiedCase == null)
            {
                AddError("Case not found");
                return ValidationResult;
            }

            _caseRepository.Update(model);

            return await SaveChanges(_caseRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveCaseCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var verifiedCase = await _caseRepository.GetByCaseNumber(request.CaseNumber);

            if (verifiedCase == null)
            {
                AddError("Case not found");
                return ValidationResult;
            }

            await _caseRepository.Remove(request.CaseNumber);

            return await SaveChanges(_caseRepository.UnitOfWork);
        }
    }
}
