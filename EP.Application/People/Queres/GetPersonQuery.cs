using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EP.Application.Interface.Contexts;
using MediatR;
using AutoMapper;
namespace EP.Application.People.Queres
{
    public class GetPersonRequestQuery:IRequest<GetPersonDto>
    {
        public int PersonId { get; set; }
    }
    public class GetPersonQuery : IRequestHandler<GetPersonRequestQuery, GetPersonDto>
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public GetPersonQuery(IDataBaseContext dataBaseContext, IMapper  mapper)
        {
            _context = dataBaseContext;
            _mapper = mapper;
        }

        public  async Task<GetPersonDto> Handle(GetPersonRequestQuery request, CancellationToken cancellationToken)
        {
            var person = _context.People.Find(request.PersonId);                       
            return await Task.FromResult(_mapper.Map<GetPersonDto>(person));            
        }
    }


    
}
