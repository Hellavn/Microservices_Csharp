using projeto2.Model;

namespace projeto2.Services.implementations
{
    public class PersonServiceImplementation : iPersonServices
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i<8; i++)
            {
                Person person = MockPerson(i);
                people.Add(person);
            }
            return people;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Primeiro Nomes " +i,
                LastName = "Sobrenome " + i,
                Address = "Endereço " + i,
                Gender = "F " 


            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindByID(long id)
        {
            return new Person
            {
                
                FirstName = "Maria",
                LastName = "da Dores",
                Address = "Campos do Jordão - SP",
                Gender = "F"

            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
