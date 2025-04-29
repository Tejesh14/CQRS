using CQRS.Models;
using MediatR;

namespace CQRS.Features.Students
{
    public record UpdateStudentCommand(int Id, string Name, int Age) : IRequest<Student>;
}
