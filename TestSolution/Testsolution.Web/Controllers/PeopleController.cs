using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testsolution.Web.Controllers
{
    using System.Web.Http;
    using Data.Entities;
    using Logic.Managers;
    using Newtonsoft.Json;

    [RoutePrefix("People")]
    public class PeopleController : ApiController
    {
        private readonly PersonManager personManager;

        public PeopleController(PersonManager personManager)
        {
            this.personManager = personManager;
        }

        [HttpGet]
        [Route("GetAll")]
        public IList<Person> GetAll()
        {
            return this.personManager.GetAll();
        }

        [HttpGet]
        [Route("GetPerson/{id}")]
        public object Get(int id)
        {
            return this.personManager.Get(id);
        }
    }
}
