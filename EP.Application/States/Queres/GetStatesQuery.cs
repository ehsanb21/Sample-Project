
using AutoMapper;
using EP.Application.Interface.Contexts;
using EP.Application.States;
using MediatR;

namespace EP.Application.States.Queres
{
    public class GetStateRequestQuery : IRequest<List<StateDto>>
    {
        
    }
    public class GetStateQuery : IRequestHandler<GetStateRequestQuery, List<StateDto>>
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public GetStateQuery(IDataBaseContext dataBaseContext, IMapper mapper)
        {
            _context = dataBaseContext;
            _mapper = mapper;
        }

        public async Task<List<StateDto>> Handle(GetStateRequestQuery request, CancellationToken cancellationToken)
        {
            var IranStates = _context.IranStates.ToList();
            
            return await Task.FromResult(_mapper.Map<List<StateDto>>(IranStates));
            
        }        
    }
}
