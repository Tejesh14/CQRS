using MediatR;

namespace CQRS.Features.Students
{
    public record DeleteStudentCommand(int Id, string Name, int Age) : IRequest<bool>;
}
