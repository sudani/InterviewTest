namespace Testsolution.Domain.Interfaces
{
    using System.Collections.Generic;
    using Entities;

    public interface IPersonRepository
    {
        Person Get(int id);
        IReadOnlyCollection<Person> GetAll();
    }
}
