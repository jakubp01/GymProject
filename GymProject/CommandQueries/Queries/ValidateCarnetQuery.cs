using GymProject.Areas.Identity.Data;
using GymProject.Controllers.Core;
using GymProject.Models;
using MediatR;

namespace GymProject.CommandQueries.Queries
{
    public class ValidateCarnetQuery
    {
        public class Query : IRequest<Result<Carnet>>
        {
            public Carnet carnet;

        }

        public class Handler : IRequestHandler<Query, Result<Carnet>>
        {
            private readonly AppDbContext _context;
            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Result<Carnet>> Handle(Query request, CancellationToken cancellationToken)
            {
                var carnet = _context.Carnets.Where(x => x.DueDate > DateTime.Now)
                    .FirstOrDefault(x => x.Id == request.carnet.Id);
                    
                if (carnet != null)
                {
                    return Result<Carnet>.Success(carnet);
                }
                else
                {
                    return Result<Carnet>.Failure("No rows were affected in the database.");
                }

            }
        }
    }
}
