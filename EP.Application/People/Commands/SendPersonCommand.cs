using EP.Application.Interface.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EP.Domain;
using EP.Domain.Person;

namespace EP.Application.People.Commands
{
    public class SendPersonCommand : IRequest<SendPersonResponseDto>
    {
        public PersonDto PersonDto { get; set; }
        public SendPersonCommand(PersonDto personDto)
        {
            PersonDto = personDto;
        }
    }

    public class SendPersonHandler : IRequestHandler<SendPersonCommand, SendPersonResponseDto>
    {
        private readonly IDataBaseContext _context;
        public SendPersonHandler(IDataBaseContext dataBaseContext)
        {
            _context = dataBaseContext;
        }

        public async Task<SendPersonResponseDto> Handle(SendPersonCommand request, CancellationToken cancellationToken)
        {
            Person person = new Person
            {                               
                FirstName = request.PersonDto.FirstName,
                LastName = request.PersonDto.LastName,
                 IranCityId = request.PersonDto.IranCityId,
                 IranStateId = request.PersonDto.IranStateId,   
            };

            var sendedResult = _context.People.Add(person);
            _context.SaveChanges();
            return await Task.FromResult(new SendPersonResponseDto
            {
                Id = sendedResult.Entity.Id
            });
        }
    }
}
