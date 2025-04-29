using CQRS.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Features.Students
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Student?>
    {
        private readonly StudentDbContext _context;

        public GetStudentByIdQueryHandler(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<Student?> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Students.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
        }
    }
}
