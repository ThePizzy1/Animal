using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ANIMAL.DAL.DataModel;
using ANIMAL.MODEL;
namespace ANIMAL.Service.Common
{
    public  interface IService
    {
    
        //GET ALL
        IEnumerable<AnimalDomain> GetAllAnimalDomain();
        IEnumerable<AnimalDomain> GetAllAnimalDomainAdopt();
        IEnumerable<AdopterDomain> GetAllAdopterDomain(); 
        IEnumerable<AdoptedDomain> GetAllAdoptedDomain();
        IEnumerable<ReturnedAnimalDomain> GetAllReturnedAnimalDomain();
        public IEnumerable<AnimalDomain> GetAllAnimalDomainNoPicture();


        //novo
        public IEnumerable<AnimalRecordDomain> GetAllAnimalRecordDomain();
        public IEnumerable<BalansDomain> GetAllBlansDomain();
        public IEnumerable<ContactDomain> GetaAllContactDomain();
        public IEnumerable<ContageusAnimalsDomain> GetAllContageusAnimalsDomain();
        public IEnumerable<EuthanasiaDomain> GetAllEuthanasiaDomain();
        public IEnumerable<FoodDomain> GetAllFoodDomain();
        public IEnumerable<FoundRecordDomain> GetAllFoundRecord();
        public IEnumerable<FundsDomain> GetAllFundsDomain();
        public IEnumerable<LabsDomain> GetAllLabsDomain();
        public IEnumerable<MedicinesDomain> GetAllMedicinesDomain();
        public IEnumerable<NewsDomain> GetAllNewsDomain();
        public IEnumerable<ParameterDomain> GetAllParameterDomain(int id);
        public IEnumerable<SystemRecordDomain> GetAllSystemRecordDomain();
        public IEnumerable<ToysDomain> GetAllToysDomain();
        public IEnumerable<VetVisitsDomain> GetAllVetVisitsDomain();

        public IEnumerable<TransactionsDomain> GetAllTransactionsDomain();



        //GET BY ID
        public MammalDomain GetAllMammalDomain(int id);
        public BirdDomain GetAllBirdDomain(int id);
        public AmphibianDomain GetAllAmphibianDomain(int id);
        public ReptileDomain GetAllReptileDomain(int id);
        public FishDomain GetAllFishDomain(int id);      
        public AnimalDomain GetAnimalById(int animalId);
        public AnimalDomain GetAllAnimalById(int animalId);
        public AdopterDomain GetAdopterByUsername(string username);
        public AdopterDomain GetAdopterById(string id);
        public IEnumerable<AdoptedDomain> GetAllAdoptedDomainForAdopter(int adopterId);
         public IEnumerable<ReturnedAnimalDomain> GetAllReturnedAnimalsForAdopter(int adopterId);

        //get by id novo

        public ToysDomain GetOneToysDomain(int id);
        public NewsDomain GetOneNewsDomain(int id);
        public MedicinesDomain GetOneMedicinesDomain(int id);
        public LabsDomain GetOneLabsDomain(int id);
        public FundsDomain GetOneFundsDomain(int id);
        public FoundRecordDomain GetOneFoundRecordDomain(int id);
        public FoodDomain GetOneFoodDomain(int id);
        public EuthanasiaDomain GetOneEuthanasiaDomain(int id);
        public ContageusAnimalsDomain GetOneContageusAnimalsDomain(int id);
        public ContactDomain GetOneContactDomain(int id);
        public BalansDomain GetOneBalansDomain(int id);

        //get by id novo novo

        public AdopterDomain GetAdopterByIdInt(int id);
        public MedicinesDomain GetOneMedicinesAnimal(int id);
        public ContageusAnimalsDomain GetOneContageusAnimal(int id);
        public LabsDomain GetOneLabsAnimal(int id);
        public VetVisitsDomain GetOneVetVisitAnimal(int id);
        public AnimalRecordDomain GetOneAnimalRecord(int id);









        //UPDATE
        public Task IncrementNumberOfAdoptedAnimalsAsync(string registerId);
        public Task IncrementNumberOfReturnedAnimalsAsync(string registerId);
        public Task<AdopterDomain> UpdateAdopterAsync(string registerId, string firstName, string lastName, DateTime dateOfBirth, string residence, string username, string password);
        public Task<AnimalDomain> UpdateAnimalAsync(int idAnimal, int age, decimal weight, decimal height, decimal length, bool neutered, bool vaccinated, bool microchipped, bool trained, bool socialized, string healthIssues, string personalityDescription);
        public Task<bool> AdoptionStatus(int animalId);
        public Task<bool> UpdateAdopterFlag(int adopterId);
        public Task<bool> AdoptionStatusFalse(int animalId);











