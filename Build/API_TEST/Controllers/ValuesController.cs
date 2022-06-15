using API_TEST.Core;
using System.Collections.Generic;
using System.Web.Http;
using API_TEST.Core;
using System.Linq;
using API_TEST.Models;

namespace API_TEST.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Personajes> Get()
        {
            using (Manager objConnection = new Manager())
            {
                objConnection.Connect();
                return objConnection.Factory.Personajes.AsEnumerable();
            }
        }

        // GET api/values/5
        [HttpGet]
        public string GetNameById(int id)
        {
            using (Manager objConnection = new Manager())
            {
                objConnection.Connect();
                var name = objConnection.Factory.Personajes.Where(x => x.Id == id).Select(x => x.Nombre).FirstOrDefault();            
                return name;
            }
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
