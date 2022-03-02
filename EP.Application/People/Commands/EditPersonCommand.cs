using AutoMapper;
using EP.Application.Interface.Contexts;
using EP.Domain.Person;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Application.People.Commands
{

    public class EditPersonCommand : IRequest<BaseResult>
    {
        public GetPersonDto PersonDto { get; set; }
        public EditPersonCommand(GetPersonDto personDto)
        {
            PersonDto = personDto;
        }
    }

    public class EditPrsonHandler : IRequestHandler<EditPersonCommand, BaseResult>
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public EditPrsonHandler(IDataBaseContext dataBaseContext, IMapper mapper)
        {
            _context = dataBaseContext;
            _mapper = mapper;
        }

        public async Task<BaseResult> Handle(EditPersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var person = _context.People.SingleOrDefault(x => x.Id == request.PersonDto.Id);
                _mapper.Map(request.PersonDto, person);
                _context.SaveChanges();
                return await Task.FromResult(new BaseResult { StatusCode = 200, Message = "Editing Completed Successfully " }); ;
            }
            catch
            {
                return await Task.FromResult(new BaseResult { StatusCode = 500, Message = "Error ... " });
            }
        }
    }
}
