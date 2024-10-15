using System.Collections.Generic;
using System.Web.Http;

namespace OwinTest.Controllers
{
    /// <summary>
    /// WebApi控制器：Values
    /// </summary>
    public class ValuesController : ApiController
    {

        static readonly List<string> _values = new List<string> { "value1", "value2", "value3" };



        // GET api/values
        public IEnumerable<string> Get()
        {
            return _values;
        }

        // GET api/values/5
        public string Get(int id)
        {
            if (id < 0 || id > _values.Count) return "NULL.";
            return _values[id];
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
            _values.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
            if (id < 0 || id > _values.Count) return;
            _values[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            if (id < 0 || id > _values.Count) return;
            _values.RemoveAt(id);
        }
    }
}
