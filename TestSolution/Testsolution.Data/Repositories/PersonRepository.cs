namespace Testsolution.Data.Repositories
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using CsvHelper;
    using Entities;
    using Interfaces;
    using Newtonsoft.Json;

    public class PersonRepository : IPersonRepository
    {
        public List<Person> personRepo = new List<Person>();
        public PersonRepository()
        {
            LoadRepo();
        }

        public Person Get(int id)
        {
            return personRepo.FirstOrDefault(x => x.Id == id);
        }

        public IList<Person> GetAll()
        {
            return personRepo;
        }

        private void LoadRepo()
        {
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath(@"~/bin/Data/MOCK_DATA.json")))
            {
                var json = reader.ReadToEnd();
                personRepo = JsonConvert.DeserializeObject<List<Person>>(json);
            }
        }

    }
}
