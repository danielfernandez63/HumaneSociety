using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    

    public static class Query
    {
        public static HumaneSocietyDataContext context = new HumaneSocietyDataContext();

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

        public static void RunEmployeeQueries(Employee employee, string message)
        {

        }




        // public static void UpdateClient(Client client)            didnt use after splitting them up
        //  {

        //  }

        public static void UpdatePassword(Client client)
        {
            try
            {
                Client person = (from n in context.Clients where n.ClientId.Equals(client.ClientId) select n).First();
                person.Password = client.Password;
                context.SubmitChanges();
            }
            catch
            {

            }
        }

        public static void UpdateIncome(Client client)
        {
            try
            {
                Client person = (from n in context.Clients where n.ClientId.Equals(client.ClientId) select n).First();
                person.Income = client.Income;
                context.SubmitChanges();
            }
            catch
            {

            }
        }

        public static void UpdateKids(Client client)
        {
            try
            {
                Client person = (from n in context.Clients where n.ClientId.Equals(client.ClientId) select n).First();
                person.NumberOfKids = client.NumberOfKids;
                context.SubmitChanges();
            }
            catch
            {

            }
        }

        public static void UpdateHomeSize(Client client)
        {
            try
            {
                Client person = (from n in context.Clients where n.ClientId.Equals(client.ClientId) select n).First();
                person.HomeSquareFootage = client.HomeSquareFootage;
                context.SubmitChanges();
            }
            catch
            {

            }
        }

        public static void UpdateUsername(Client client)
        {
            try
            {
                Client person = (from n in context.Clients where n.ClientId.Equals(client.ClientId) select n).First();
                person.UserName = client.UserName;
                context.SubmitChanges();
            }
            catch
            {

            }
        }
        public static void UpdateEmail(Client client)
        {
            try
            {
                Client person = (from n in context.Clients where n.ClientId.Equals(client.ClientId) select n).First();
                person.Email = client.Email;
                context.SubmitChanges();
            }
            catch
            {

            }
        }
        public static void UpdateAddress(Client client)
        {
            try
            {
                Client person = (from n in context.Clients where n.ClientId.Equals(client.ClientId) select n).First();
                person.Address = client.Address;
                context.SubmitChanges();
            }
            catch
            {

            }
        }
        public static void UpdateFirstName(Client client)
        {
            try
            {
                Client person = (from n in context.Clients where n.ClientId.Equals(client.ClientId) select n).First();
                person.FirstName = client.FirstName;
                context.SubmitChanges();             
            }
            catch
            {

            }

        }
        public static void UpdateLastName(Client client)
        {
            try
            {
                Client person = (from n in context.Clients where n.ClientId.Equals(client.ClientId) select n).First();
                person.LastName = client.LastName;
                context.SubmitChanges();
            }
            catch
            {

            }

        }
    
    }
}
