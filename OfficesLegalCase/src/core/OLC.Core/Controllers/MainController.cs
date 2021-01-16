using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace OLC.Core.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ICollection<string> Errors = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperation())
            {
                return Ok(result ?? true);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Mensagens", Errors.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                AddError(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected bool ValidOperation()
        {
            return !Errors.Any();
        }

        protected void AddError(string erro)
        {
            Errors.Add(erro);
        }

        protected void CleanErrors()
        {
            Errors.Clear();
        }
    }
}
