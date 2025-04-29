using CQRS.Features.Students;
using CQRS.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ISender _sender;
        public StudentController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            List<Student>? students = await _sender.Send(new GetStudentsQuery());

            if (students == null)
                return NotFound();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            Student? student = await _sender.Send(new GetStudentByIdQuery(id));

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateStudentCommand createStudentCommand)
        {
            return Ok(await _sender.Send(createStudentCommand));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> Put(int id, [FromBody] UpdateStudentCommand updateStudentCommand)
        {
            Student? student = await _sender.Send(new GetStudentByIdQuery(id));

            if (student == null)
                return NotFound();

            return Ok(await _sender.Send(updateStudentCommand));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Student? student = await _sender.Send(new GetStudentByIdQuery(id));

            if (student == null)
                return NotFound();

            return Ok(await _sender.Send(new DeleteStudentCommand(student.Id, student.Name, student.Age)));
        }
    }
}
