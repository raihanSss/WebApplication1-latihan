using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: api/<HomeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [Route("create")]
        [HttpPost]
        public string Create([FromBody] string value)
        {
            return "hehe";
        }

        // POST api/<HomeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        [Route("product")]
        [HttpPost]
        public string Createproduct([FromBody] string value)
        {
            return "hehe";
        }


       /*[route("product")]
        [httpget("{id}")]
        public iactionresult getproduct(int id)
        {
           if (id > 5)
            {
                return notfound();
            }
           return ok("id = " + id);
        }*/
    }
}
