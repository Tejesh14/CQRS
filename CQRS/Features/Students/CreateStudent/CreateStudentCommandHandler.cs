using CQRS.Models;
using MediatR;

namespace CQRS.Features.Students
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly StudentDbContext _context;

        public CreateStudentCommandHandler(StudentDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            Student student = new Student()
            {
                Name = request.Name,
                Age = request.Age,
            };

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student.Id;
        }
    }
}
