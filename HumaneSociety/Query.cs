using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public static class Query
    {
        public static Room GetRoom(int animalID)
        {

        }

        public static Adoption GetPendingAdoptions()
        {

        }
        public static void UpdateAdoption(bool someBool, Adoption adoption)
        {

        }
        public static AnimalShot GetShots(Animal animal)
        {

        }
        public static void UpdateShot(string shot, Animal animal)
        {

        }
        public static void EnterUpdate(Animal animal, Dictionary<int, string> updates)
        {

        }
        public static void RemoveAnimal(Animal animal)
        {

        }
        public static Species GetSpecies()
        {

        }
        public static DietPlan GetDietPlan()
        {

        }
        public static void AddAnimal(Animal animal)
        {

        }
        public static Employee EmployeeLogin(string userName, string password)
        {
            
        }
        public static Employee RetrieveEmployeeUser(string email, int employeeNumber)
        {

        }
        public static void AddUsernameAndPassword(Employee employee)
        {

        }
        public static bool CheckEmployeeUsernameExist(string username)
        {
            return false;
        }
        public static Client GetClient(string userName, string password)
        {

        }
        public static int GetUserAdoptionStatus(Client client)
        {

        }
        public static Animal GetAnimalByID(int ID)
        {

        }
        public static void Adopt(Animal animal, Client client)
        {

        }
        public static Client RetrieveClients()
        {

        }
        public static USState GetStates()
        {

        }
        public static void AddNewClient(string firstName, string lastName, string username, string password, string email, string streetAddress, int zipCode, int state)
        {

        }
        public static void UpdateClient(Client client)
        {

        }
        public static void UpdateUsername(Client client)
        {

        }
        public static void UpdateEmail(Client client)
        {

        }
        public static void UpdateAddress(Client client)
        {

        }
        public static void UpdateFirstName(Client client)
        {

        }
        public static void UpdateLastName(Client client)
        {

        }
        public static void RunEmployeeQueries(Employee employee, string message) //pass in employee?
        {

        }

    }
}
