using CQRS.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Features.Students
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, List<Student>?>
    {
        private readonly StudentDbContext _context;

        public GetStudentsQueryHandler(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>?> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Students.ToListAsync();
        }
    }
}
