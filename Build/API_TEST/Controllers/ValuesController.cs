using API_TEST.Core;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using API_TEST.Models;
using System.Text;
using System;

namespace API_TEST.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpGet]
        public StringBuilder Get()
        {
            using (Manager objConnection = new Manager())
            {
                StringBuilder resultado = new StringBuilder();
                var lstpersonajes = objConnection.Factory.Personajes.ToList();
                var lista = new List<string>();
                foreach (var personaje in lstpersonajes)
                    resultado.Append($"[{personaje.Id} - {personaje.Nombre} {personaje.Apellido} - {personaje.Serie}]");
                return resultado;
            }            
        }

        // GET api/values/5
        [HttpGet]
        [ActionName("GetName")]
        public string GetNameById(int id)
        {
            using (Manager objConnection = new Manager())
            {
                objConnection.Connect();
                var name = objConnection.Factory.Personajes.Where(x => x.Id == id).Select(x => x.Nombre).FirstOrDefault();
                return name;
            }
        }
        [HttpGet]
        [ActionName("GetLastName")]
        public string GetLastNameById(int id)
        {
            using (Manager objConnection = new Manager())
            {
                objConnection.Connect();
                var lastName = objConnection.Factory.Personajes.Where(x => x.Id == id).Select(x => x.Apellido).FirstOrDefault();
                return lastName;
            }
        }
        [HttpGet]
        [ActionName("GetFullName")]
        public string GetFullNameById(int id)
        {
            using (Manager objConnection = new Manager())
            {
                objConnection.Connect();
                var objPersonaje = objConnection.Factory.Personajes.Where(x => x.Id == id).FirstOrDefault();
                var fullName = objPersonaje.Nombre + " " + objPersonaje.Apellido;
                return fullName;
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
            using (Manager objConexion = new Manager()) 
            {
                objConexion.Connect();
                var objPersonaje = objConexion.Factory.Personajes.Where(x => x.Id == id).FirstOrDefault();
                if (objPersonaje != null)
                    objConexion.Factory.Personajes.DeleteOnSubmit(objPersonaje);
                objConexion.Factory.SubmitChanges();
            }
        }
    }
}
