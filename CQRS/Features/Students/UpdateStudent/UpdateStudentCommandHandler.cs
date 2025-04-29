using CQRS.Models;
using MediatR;

namespace CQRS.Features.Students
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Student>
    {
        private readonly StudentDbContext _context;

        public UpdateStudentCommandHandler(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<Student> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            Student student = new Student()
            {
                Id = request.Id,
                Age = request.Age,
                Name = request.Name,
            };

            _context.Students.Update(student);

            await _context.SaveChangesAsync();

            return student;
        }
    }
}
