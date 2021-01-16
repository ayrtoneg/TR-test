using FluentValidation.Results;
using OLC.Core.Data;
using System.Threading.Tasks;

namespace OLC.Core.Messages
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddError(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected async Task<ValidationResult> SaveChanges(IUnitOfWork uow)
        {
            if (!await uow.Commit()) AddError("There was an error persisting the data");

            return ValidationResult;
        }
    }
}
