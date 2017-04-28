using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testsolution.Logic.Managers
{
    using Data.Entities;
    using Data.Interfaces;

    public class PersonManager
    {
        private readonly IPersonRepository personRepository;

        public PersonManager(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public IList<Person> GetAll()
        {
            return this.personRepository.GetAll();
        }

        public Person Get(int id)
        {
            return this.personRepository.Get(id);
        }
    }
}
