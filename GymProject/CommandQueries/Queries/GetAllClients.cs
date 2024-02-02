using GymProject.Areas.Identity.Data;
using GymProject.Controllers.Core;
using GymProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GymProject.CommandQueries.Queries
{
    public class GetAllClients
    {
        public class Query : IRequest<Result<List<Client>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<Client>>>
        {
            private readonly AppDbContext _context;
            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Client>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var response = await _context.Clients.ToListAsync();
                if (response != null)
                {

                    return Result<List<Client>>.Success(response);

                }
                return Result<List<Client>>.Failure("error");

            }
        }
    }
}
