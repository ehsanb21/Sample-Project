using AutoMapper;
using EP.Application.Interface.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Application.Cites.Queres
{
    public class GetCitesRequestQuery : IRequest<List<CitesDto>>
    {
        public int Id { get; set; }
    }
    public class GetStateQuery : IRequestHandler<GetCitesRequestQuery, List<CitesDto>>
    {
        private readonly IDataBaseContext _context;

        private readonly IMapper _mapper;
        public GetStateQuery(IDataBaseContext dataBaseContext, IMapper mapper)
        {
            _context = dataBaseContext;
            _mapper = mapper;
        }

        public async Task<List<CitesDto>> Handle(GetCitesRequestQuery request, CancellationToken cancellationToken)
        {
            var Cites = _context.cites.Where( c=>c.IranStateId == request.Id).ToList();
            return await Task.FromResult(_mapper.Map<List<CitesDto>>(Cites));
        }
    }
}
