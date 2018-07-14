using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Test.UI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> GetList()
       {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string GetById(string id)
        {
            return $"value = {id}";
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody]string value)
        {
            return new JsonResult(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
