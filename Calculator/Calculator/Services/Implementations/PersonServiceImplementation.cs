using Calculator.Model;
using Calculator.Model.Context;
using System;

namespace Calculator.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySqlContext _context;

        public PersonServiceImplementation(MySqlContext context)
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }
        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

            return person;

        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id))
                return new Person();

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {

                    throw e;
                }
            }

            return result;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
        }

        private bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
