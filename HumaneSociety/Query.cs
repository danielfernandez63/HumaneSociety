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

        public static void EnterUpdate(Animal animal, Dictionary<int, string> updates)
        {

        }      

        public static Employee RetrieveEmployeeUser(string email, int employeeNumber)
        {

        }    

        public static void RunEmployeeQueries(Employee employee, string message)
        {
            // delegate
            if (message == "update")
            {
                Employee name = (from n in context.Employees where n.EmployeeId == employee.EmployeeId select n).First();
                name.FirstName = employee.FirstName;
                name.LastName = employee.LastName;
                name.Email = employee.Email;
                name.EmployeeId = employee.EmployeeId;
                context.SubmitChanges();
            }
            else if (message == "read")
            {
                Employee name = (from n in context.Employees where n.EmployeeNumber == employee.EmployeeNumber select n).First();
                Console.WriteLine("Here are the results for the employee you searched for: " + employee);
                Console.ReadLine();
            }
            else if (message == "delete")
            {
                Employee name = (from n in context.Employees where n.EmployeeNumber == employee.EmployeeNumber select n).First();
                context.Employees.DeleteOnSubmit(employee);
                context.SubmitChanges();
            }
            else if (message == "create")
            {
                context.Employees.InsertOnSubmit(employee);
                context.SubmitChanges();
            }
        }


        public static void RemoveAnimal(Animal animal)
        {
            try
            {
                Animal name = (from n in context.Animals where n.AnimalId == animal.AnimalId select n).First();
                context.Animals.DeleteOnSubmit(animal);
                context.SubmitChanges();

            }
            catch
            {

            }
        }

        public static void AddAnimal(Animal animal)
        {
            try
            {             
                context.Animals.InsertOnSubmit(animal);
                context.SubmitChanges();             
            }
            catch
            {
               
            }

        }

        public static bool CheckEmployeeUsernameExist(string username)
        {
            try
            {
               Employee person = (from n in context.Employees where n.UserName == username select n).First();

                return true;            
            }
            catch
            {
                return false;
            }
         
        }

        public static void AddUsernameAndPassword(Employee employee)
        {
            try
            {
                Employee person = (from n in context.Employees where n.EmployeeId.Equals(employee.EmployeeId) select n).First();
                person.Password = employee.Password;
                person.UserName = employee.UserName;
                context.SubmitChanges();
            }
            catch
            {

            }
        }

        public static void AddNewClient(string firstName, string lastName, string username, string password, string email, string streetAddress, int zipCode, int state)
        {         
                Client newclient = new Client();
                Address newaddress = new Address();
                {
                    newclient.FirstName = firstName;
                    newclient.LastName = lastName;
                    newclient.UserName = username;
                    newclient.Password = password;
                    newclient.Email = email;
                    newaddress.AddressLine1 = streetAddress;
                    newaddress.Zipcode = zipCode;
                    newaddress.USStateId = state;
                    newclient.AddressId = newaddress.AddressId;        
                }

            try
            {
                context.Clients.InsertOnSubmit(newclient);
                context.SubmitChanges();
            }
            catch
            {

            }

        }

        public static IQueryable<Client> RetrieveClients()
        {
            var getClients = from clients in context.Clients
                             select clients;
            return getClients;
        }
        public static IQueryable<USState> GetStates()
        {
            var getStates = from states in context.USStates
                            select states;
            return getStates;
        }
        public static void Adopt(Animal animal, Client client)
        {
            Adoption newAdoption = new Adoption();
            newAdoption.ClientId = client.ClientId;
            newAdoption.AnimalId = animal.AnimalId;
            newAdoption.AdoptionFee = 75;
            context.Adoptions.InsertOnSubmit(newAdoption);
            context.SubmitChanges();
        }
        public static Animal GetAnimalByID(int ID)
        {
            var animalByID = (from animal in context.Animals
                              where animal.AnimalId == ID
                              select animal).First();
            return animalByID;
        }
        public static IQueryable<Adoption> GetUserAdoptionStatus(Client client)
        {
            var adoptionStatus = from status in context.Adoptions
                                 where status.ClientId == client.ClientId
                                 select status;
            return adoptionStatus;
        }
        public static Client GetClient(string userName, string password)
        {
            var existingClient = (from client in context.Clients
                                  where client.UserName == userName && client.Password == password
                                  select client).First();
            return existingClient;
        }
        public static Employee EmployeeLogin(string userName, string password)
        {
            var existingEmployee = (from employee in context.Employees
                                    where employee.UserName == userName && employee.Password == password
                                    select employee).First();
            return existingEmployee;
        }
        public static IQueryable<DietPlan> GetDietPlan()
        {
            var getDietPlans = from dietPlan in context.DietPlans
                               select dietPlan;
            return getDietPlans;
        }
        public static IQueryable<Species> GetSpecies()
        {
            var getSpecies = from species in context.Species
                             select species;
            return getSpecies;
        }
        public static IQueryable<AnimalShot> GetShots(Animal animal)
        {
            var animalShots = from shots in context.AnimalShots
                              where shots.AnimalId == animal.AnimalId
                              select shots;
            return animalShots;
        }
        public static void UpdateShot(string shot, Animal animal)
        {
            AnimalShot newShot = new AnimalShot();
            newShot.AnimalId = animal.AnimalId;
            newShot.DateReceived = DateTime.Now;
            context.AnimalShots.InsertOnSubmit(newShot);
            context.SubmitChanges();

        }

        public static void UpdateAdoption(bool willApprove, Adoption adoption)
        {
            var updatedAdoption = willApprove == true ? adoption.ApprovalStatus = "Approved" : adoption.ApprovalStatus = "Denied";
            context.SubmitChanges();
        }

        public static Room GetRoom(int animalID)
        {
            var roomResult = (from room in context.Rooms
                              where room.AnimalId == animalID
                              select room).First();
            return roomResult;
        }
        public static IQueryable<Adoption> GetPendingAdoptions()
        {
            var pendingAdoptions = from adoption in context.Adoptions where adoption.ApprovalStatus == "pending" select adoption;
            return pendingAdoptions;
        }

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
