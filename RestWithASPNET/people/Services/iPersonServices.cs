using projeto2.Model;

namespace projeto2.Services
{
    public interface iPersonServices
    {
        Person Create(Person person);
        Person FindByID(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);

    }
}
