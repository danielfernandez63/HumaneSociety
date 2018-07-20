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
        public delegate void employeeQueryCRUD(Employee employee);


        public static void RunEmployeeQueryUpdate(Employee employee)
        {
            Employee name = (from n in context.Employees where n.EmployeeId == employee.EmployeeId select n).First();
            name.FirstName = employee.FirstName;
            name.LastName = employee.LastName;
            name.Email = employee.Email;
            name.EmployeeId = employee.EmployeeId;
            context.SubmitChanges();
        }
        public static void RunEmployeeQueryRead(Employee employee)
        {
            Employee name = (from n in context.Employees where n.EmployeeNumber == employee.EmployeeNumber select n).First();
            Console.WriteLine($"EmployeeID: {name.EmployeeId} Employee Number: {name.EmployeeNumber} Employee Name: {name.FirstName + " " + name.LastName} Employee UserName: {name.UserName} Employee Password: {name.Password} Employee email: {name.Email}");
            Console.ReadLine();
        }
        public static void RunEmployeeQueryDelete(Employee employee)
        {
            Employee name = (from n in context.Employees where n.EmployeeNumber == employee.EmployeeNumber select n).First();
            context.Employees.DeleteOnSubmit(employee);
            context.SubmitChanges();
        }
        public static void RunEmployeeQueryCreate(Employee employee)
        {
            context.Employees.InsertOnSubmit(employee);
            context.SubmitChanges();
        }



        public static void RunEmployeeQueries(Employee employee, string message)
        {
            employeeQueryCRUD runEmployeeCrudDelegate;

            if (message == "update")
            {
                runEmployeeCrudDelegate = RunEmployeeQueryUpdate;
                runEmployeeCrudDelegate(employee);
            }
            else if (message == "read")
            {
                runEmployeeCrudDelegate = RunEmployeeQueryRead;
                runEmployeeCrudDelegate(employee);
            }
            else if (message == "delete")
            {
                runEmployeeCrudDelegate = RunEmployeeQueryDelete;
                runEmployeeCrudDelegate(employee);
            }
            else if (message == "create")
            {
                runEmployeeCrudDelegate = RunEmployeeQueryCreate;
                runEmployeeCrudDelegate(employee);
<<<<<<< HEAD
            }
        }
        public static void ImportCSVDataToDatabase(string[][] csvOutputData) // CSV Data to New Record
        {
            for (int i = 0; i < csvOutputData.Count(); i++)
            {
                Animal newAnimal = new Animal();
                newAnimal.AnimalId = int.Parse(csvOutputData[i][0]);
                newAnimal.Name = csvOutputData[i][1];
                newAnimal.Weight = int.Parse(csvOutputData[i][3]);
                newAnimal.Age = int.Parse(csvOutputData[i][4]);
                newAnimal.Demeanor = csvOutputData[i][7];
                newAnimal.KidFriendly = (int.Parse(csvOutputData[i][8]) == 1) ? true : false;
                newAnimal.PetFriendly = (int.Parse(csvOutputData[i][9]) == 1) ? true : false;
                newAnimal.AdoptionStatus = csvOutputData[i][10];
                context.Animals.InsertOnSubmit(newAnimal);
                context.SubmitChanges();
=======
>>>>>>> 6868244ce47ce623a8b791bb6ad8c9ed03e731fa
            }
        }

        public static void EnterUpdate(Animal animal, Dictionary<int, string> updates)
        {
            foreach (KeyValuePair<int, string> element in updates)
            {
                var specifiedAnimal = (from animals in context.Animals
                                       where animals.AnimalId == animal.AnimalId
                                       select animals).First();
                switch (element.Key)
                {
                    case 1:
                        specifiedAnimal.Species.Name = element.Value;
                        break;
                    case 2:
                        specifiedAnimal.Species.Name = element.Value;
                        break;
                    case 3:
                        specifiedAnimal.Name = element.Value;
                        break;
                    case 4:
                        specifiedAnimal.Age = int.Parse(element.Value);
                        break;
                    case 5:
                        specifiedAnimal.Demeanor = element.Value;
                        break;
                    case 6:
                        specifiedAnimal.KidFriendly = bool.Parse(element.Value);
                        break;
                    case 7:
                        specifiedAnimal.PetFriendly = bool.Parse(element.Value);
                        break;
                    case 8:
                        specifiedAnimal.Weight = int.Parse(element.Value);
                        break;
                }
            }
            context.SubmitChanges();
        }

        public static Employee RetrieveEmployeeUser(string email, int employeeNumber)
        {
            var employeeSearch = (from e in context.Employees where e.Email == email && e.EmployeeNumber == employeeNumber select e).First();
            if (employeeSearch.EmployeeId > 0)
            {
                return employeeSearch;
            }
            else
            {
                employeeSearch.Password = null;
                return employeeSearch;
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
            newAdoption.AdoptionFee = 200;            
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

        public static List<Animal> GetAnimal()
        {
            var animalList = (from animal in context.Animals
                              where animal.AnimalId >= 0
                              select animal).ToList();
            return animalList;

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
        public static DietPlan GetDietPlan(string dietPlan)
        {
            try
            {
                var getDietPlan = (from d in context.DietPlans
                                  where d.Name == dietPlan
                                  select d).First();
                return getDietPlan;
            }
            catch
            {
                DietPlan newDietPlan = new DietPlan();
                newDietPlan.Name = dietPlan;
                context.DietPlans.InsertOnSubmit(newDietPlan);
                context.SubmitChanges();
                return newDietPlan;
            }
        }
        public static Species GetSpecies(string species)
        {
            try
            {
                var getSpecies = (from s in context.Species
                                  where s.Name == species
                                  select s).First();
                return getSpecies;
            }
            catch
            {
                Species newSpecies = new Species();
                newSpecies.Name = species;
                context.Species.InsertOnSubmit(newSpecies);
                context.SubmitChanges();
                return newSpecies;
            }
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
            var updatedAdoption = willApprove == true ? adoption.ApprovalStatus = "Adopted" : adoption.ApprovalStatus = "Adoption Denied";
            context.SubmitChanges();
        }

        public static Room GetRoom(int animalID)
        {
            var roomResult = (from room in context.Rooms
                              where room.AnimalId == animalID
                              select room).First();
            return roomResult;
        }
        public static void UpdateRoom(Animal animal, int newRoomNumber)
        {          
            var roomResult = (from room in context.Rooms
                                where room.RoomNumbers == newRoomNumber
                                select room).First();
            if (roomResult.RoomNumbers == null)
            {
                roomResult.AnimalId = animal.AnimalId;
                context.SubmitChanges();
            }
            else
            {
                roomResult.RoomNumbers = roomResult.RoomNumbers;
                Console.WriteLine("Room is already occupied!");
            }
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
