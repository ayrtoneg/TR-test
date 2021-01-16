using FluentValidation.Results;
using OLC.Core.Messages;
using System.Threading.Tasks;

namespace OLC.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task<ValidationResult> SendCommand<T>(T comando) where T : Command;
    }
}
