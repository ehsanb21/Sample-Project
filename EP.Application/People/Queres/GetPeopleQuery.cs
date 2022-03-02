using EP.Application.Interface.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace EP.Application.People.Queres
{
    public class GetPeopleRequestQuery : IRequest<List<GetPersonDto>>
    {
        public int PageNumber { get; set; }
        public int CountRow { get; set; }
    }
    public class GetPeopleQuery : IRequestHandler<GetPeopleRequestQuery, List<GetPersonDto>>
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public GetPeopleQuery(IDataBaseContext dataBaseContext, IMapper mapper)
        {
            _context = dataBaseContext;
            _mapper = mapper;
        }

        public async Task<List<GetPersonDto>> Handle(GetPeopleRequestQuery request, CancellationToken cancellationToken)
        {
            var people = _context.People.ToList();
            return await Task.FromResult(_mapper.Map<List<GetPersonDto>>(_context.People.Include(c=>c.IranCity).Include(c=>c.IranState)));
        }
    }
}
