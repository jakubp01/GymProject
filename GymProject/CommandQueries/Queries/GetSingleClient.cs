using GymProject.Areas.Identity.Data;
using GymProject.Controllers.Core;
using GymProject.Models;
using MediatR;

namespace GymProject.CommandQueries.Queries
{
    public class GetSingleClient
    {
        public class Query : IRequest<Result<Client>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Client>>
        {
            private readonly AppDbContext _context;
            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Result<Client>> Handle(Query request, CancellationToken cancellationToken)
            {
                var response = _context.Clients.FirstOrDefault(x => x.Id == request.Id);


                if (response != null)
                {

                    return Result<Client>.Success(response);

                }
                return Result<Client>.Failure("error");

            }
        }
    }
}
