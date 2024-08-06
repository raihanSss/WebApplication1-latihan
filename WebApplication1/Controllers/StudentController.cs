using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using WebApplication1.models;

namespace WebApplication1.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static readonly List<Students> students = new List<Students>();

        [HttpPost]
        public IActionResult Post([FromBody] Students student)
        {
            students.Add(student);

            return Ok("Data berhasil ditambah");
        }

        [HttpGet]
        public async Task <IActionResult> GetStudentAsync()
        {
            await Task.Delay(10000);
            return Ok(students);
        }

        [HttpGet("{StudentId}")]
        public IActionResult GetStudent(int StudentId)
        {
            var student = students.FirstOrDefault(s => s.StudentId == StudentId);
            if (student == null)
            {
                return NotFound("id tidak ditemukan");
            }
            return Ok(student);
        }

        [HttpPut("{StudentId}")]
        public IActionResult Put(int StudentId, [FromBody] Students updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.StudentId == StudentId);
            if (student == null)
            {
                return NotFound("id tidak ditemukan");
            }

            student.Name = updatedStudent.Name;
            student.Major = updatedStudent.Major;
            student.Age = updatedStudent.Age;

            return Ok("data dengan id" + StudentId +  "diupdate");
        }


        [HttpDelete("{StudentId}")]
        public IActionResult Delete(int StudentId)
        {
            var student = students.FirstOrDefault(s => s.StudentId == StudentId);
            if (student == null)
            {
                return NotFound("id tidak ditemukan");
            }

            students.Remove(student);
            return Ok("data dengan id" + StudentId + "dihapus");
        }
    }
}
