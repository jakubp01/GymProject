using GymProject.Areas.Identity.Data;
using GymProject.Controllers.Core;
using GymProject.Models;
using MediatR;

namespace GymProject.CommandQueries.Commands
{
    public class CreateUserCommand
    {
        public class Command : IRequest<Result<Client>>
        {
            public Client client;

        }

        public class Handler : IRequestHandler<Command, Result<Client>>
        {
            private readonly AppDbContext _context;
            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Result<Client>> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Clients.Add(request.client);
                int rowsAffected = await _context.SaveChangesAsync();


                if (rowsAffected > 0)
                {
                    return Result<Client>.Success(request.client);
                }
                else
                {
                    return Result<Client>.Failure("No rows were affected in the database.");
                }

            }
        }
    }
}
