using AutoMapper;
using EP.Application.Interface.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Application.People.Commands
{
    public class DeletePersonCommand : IRequest<BaseResult>
    {
        public int Id { get; set; }
        public DeletePersonCommand(int id)
        {
            Id = id;
        }
    }

    public class DeletePrsonHandler : IRequestHandler<DeletePersonCommand, BaseResult>
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public DeletePrsonHandler(IDataBaseContext dataBaseContext, IMapper mapper)
        {
            _context = dataBaseContext;
            _mapper = mapper;
        }

        public async Task<BaseResult> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var person =await _context.People.FindAsync(request.Id);
                if (person != null)
                {
                    _context.People.Remove(person);
                    _context.SaveChanges();
                return await Task.FromResult(new BaseResult { StatusCode = 200, Message = "Delete Completed Successfully " }); ;
                }
                return await Task.FromResult(new BaseResult { StatusCode = 404, Message = "Person NotFound  " }); ;
            }
            catch
            {
                return await Task.FromResult(new BaseResult { StatusCode = 500, Message = "Error ... " });
            }
        }
    }
}
