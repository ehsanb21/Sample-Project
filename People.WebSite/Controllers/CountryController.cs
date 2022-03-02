
using EP.Application.States.Queres;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using EP.Application.Cites.Queres;

namespace People.WebSite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-states")]
        public async Task<IActionResult> GetPeople()
        {
            GetStateRequestQuery getStatesRequest = new GetStateRequestQuery();
            var getPersonResult = await _mediator.Send(getStatesRequest);
            return Ok(getPersonResult);
        }

        [HttpGet("get-cites/{id}")]
        public async Task<IActionResult> GetCites(int id)
        {
            GetCitesRequestQuery getCitesRequest = new GetCitesRequestQuery() { Id = id };
            var getPersonResult = await _mediator.Send(getCitesRequest);
            return Ok(getPersonResult);
        }

    }
}
