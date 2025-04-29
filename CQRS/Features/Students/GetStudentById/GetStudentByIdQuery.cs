using CQRS.Models;
using MediatR;

namespace CQRS.Features.Students
{
    public record GetStudentByIdQuery(int Id) : IRequest<Student>;
}
