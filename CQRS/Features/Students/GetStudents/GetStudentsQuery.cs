using CQRS.Models;
using MediatR;

namespace CQRS.Features.Students
{
    public record GetStudentsQuery : IRequest<List<Student>>;
}
