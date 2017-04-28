namespace Testsolution.Data.Interfaces
{
    using System.Collections.Generic;
    using Entities;

    public interface IPersonRepository
    {
        Person Get(int id);
        IList<Person> GetAll();
    }
}
