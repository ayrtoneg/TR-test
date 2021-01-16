using Microsoft.AspNetCore.Mvc;
using OLC.Cases.Api.Application.Commands;
using OLC.Cases.Api.Models;
using OLC.Cases.Api.ViewModels;
using OLC.Core.Controllers;
using OLC.Core.Mediator;
using System.Threading.Tasks;

namespace OLC.Cases.Api.Controllers
{
    public class CaseController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ICaseRepository _caseRepository;

        public CaseController(IMediatorHandler mediatorHandler, ICaseRepository caseRepository)
        {
            _mediatorHandler = mediatorHandler;
            _caseRepository = caseRepository;
        }

        [HttpGet("case")]
        public async Task<IActionResult> Get()
        {
            return CustomResponse(await _caseRepository.GetAll());
        }

        [HttpGet("case/{caseNumber}")]
        public async Task<IActionResult> Get(string caseNumber)
        {
            return CustomResponse(await _caseRepository.GetByCaseNumber(caseNumber));
        }

        [HttpPost("case")]
        public async Task<IActionResult> Post([FromBody] CaseViewModel viewModel)
        {
            return CustomResponse(await _mediatorHandler.SendCommand(
                new NewCaseCommand(viewModel.CaseNumber, viewModel.CourtName, viewModel.NameOfTheResponsible)));
        }

        [HttpPut("case")]
        public async Task<IActionResult> Put([FromBody] CaseViewModel viewModel)
        {
            return CustomResponse(await _mediatorHandler.SendCommand(
                new UpdateCaseCommand(viewModel.CaseNumber, viewModel.CourtName, viewModel.NameOfTheResponsible)));
        }

        [HttpDelete("case/{caseNumber}")]
        public async Task<IActionResult> Delete(string caseNumber)
        {
            return CustomResponse(await _mediatorHandler.SendCommand(
                new RemoveCaseCommand(caseNumber)));
        }
    }
}
