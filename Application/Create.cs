using Domain;
using MediatR;
using Persistence;
using static Application.Create; //nie widzi <Command>, why?

namespace Application
{
    public class Create
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }
    }

    public class Handler : IRequestHandler<Command>
    {
        private readonly DataContext _context;
        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken) //Unit nic nie zawiera, mowi API ze request sie skonczyl
        {
            _context.Activities.Add(request.Activity);
            await _context.SaveChangesAsync();
            return Unit.Value; //Unit Value nic nie zwraca
        }
    }
}