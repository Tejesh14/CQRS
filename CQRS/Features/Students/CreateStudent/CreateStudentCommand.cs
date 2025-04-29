using MediatR;

namespace CQRS.Features.Students
{
    public record CreateStudentCommand(string Name, int Age) : IRequest<int>;
}
