using ANIMAL.DAL.DataModel;
using ANIMAL.MODEL;
using ANIMAL.Repository.Common;
using ANIMAL.Service.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ANIMAL.Service
{
    public class Service : IService
    {
        readonly IRepository _repository;
        public Service(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<AdoptedDomain> GetAllAdoptedDomain()
        {
            IEnumerable<AdoptedDomain> adoptedDomains = _repository.GetAllAdoptedDomain();
            return adoptedDomains;
        }
        public IEnumerable<AdopterDomain> GetAllAdopterDomain()
        {
            IEnumerable<AdopterDomain> adopterDomains = _repository.GetAllAdopterDomain();
            return adopterDomains;
        }
        public IEnumerable<AnimalDomain> GetAllAnimalDomain()
            {
                IEnumerable<AnimalDomain> animalDomains = _repository.GetAllAnimalDomain();
                return animalDomains;

            } 
        IEnumerable<ReturnedAnimalDomain> IService.GetAllReturnedAnimalDomain()
        {
            IEnumerable<ReturnedAnimalDomain> reptileDomains = _repository.GetAllReturnedAnimalDomain();
            return reptileDomains;
        }
        IEnumerable<AnimalDomain> IService.GetAllAnimalDomainAdopt()
        {
            IEnumerable<AnimalDomain> adoptedDomains = _repository.GetAllAnimalDomainAdopt();
            return adoptedDomains;
        }  
        IEnumerable<AnimalDomain> IService.GetAllAnimalDomainNoPicture()
        {
            IEnumerable<AnimalDomain> animalDomains = _repository.GetAllAnimalDomain();
            return animalDomains;
        }


        //novo

        IEnumerable<AnimalRecordDomain> IService.GetAllAnimalRecordDomain()
        {
            IEnumerable<AnimalRecordDomain> recordDomains = _repository.GetAllAnimalRecordDomain();
            return recordDomains;
        }
        IEnumerable<BalansDomain> IService.GetAllBlansDomain()
        {
            IEnumerable<BalansDomain> balansDomains = _repository.GetAllBlansDomain();
            return balansDomains;
        }
        IEnumerable<ContactDomain> IService.GetaAllContactDomain()
        {
            IEnumerable<ContactDomain> contactDomains = _repository.GetaAllContactDomain();
            return contactDomains;
        }
        IEnumerable<ContageusAnimalsDomain> IService.GetAllContageusAnimalsDomain()
        {
            IEnumerable<ContageusAnimalsDomain> contageusAnimalsDomains = _repository.GetAllContageusAnimalsDomain();
            return contageusAnimalsDomains;
        }
        IEnumerable<EuthanasiaDomain> IService.GetAllEuthanasiaDomain()
        {
            IEnumerable<EuthanasiaDomain> euthanasiaDomains = _repository.GetAllEuthanasiaDomain();
            return euthanasiaDomains;
        }
        IEnumerable<FoodDomain> IService.GetAllFoodDomain()
        {
            IEnumerable<FoodDomain> foodDomains = _repository.GetAllFoodDomain();
            return foodDomains;
        }
        IEnumerable<FoundRecordDomain> IService.GetAllFoundRecord()
        {
            IEnumerable<FoundRecordDomain> fundRecordDomains = _repository.GetAllFoundRecord();
            return fundRecordDomains;
        }
        IEnumerable<FundsDomain> IService.GetAllFundsDomain()
        {
            IEnumerable<FundsDomain> funsdDomains = _repository.GetAllFundsDomain();
            return funsdDomains;
        }
        IEnumerable<LabsDomain> IService.GetAllLabsDomain()
        {
            IEnumerable<LabsDomain> labsDomains = _repository.GetAllLabsDomain();
            return labsDomains;
        }
        IEnumerable<MedicinesDomain> IService.GetAllMedicinesDomain()
        {
            IEnumerable<MedicinesDomain> medicinesDomains = _repository.GetAllMedicinesDomain();
            return medicinesDomains;
        }
        IEnumerable<NewsDomain> IService.GetAllNewsDomain()
        {
            IEnumerable<NewsDomain> newsDomains = _repository.GetAllNewsDomain();
            return newsDomains;
        }
        IEnumerable<ParameterDomain> IService.GetAllParameterDomain(int id)
        {
            IEnumerable<ParameterDomain> parametarDomains = _repository.GetAllParameterDomain(id);
            return parametarDomains;
        }
        IEnumerable<SystemRecordDomain> IService.GetAllSystemRecordDomain()
        {
             IEnumerable<SystemRecordDomain> systemRecordDomains = _repository.GetAllSystemRecordDomain();
            return systemRecordDomains;
        }
        IEnumerable<ToysDomain> IService.GetAllToysDomain()
        {
            IEnumerable<ToysDomain> toysDomains = _repository.GetAllToysDomain();
            return toysDomains;
        }
        IEnumerable<VetVisitsDomain> IService.GetAllVetVisitsDomain()
        {
            IEnumerable<VetVisitsDomain> vetDomains = _repository.GetAllVetVisitsDomain();
            return vetDomains;
        }






        //GET BY ID
        public AmphibianDomain GetAllAmphibianDomain(int id)
        {
            AmphibianDomain amphibianDomains = _repository.GetAllAmphibianDomain(id);
            return amphibianDomains;
        }
        AnimalDomain IService.GetAllAnimalById(int animalId)
        {
            AnimalDomain adoptedDomains = _repository.GetAllAnimalById(animalId);
            return adoptedDomains;
        }
        BirdDomain IService.GetAllBirdDomain(int id)
        {
            BirdDomain birdDomains = _repository.GetAllBirdDomain(id);
            return birdDomains;
        }
        FishDomain IService.GetAllFishDomain(int id)
        {
            FishDomain fishDomains = _repository.GetAllFishDomain(id);
            return fishDomains;
        }
        MammalDomain IService.GetAllMammalDomain(int id)
        {
            MammalDomain mamelDomains = _repository.GetAllMammalDomain(id);
            return mamelDomains;
        }
        ReptileDomain IService.GetAllReptileDomain(int id)
        {
            ReptileDomain reptileDomains = _repository.GetAllReptileDomain(id);
            return reptileDomains;
        }
        AnimalDomain IService.GetAnimalById(int animalId)
        {
            AnimalDomain adoptedDomains = _repository.GetAnimalById(animalId);
            return adoptedDomains;
        }
        AdopterDomain IService.GetAdopterById(string id)
        {
            AdopterDomain adoptedDomains = _repository.GetAdopterById(id);
            return adoptedDomains;
        }
        public IEnumerable<AdoptedDomain> GetAllAdoptedDomainForAdopter(int adopterId)
        {
            IEnumerable<AdoptedDomain> adoptedDomains = _repository.GetAllAdoptedDomainForAdopter(adopterId);
            return adoptedDomains;
        }
        AdopterDomain IService.GetAdopterByUsername(string username)
        {
            AdopterDomain adoptedDomains = _repository.GetAdopterByUsername(username);
            return adoptedDomains;
        }
        //get by id novo
        ToysDomain IService.GetOneToysDomain(int id)
        {
            ToysDomain toysDomain = _repository.GetOneToysDomain(id);
            return toysDomain;
        }
        NewsDomain IService.GetOneNewsDomain(int id)
        {
            NewsDomain newsDomain = _repository.GetOneNewsDomain(id);
            return newsDomain;
        }
        MedicinesDomain IService.GetOneMedicinesDomain(int id)
        {
            MedicinesDomain MedicinesDomain = _repository.GetOneMedicinesDomain(id);
            return MedicinesDomain;
        }
        LabsDomain IService.GetOneLabsDomain(int id)
        {
            LabsDomain labsDomain = _repository.GetOneLabsDomain(id);
            return labsDomain;
        }
        FundsDomain IService.GetOneFundsDomain(int id)
        {
            FundsDomain fundsDomain = _repository.GetOneFundsDomain(id);
            return fundsDomain;
        }
        FoundRecordDomain IService.GetOneFoundRecordDomain(int id)
        {
            FoundRecordDomain foundRecordDomain = _repository.GetOneFoundRecordDomain(id);
            return foundRecordDomain;
        }
        FoodDomain IService.GetOneFoodDomain(int id)
        {
            FoodDomain foodDomain = _repository.GetOneFoodDomain(id);
            return foodDomain;
        }
        EuthanasiaDomain IService.GetOneEuthanasiaDomain(int id)
        {
            EuthanasiaDomain euthanasiaDomain = _repository.GetOneEuthanasiaDomain(id);
            return euthanasiaDomain;
        }
        ContageusAnimalsDomain IService.GetOneContageusAnimalsDomain(int id)
        {
            ContageusAnimalsDomain contageusAnimalsDomain = _repository.GetOneContageusAnimalsDomain(id);
            return contageusAnimalsDomain;
        }
        ContactDomain IService.GetOneContactDomain(int id)
        {
            ContactDomain contactDomain = _repository.GetOneContactDomain(id);
            return contactDomain;
        }
        BalansDomain IService.GetOneBalansDomain(int id)
        {
            BalansDomain balansDomain = _repository.GetOneBalansDomain(id);
            return balansDomain;
        }

        //get by id novo novo
        //-----------------------------------------------------------
        AdopterDomain IService.GetAdopterByIdInt(int id)
        {
            AdopterDomain domain = _repository.GetAdopterByIdInt(id);
            return domain;
        }
        MedicinesDomain IService.GetOneMedicinesAnimal(int id)
        {
            MedicinesDomain domain = _repository.GetOneMedicinesAnimal(id);
            return domain;
        }
        ContageusAnimalsDomain IService.GetOneContageusAnimal(int id)
        {
            ContageusAnimalsDomain domain = _repository.GetOneContageusAnimal(id);
            return domain;
        }
        LabsDomain IService.GetOneLabsAnimal(int id)
        {
            LabsDomain domain = _repository.GetOneLabsAnimal(id);
            return domain;
        }
        VetVisitsDomain IService.GetOneVetVisitAnimal(int id)
        {
            VetVisitsDomain domain = _repository.GetOneVetVisitAnimal(id);
            return domain;
        }
        AnimalRecordDomain IService.GetOneAnimalRecord(int id)
        {
         AnimalRecordDomain domain = _repository.GetOneAnimalRecord(id);
            return domain;
        }






        

        //UPDATE
        public Task IncrementNumberOfAdoptedAnimalsAsync(string registerId)
        {
            Task adopter = _repository.IncrementNumberOfAdoptedAnimalsAsync( registerId);
            return adopter;
        }
        public Task IncrementNumberOfReturnedAnimalsAsync(string registerId)
        {
            Task adopter = _repository.IncrementNumberOfReturnedAnimalsAsync( registerId);
            return adopter;
        }
        Task<AdopterDomain> IService.UpdateAdopterAsync(string registerId, string firstName, string lastName, DateTime dateOfBirth, string residence, string username, string password)
        {
            Task<AdopterDomain> adopter = _repository.UpdateAdopterAsync(registerId, firstName, lastName, dateOfBirth, residence, username, password);
            return adopter;
        }
        public Task<AnimalDomain> UpdateAnimalAsync(int idAnimal, int age, decimal weight, decimal height, decimal length, bool neutered, bool vaccinated, bool microchipped, bool trained, bool socialized, string healthIssues, string personalityDescription)
        {
            Task<AnimalDomain> aniimal = _repository.UpdateAnimalAsync( idAnimal,  age,  weight,  height,  length,  neutered,  vaccinated,  microchipped,  trained,  socialized,  healthIssues,  personalityDescription);
            return aniimal;
        }   
        async Task<bool> IService.AdoptionStatus(int animalId)
        {
            await _repository.AdoptionStatus(animalId);
            return true;

        }
        async Task<bool> IService.UpdateAdopterFlag(int adopterId)
        {
          await  _repository.UpdateAdopterFlag(adopterId);
            return true;
        }
        async Task<bool> IService.AdoptionStatusFalse(int animalId)
        {
            await _repository.AdoptionStatusFalse(animalId);
            return true;
        }



        //update novo


        async Task IService.UpdateAnimalRecordDomain(int id, int recordId)
        {
          await _repository.UpdateAnimalRecordDomain( id,  recordId);
  
        }
        async Task<bool> IService.UpdateAnimalBalansDomain(int id, decimal balance)
        {
            await _repository.UpdateAnimalBalansDomain( id,  balance);
            return true;
        }
        async Task<bool> IService.UpdateContageusAnimalsDomain(int id, bool contageus)
        {
            await _repository.UpdateContageusAnimalsDomain( id,  contageus);
            return true;
        }
        async Task<bool> IService.UpdateEuthanasiaDomain(int id, DateTime date, bool complited)
        {
            await _repository.UpdateEuthanasiaDomain( id,  date,  complited);
            return true;
        }
        async Task<bool> IService.UpdateFoodDomainIncrement(int id)
        {
            await _repository.UpdateFoodDomainIncrement( id);
            return true;
        }
        async Task<bool> IService.UpdateFoodDomainDecrement(int id)
        {
            await _repository.UpdateFoodDomainDecrement( id);
            return true;
        }
        async Task<bool> IService.UpdateFoodDomain(int id, string brandName, string name, string foodType, string animalType, string ageGroup, decimal weight, decimal caloriesPerServing, decimal weightPerServing, string measurementPerServing, decimal fatContent, decimal fiberContent, DateTime exporationDate, int quantity, string notes, string measurementWeight)
        {
            await _repository.UpdateFoodDomain( id,  brandName,  name,  foodType,  animalType,  ageGroup,  weight,  caloriesPerServing,  weightPerServing,  measurementPerServing,  fatContent,  fiberContent,  exporationDate,  quantity,  notes,  measurementWeight)
       ;
            return true;
        }
        async Task<bool> IService.UpdateToysDomainIncrement(int id)
        {
            await _repository.UpdateToysDomainIncrement(id);
            return true;
        }
        async Task<bool> IService.UpdateToysDomainDecrement(int id)
        {
            await _repository.UpdateToysDomainDecrement(id);
            return true;
        }
        async Task<bool> IService.UpdateToysDomain(int id, string brandName, string name, string animalType, string toyType, string ageGroup, decimal hight, decimal width, int quantity, string notes)
        {
            await _repository.UpdateToysDomain( id,  brandName,  name,  animalType,  toyType,  ageGroup,  hight,  width,  quantity,  notes);
            return true;
        }
        async Task<bool> IService.UpdateFoundRecordDomain(int id, int animalId, DateTime date, string adress, string description, string ownerName, string ownerSurname, string ownerPhoneNumber, string ownerOIB, string registerId)
        {
            await _repository.UpdateFoundRecordDomain( id,  animalId,  date,  adress,  description,  ownerName,  ownerSurname,  ownerPhoneNumber,  ownerOIB,  registerId);
            return true;
        }   
        async Task<bool> IService.UpdateMedicinesDomainUsage(int id, bool usage)
        {
            await _repository.UpdateMedicinesDomainUsage( id,  usage);
            return true;
        }
        async Task<bool> IService.UpdateMedicinesDomain(int id, decimal amountOfMedicine, string mesurmentUnit, int medicationIntake, string frequencyOfMedicationUse)
        {
            await _repository.UpdateMedicinesDomain( id,  amountOfMedicine,  mesurmentUnit,  medicationIntake,  frequencyOfMedicationUse);
            return true;
        }
        async Task<bool> IService.UpdateNewsDomain(int id, string name, string description, DateTime dateTime)
        {
            await _repository.UpdateNewsDomain( id,  name,  description,  dateTime);
            return true;
        }
        async Task<bool> IService.UpdateVetVisitsDomain(int id, DateTime startTime, DateTime endTime, string notes)
        {
            await _repository.UpdateVetVisitsDomain( id,  startTime,  endTime,  notes);
            return true;
        }
        async Task<bool> IService.UpdateContactDomain(int id)
        {
            await _repository.UpdateContactDomain(id);
            return true;
        }
        async Task<bool> IService.UpdateParametar(ParameterDomain p)
        {
            await _repository.UpdateParametar(p);
            return true;
        }






        //ADD
        Task<AdopterDomain> IService.CreateAdopterAsync(string firstName, string lastName, DateTime dateOfBirth, string residence, string username, string password, string registerId)
        {
            Task<AdopterDomain> adopter = _repository.CreateAdopterAsync(firstName, lastName, dateOfBirth, residence, username, password, registerId);
            return adopter;
        }
        public IEnumerable<ReturnedAnimalDomain> GetAllReturnedAnimalsForAdopter(int adopterId)
        {
            IEnumerable<ReturnedAnimalDomain> animalDomains = _repository.GetAllReturnedAnimalsForAdopter(adopterId);
            return animalDomains;
        }
        public  Task<AnimalDomain> AddAnimalAsync(string name, string family, string species, string subspecies, int age, string gender, decimal weight, decimal height, decimal length, bool neutered, bool vaccinated, bool microchipped, bool trained, bool socialized, string healthIssues, byte[] picture, string personalityDescription, bool adopted)
        {
            try
            {
                Task<AnimalDomain> animal = _repository.AddAnimalAsync(
                    name,
                    family,
                    species,
                    subspecies,
                    age,
                    gender,
                    weight,
                    height,
                    length,
                    neutered,
                    vaccinated,
                    microchipped,
                    trained,
                    socialized,
                    healthIssues,
                      picture,
                    personalityDescription,
                    adopted
                );

                return animal;
            }
            catch (Exception ex)
            {
                
                throw new Exception($"Failed to add animal: {ex.Message}");
            }
        }     
        async Task<bool> IService.CreateReturnedAnimalAsync(int adoptionCode, int animalId, int adopterId, DateTime returnDate, string returnReason)
        {
            await _repository.CreateReturnedAnimalAsync(adoptionCode, animalId, adopterId, returnDate, returnReason);
            return true;
        }
        async Task<bool> IService.CreateAdoptedAsync(int animalId, int adopterId, DateTime adoptionDate)
        {
            await _repository.CreateAdoptedAsync(animalId, adopterId, adoptionDate);
            return true;
        }

        //add novo
        //-----------------------------------------------------------------------------------------------
        async Task IService.AddAnimalRecord(int idAnimal)
        {          
            try
            {
                await _repository.AddAnimalRecord(idAnimal);             
            }
            catch (Exception ex)
            {             
                throw new Exception($"Failed to add record service message: {ex.Message}");
            }          
        }
        async  Task IService.AddFoundRecord(int animalId, DateTime date, string adress, string description, string ownerName, string ownerSurname, string ownerPhoneNumber, string ownerOIB, string registerId)
        {
            try
            {
                await _repository.AddFoundRecord( animalId,  date,  adress,  description,  ownerName,  ownerSurname,  ownerPhoneNumber,  ownerOIB,  registerId);
            }
            catch (Exception ex)
            {        
                throw new Exception($"Failed to add found animal service message: {ex.Message}");
            }
        }
        async Task IService.AddFood(string brandName, string name, string foodType, string animalType, string ageGroup, decimal weight, decimal caloriesPerServing, decimal weightPerServing, string measurementPerServing, decimal fatContent, decimal fiberContent, DateTime exporationDate, int quantity, string notes, string measurementWeight)
        {
            await _repository.AddFood(brandName, name, foodType, animalType, ageGroup, weight, caloriesPerServing, weightPerServing, measurementPerServing, fatContent, fiberContent, exporationDate, quantity, notes, measurementWeight);
        }
        async Task IService.AddToys(string brandName, string name, string animalType, string toyType, string ageGroup, decimal hight, decimal width, int quantity, string notes)
       {
            await _repository.AddToys(brandName, name, animalType, toyType, ageGroup, hight, width, quantity, notes);
       }
        async Task IService.AddNews(string name, string description, DateTime dateTime)
        {
            await _repository.AddNews( name,  description,  dateTime);
        }
        async   Task IService.AddVetVsit(int animalId, DateTime startTime, DateTime endTime, string typeOfVisit, string notes)
        {
            try
            {
                await _repository.AddVetVsit( animalId,  startTime,  endTime,  typeOfVisit,  notes)
    ;

            }
            catch (Exception ex)
            {
             
                throw new Exception($"Failed to add found animal service message: {ex.Message}");
            }
        }
        async Task IService.AddSystemRecord(int recordNumber, string recordName, string recordDescription)
        {
            await _repository.AddSystemRecord( recordNumber,  recordName,  recordDescription);
        }
        async Task IService.AddMedicines(int animalId, string nameOfMedicines, string descriptio, string vetUsername, decimal amountOfMedicine, string mesurmentUnit, int medicationIntake, string frequencyOfMedicationUse, bool usage)
        {
            await _repository.AddMedicines( animalId,  nameOfMedicines,  descriptio,  vetUsername,  amountOfMedicine,  mesurmentUnit,  medicationIntake,  frequencyOfMedicationUse,  usage);
        }
        async Task IService.AddFunds(int adopterId, decimal amount, string purpose)
        {
            await _repository.AddFunds( adopterId,  amount,  purpose);

        }
        async  Task IService.AddEuthanasia(int animalId, DateTime date, string nameOfDesissse, bool complited)
        {
            await _repository.AddEuthanasia( animalId,  date,  nameOfDesissse,  complited);
        }
        async  Task IService.AddContageus(int animalId, string desisseName, DateTime startTime, string description, bool contageus)
        {
            await _repository.AddContageus(animalId, desisseName, startTime, description, contageus);
        }
        async   Task IService.AddContact(string name, string email, string description, int adopterId)
        {
            await _repository.AddContact(name, email, description, adopterId);
        }
        async Task IService.AddBalans(string iban, string password, string type)
        {
            await _repository.AddBalans(iban, password, type);
              
        }
        Task<LabsDomain> IService.AddLab(int animalId, DateTime date)
        {
            try
            {
                Task<LabsDomain> labs = _repository.AddLab(animalId, date);

                return labs;
            }
            catch (Exception ex)
            {

                throw new Exception($"Failed to add lab service: {ex.Message}");
            }
        }
        async Task IService.AddParametar(ParameterDomain parametar)
        {
            await _repository.AddParametar(parametar);
        }





        //Zasebne karakteristike životinja Update i Add
        async  Task IService.AddBirdAsync(BirdDomain birdDomain)
        {
           
                await _repository.AddBirdAsync(birdDomain);
           
        }
        async Task IService.AddMammalAsync(MammalDomain mammalDomain)
        {        
                await _repository.AddMammalAsync(mammalDomain);         
        }
        async Task IService.AddFishAsync(FishDomain fishDomain)
        {          
                await _repository.AddFishAsync(fishDomain);    
        }
        async Task IService.AddReptileAsync(ReptileDomain reptileDomain)
        {
                await _repository.AddReptileAsync(reptileDomain);
        }
        async Task IService.AddAmphibianAsync(AmphibianDomain amphibianDomain)
        {
                await _repository.AddAmphibianAsync(amphibianDomain);
        }
        async Task<bool> IService.UpdateBird(BirdDomain animal)
        {
            try
            {
                await _repository.UpdateBird(animal);
                return true;
            }
            catch { return false; }
        }
        async Task<bool> IService.UpdateMammal(MammalDomain animal)
        {
            try
            {
                await _repository.UpdateMammal(animal);
                return true;
            }
            catch { return false; }
        }
        async Task<bool> IService.UpdateFish(FishDomain animal)
        {
            try
            {
                await _repository.UpdateFish(animal);
                return true;
            }
            catch { return false; }
        }
        async Task<bool> IService.UpdateReptile(ReptileDomain animal)
        {
            try
            {
                await _repository.UpdateReptile(animal);
                return true;
            }
            catch { return false; }
        }
        async Task<bool> IService.UpdateAmphibian(AmphibianDomain animal)
        {
            try
            {
                await _repository.UpdateAmphibian(animal);
                return true;
            }
            catch { return false; }
        }     




        //DELETE
        async Task IService.DeleteNews(int id)
        {
            await _repository.DeleteNews(id);
           
          
        }
        async Task<bool> IService.DeleteAdoptedAsync(int adoptedId)
        {
            await _repository.DeleteAdoptedAsync(adoptedId);
            return true;
        }      
        public  void DeleteAdoptedReturn(int adoptedId)
        {
             _repository.DeleteAdoptedReturn(adoptedId);
            
        }   
        public async Task DeleteAnimal(int idAnimal)
        {
            try
            {
                // Ensure that the idAnimal is valid (Optional)
                if (idAnimal <= 0)
                {
                    throw new ArgumentException("Invalid animal ID.");
                }

                // Delegate to the repository's DeleteAnimal method
                await _repository.DeleteAnimal(idAnimal);
            }
            catch (Exception ex)
            {
                // Log the exception (replace Console.WriteLine with proper logging)
                Console.WriteLine($"Error deleting animal with ID {idAnimal}: {ex.Message}");

                // Optionally, rethrow the exception if it needs to be handled at a higher level
                throw;
            }
        }

       
    }
}
