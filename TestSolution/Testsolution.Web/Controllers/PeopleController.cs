using System.Collections.Generic;

namespace Testsolution.Web.Controllers
{
    using System.Web.Http;
    using Data.Entities;
    using Logic.Managers;

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
