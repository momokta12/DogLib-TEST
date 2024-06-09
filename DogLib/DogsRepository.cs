using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogLib
{
    public class DogsRepository
    {
        public int nextId = 4;
        private List<Dog> Dogs = new()
        {
            new Dog { Id = 1, Name = "Fido", Age = 3 },
            new Dog { Id = 2, Name = "Rex", Age = 5 },
            new Dog { Id = 3, Name = "Spot", Age = 2 }
        };
        
        public Dog Add(Dog dog)
        {
            dog.Id = nextId++;
            Dogs.Add(dog);
            return dog;
        }

        public List<Dog> GetAll()
        {
            return new List<Dog>(Dogs);
        }

        public Dog? GetById(int id)
        {
            return Dogs.Find(d => d.Id == id);
        }

        public Dog? Delete(int id)
        {
            Dog? dog = GetById(id);
            if (dog is null)
            {
                throw new ArgumentException("Dog not found");
            }
            else 
            {
                Dogs.Remove(dog);
            }
            return dog;
        }

          // Sort by name
        public IEnumerable<Dog> SortByName()
        {
                return Dogs.OrderBy(dog => dog.Name);
        }

            // Sort by age
        public IEnumerable<Dog> SortByAge()
        {
                return Dogs.OrderBy(dog => dog.Age);
        }

            // Filter by name
        public IEnumerable<Dog> FilterByName(string name)
        {
                return Dogs.Where(dog => dog.Name == name);
        }

    }
}
