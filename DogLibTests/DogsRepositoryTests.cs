using Microsoft.VisualStudio.TestTools.UnitTesting;
using DogLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogLib.Tests
{
    [TestClass()]
    public class DogsRepositoryTests
    {

        [TestMethod()]
        public void AddTest()
        {
            DogsRepository repository = new();// her laver vi en ny instans af DogsRepository
            int initialCount = repository.GetAll().Count;// her tæller vi antallet af hunde i listen

            Dog dog = new(); // her laver vi en ny instans af Dog
            repository.Add(dog); // her tilføjer vi en hund til listen

            Assert.AreEqual(initialCount + 1, repository.GetAll().Count);// her tester vi at listen er incremented
            Assert.AreEqual(initialCount + 1, dog.Id); //her tester vi at nextId er incremented

        }

        [TestMethod()]
        public void GetAllTest()//her tester vi at vi får en liste med 3 hunde 
        {
            DogsRepository dogrepository = new(); // her laver vi en ny instans af DogsRepository
            var dogs = dogrepository.GetAll(); // her henter vi listen af hunde
            Assert.AreEqual(3, dogs.Count); // her tester vi at listen indeholder 3 hunde
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            DogsRepository dogrepository = new(); // her laver vi en ny instans af DogsRepository

            Dog dog = new Dog();// her laver vi en ny instans af Dog

            dogrepository.Add(dog); // her tilføjer vi en hund til listen

            Dog retrievedDog = dogrepository.GetById(dog.Id); // her henter vi hunden fra listen

            Assert.AreEqual(dog.Id, retrievedDog.Id); // her tester vi at hunden er retrieved Med samme Id
            Assert.IsNotNull(retrievedDog); // her tester vi at retrievedDog ikke er null
        }

        [TestMethod()]
        public void DeleteTest()
        {
            DogsRepository dogrepository = new(); // Create a new instance of DogsRepository

            Dog newDog =new Dog {Name="newdog", Age= 6 }; // Create a new instance of Dog
            dogrepository.Add(newDog); // Add the dog to the list

            int initialCount = dogrepository.GetAll().Count; // Count the number of dogs in the list

            Dog dogtodelete = dogrepository.GetAll().FirstOrDefault(); // Get the first dog from the list
            
            if (dogtodelete != null)
            {
                Dog deleteddog = dogrepository.Delete(dogtodelete.Id); // Delete the dog from the list
           
                Assert.AreEqual(initialCount - 1, dogrepository.GetAll().Count); // Test that the list count has decreased
                Assert.IsNull(dogrepository.GetById(dogtodelete.Id)); // Test that the dog is not in the list
                Assert.AreEqual(dogtodelete.Id, deleteddog.Id); // Test that the dog is not in the list
            }      
            
            else
            {
                Assert.Fail("No dog to delete");
            }
        }

        [TestMethod()]
        public void SortByName(){
            DogsRepository dogrepository = new(); // Create a new instance of DogsRepository

            var sortedDogs = dogrepository.SortByName(); // Sort the dogs by name

            Assert.AreEqual("Fido", sortedDogs.First().Name); // Test that the first dog is Fido
            Assert.AreEqual("Spot", sortedDogs.Last().Name); // Test that the last dog is Spot
        }

        [TestMethod()]
        public void SortByAge(){
            DogsRepository dogrepository = new(); // Create a new instance of DogsRepository

            var sortedDogs = dogrepository.SortByAge(); // Sort the dogs by age

            Assert.AreEqual(2, sortedDogs.First().Age); // Test that the first dog is 2 years old
            Assert.AreEqual(5, sortedDogs.Last().Age); // Test that the last dog is 5 years old
        }
        
        [TestMethod()]
        public void FilterByName() {             
            DogsRepository dogrepository = new(); // Create a new instance of DogsRepository

            var filteredDogs = dogrepository.FilterByName("Fido"); // Filter the dogs by name

            Assert.AreEqual(1, filteredDogs.Count()); // Test that the list contains 1 dog
            Assert.AreEqual("Fido", filteredDogs.First().Name); // Test that the first dog is Fido
        }
    }
}