        //novo
        public Task UpdateAnimalRecordDomain(int id, int recordId);
        public Task<bool> UpdateAnimalBalansDomain(int id, decimal balance);
        public Task<bool> UpdateContageusAnimalsDomain(int id, bool contageus);
        public Task<bool> UpdateEuthanasiaDomain(int id, DateTime date, bool complited);
        public Task<bool> UpdateFoodDomainIncrement(int id);
        public Task<bool> UpdateFoodDomainDecrement(int id);
        public Task<bool> UpdateFoodDomain(FoodDomain food);
        public Task<bool> UpdateToysDomainIncrement(int id);
        public Task<bool> UpdateToysDomainDecrement(int id);
        public Task<bool> UpdateToysDomain(ToysDomain toy);
        public Task<bool> UpdateFoundRecordDomain(int id, int animalId, DateTime date, string adress, string description, string ownerName, string ownerSurname, string ownerPhoneNumber, string ownerOIB, string registerId);
        public Task<bool> UpdateMedicinesDomainUsage(int id, bool usage);
        public Task<bool> UpdateMedicinesDomain(int id, decimal amountOfMedicine, string mesurmentUnit, int medicationIntake, string frequencyOfMedicationUse);
        public Task<bool> UpdateNewsDomain(int id, string name, string description, DateTime dateTime);
        public Task<bool> UpdateVetVisitsDomain(int id, DateTime startTime, DateTime endTime, string notes);
        public Task<bool> UpdateContactDomain(int id);
        public Task<bool> UpdateParametar(ParameterDomain p);








        //ADD
        public Task<AdopterDomain> CreateAdopterAsync(string firstName, string lastName, DateTime dateOfBirth, string residence, string username, string password, string registerId);    
        Task<AnimalDomain> AddAnimalAsync(
        string name,
        string family,
        string species,
        string subspecies,
        int age,
        string gender,
        decimal weight,
        decimal height,
        decimal length,
        bool neutered,
        bool vaccinated,
        bool microchipped,
        bool trained,
        bool socialized,
        string healthIssues,
        byte[] picture,
        string personalityDescription,
        bool adopted)
        ;
         public Task<bool> CreateReturnedAnimalAsync( int adoptionCode, int animalId, int adopterId, string returnReason);
         public  Task<bool> CreateAdoptedAsync(int animalId, int adopterId, DateTime adoptionDate);
        //novo
        public Task AddAnimalRecord(int idAnimal);
        public Task AddFoundRecord(int animalId, DateTime date, string adress, string description, string ownerName, string ownerSurname, string ownerPhoneNumber, string ownerOIB, string registerId);
        public Task AddFood(string brandName, string name, string foodType, string animalType, string ageGroup, decimal weight, decimal caloriesPerServing, decimal weightPerServing, string measurementPerServing, decimal fatContent, decimal fiberContent, DateTime exporationDate, int quantity, string notes, string measurementWeight);
        public Task AddToys(string brandName, string name, string animalType, string toyType, string ageGroup, decimal hight, decimal width, int quantity, string notes);
        public Task AddNews(string name, string description, DateTime dateTime);
        public Task AddVetVsit(int animalId, DateTime startTime, DateTime endTime, string typeOfVisit, string notes);
        public Task AddSystemRecord(int recordNumber, string recordName, string recordDescription);
        public Task AddMedicines(int animalId, string nameOfMedicines, string descriptio, string vetUsername, decimal amountOfMedicine, string mesurmentUnit, int medicationIntake, string frequencyOfMedicationUse, bool usage);
        public Task AddFunds(int adopterId, decimal amount, string purpose, string iban);
        public Task AddEuthanasia(int animalId, DateTime date, string nameOfDesissse, bool complited);
        public Task AddContageus(int animalId, string desisseName, DateTime startTime, string description, bool contageus);
        public Task AddContact(string name, string email, string description, int adopterId);
        public Task AddBalans(string iban, string password, string type);
        public Task<LabsDomain> AddLab(int animalId, DateTime date);
        public Task AddParametar(ParameterDomain parametar);

        public Task AddTransactions(TransactionsDomain transactions);


        //Zasebne karakteristike životinja UPDATE I ADD
        public Task AddBirdAsync(BirdDomain birdDomain);
        public Task AddMammalAsync(MammalDomain mammalDomain);
        public Task AddFishAsync(FishDomain fishDomain);
        public Task AddReptileAsync(ReptileDomain reptileDomain);
        public Task AddAmphibianAsync(AmphibianDomain amphibianDomain);
        public Task<bool> UpdateBird(BirdDomain animal);
        public Task<bool> UpdateMammal(MammalDomain animal);
        public Task<bool> UpdateFish(FishDomain animal);
        public Task<bool> UpdateReptile(ReptileDomain animal);
        public Task<bool> UpdateAmphibian(AmphibianDomain animal);














        //DELETE
        public Task<bool> DeleteAdoptedAsync(int adoptedId);//ovo se ne koristi
        public  void DeleteAdoptedReturn(int adoptedId); //ovo se ne koristi
        public  Task DeleteAnimal(int idAnimal);//ovo se ne koristi
        public Task DeleteNews(int id);

    }
}
