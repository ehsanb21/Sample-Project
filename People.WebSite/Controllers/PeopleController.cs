using EP.Application.People.Commands;
using Microsoft.AspNetCore.Mvc;
using People.WebSite.Controllers;
using MediatR;
using EP.Application.People.Queres;
using EP.Application.People;
using People.WebSite.Models;
using EP.Application.utility;
using Microsoft.AspNetCore.OData.Query;

namespace People.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("send-person")]
        public async Task<IActionResult> Send(PersonDto personDto)
        {
            SendPersonCommand sendPersonCommand = new SendPersonCommand(personDto);
            var sendedResult = await _mediator.Send(sendPersonCommand);
            return Ok(sendedResult);
        }

        [HttpPut("edit-person")]
        public async Task<IActionResult> Edit(GetPersonDto personDto)
        {
            EditPersonCommand sendPersonCommand = new EditPersonCommand(personDto);
            var sendedResult = await _mediator.Send(sendPersonCommand);
            return Ok(sendedResult);
        }

        [HttpDelete("delete-person/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeletePersonCommand sendPersonCommand = new DeletePersonCommand(id);
            var sendedResult = await _mediator.Send(sendPersonCommand);
            return Ok(sendedResult);
        }

        [HttpGet("get-person")]
        [EnableQuery]
        public async Task<IActionResult> GetPeople()
        {
            GetPeopleRequestQuery getPeopleRequest = new GetPeopleRequestQuery();            
            var getPersonResult = await _mediator.Send(getPeopleRequest);
            return Ok(getPersonResult);
        }

        [HttpGet("get-person/{id}")]
        [EnableQuery]
        public async Task<IActionResult> GetPerson(int id)
        {
            GetPersonRequestQuery getPeopleRequest = new GetPersonRequestQuery { PersonId = id };
            var getPersonResult = await _mediator.Send(getPeopleRequest);
            return Ok(getPersonResult);
        }
    }
}