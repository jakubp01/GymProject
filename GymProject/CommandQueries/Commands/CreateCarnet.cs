using GymProject.Areas.Identity.Data;
using GymProject.Controllers.Core;
using GymProject.Models;
using MediatR;

namespace GymProject.CommandQueries.Commands
{
    public class CreateCarnet
    {
        public class Command : IRequest<Result<Carnet>>
        {
            public Carnet carnet;

        }

        public class Handler : IRequestHandler<Command, Result<Carnet>>
        {
            private readonly AppDbContext _context;
            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Result<Carnet>> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Carnets.Add(request.carnet);
                int rowsAffected = await _context.SaveChangesAsync();


                if (rowsAffected > 0)
                {
                    return Result<Carnet>.Success(request.carnet);
                }
                else
                {
                    return Result<Carnet>.Failure("No rows were affected in the database.");
                }

            }
        }
    }
}
