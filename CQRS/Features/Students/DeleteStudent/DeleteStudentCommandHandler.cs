using CQRS.Models;
using MediatR;

namespace CQRS.Features.Students
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly StudentDbContext _context;

        public DeleteStudentCommandHandler(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            _context.Students.Remove(new Student()
            {
                Id = request.Id,
                Name = request.Name,
                Age = request.Age,
            });

            int result = await _context.SaveChangesAsync();

            return result > 0 ? true : false;
        }
    }
}
