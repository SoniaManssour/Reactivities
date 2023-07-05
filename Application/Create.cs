using Domain;
using FluentValidation;
using MediatR;
using Persistence;
using static Application.Create; //nie widzi <Command>, why?
using Application.Activities;
using Application.Core;

namespace Application
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Activity Activity { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Activity).SetValidator(new ActivityValidator());
            }
        }
   

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _context;
        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken) //Unit nic nie zawiera, mowi API ze request sie skonczyl
        {
            _context.Activities.Add(request.Activity);
            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return Result<Unit>.Failure("Failed to create activity");
            return Result<Unit>.Success(Unit.Value);
        }
    }
     }
}