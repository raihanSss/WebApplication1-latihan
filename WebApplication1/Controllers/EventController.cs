using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.models;

namespace WebApplication1.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private static readonly List<Event> events = new List<Event>();

        [HttpPost]
        public IActionResult CreateEvent([FromBody] Event even)
        {
            events.Add(even);

            return Ok("Data berhasil ditambah");
        }


        [HttpGet("{id}")]
        public IActionResult GetEvent(int id)
        {
            var even = events.FirstOrDefault(e => e.id == id);
            if (even == null)
            {
                return NotFound("id tidak ditemukan");
            }
            return Ok(events);
        }


        [HttpGet]
        public IActionResult GetEvents([FromQuery] string name, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
    
            var query = events.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            }

            if (startDate.HasValue)
            {
                query = query.Where(e => e.Date >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(e => e.Date <= endDate.Value);
            }


            return Ok(query.ToList());
        }
    


        [HttpPut("{id}")]
        public IActionResult UpdateEvent(int id, [FromBody] Event updatedEvent)
        {
            var even = events.FirstOrDefault(e => e.id == id);
            if (even == null)
            {
                return NotFound("id tidak ditemukan");
            }

            even.Name = updatedEvent.Name;
            even.Date = updatedEvent.Date;
            even.Location = updatedEvent.Location;
            even.MaxAttendees = updatedEvent.MaxAttendees;
            even.Tags = updatedEvent.Tags;

            return Ok("data dengan id" + id + "diupdate");
        }


        [HttpPatch("{id}/location")]
        public IActionResult UpdateLocation(int id, [FromForm] Event updatedLocation)
        {
            var even = events.FirstOrDefault(e => e.id == id);
            if (even == null)
            {
                return NotFound("id tidak ditemukan");
            }

            even.Location = updatedLocation.Location;
           
            return Ok("lokasi dengan id" + id + "diupdate");
        }


        [HttpPost("{id}/tags")]
        public IActionResult AddTag([FromRoute] int id, [FromHeader(Name = "X-New-Tag")] string newTag)
        {
            var even = events.FirstOrDefault(e => e.id == id);
            if (even == null)
            {
                return NotFound("Event not found.");
            }

            
            even.Tags.Add(newTag);

            return Ok(new { EventId = even.id, Tags = even.Tags });
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var even = events.FirstOrDefault(e => e.id == id);
            if (even == null)
            {
                return NotFound("id tidak ditemukan");
            }

            events.Remove(even);
            return Ok("data event dengan id" + id + "dihapus");
        }


        [HttpGet("export")]
        public IActionResult ExportEvents([FromQuery] string format)
        {
  
            if (format != "csv" && format != "json")
            {
                return BadRequest("Invalid format specified. Please use 'csv' or 'json'.");
            }

    
            if (format == "csv")
            {
                var csv = GenerateCsv(events);
                return File(Encoding.UTF8.GetBytes(csv), "text/csv", "events.csv");
            }
            else
            {
                return Ok(events);
            }
        }

        private string GenerateCsv(List<Event> events)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Id,Name, Date, Location, MaxAttendees,Tags");

            foreach (var e in events)
            {
                var tags = string.Join(";", e.Tags);
                sb.AppendLine($"{e.id},{e.Name}, {e.Date}, {e.Location}, {e.MaxAttendees}, {tags}");
            }

            return sb.ToString();
        }



    }

    


}
