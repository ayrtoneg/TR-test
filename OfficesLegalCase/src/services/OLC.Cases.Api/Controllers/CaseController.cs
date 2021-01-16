using Microsoft.AspNetCore.Mvc;
using OLC.Core.Controllers;
using System.Threading.Tasks;

namespace OLC.Cases.Api.Controllers
{
    public class CaseController : MainController
    {

        [HttpGet("case")]
        public async Task<IActionResult> Index()
        {
            return CustomResponse();
        }
    }
}
