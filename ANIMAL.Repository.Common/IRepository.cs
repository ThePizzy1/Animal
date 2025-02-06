
using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using ANIMAL.DAL.DataModel;
using ANIMAL.MODEL;
namespace ANIMAL.Repository.Common
{
  public   interface IRepository { 
     
        //GET ALL     
        // public IEnumerable<AnimalDomain> ();
        IEnumerable<AnimalDomain> GetAllAnimalDomain();
        IEnumerable<AnimalDomain> GetAllAnimalDomainAdopt();
        IEnumerable<AdopterDomain> GetAllAdopterDomain();
        IEnumerable<ReturnedAnimalDomain> GetAllReturnedAnimalDomain();
        public IEnumerable<AnimalDomain> GetAllAnimalDomainNoPicture();
      
        IEnumerable<AdoptedDomain> GetAllAdoptedDomain();
   //novo
        public IEnumerable<AnimalRecordDomain> GetAllAnimalRecordDomain();
        public IEnumerable<BalansDomain> GetAllBlansDomain();//1
        public IEnumerable<ContactDomain>GetaAllContactDomain();//1
        public IEnumerable<ContageusAnimalsDomain> GetAllContageusAnimalsDomain();//1
        public IEnumerable<EuthanasiaDomain> GetAllEuthanasiaDomain();//1
        public IEnumerable<FoodDomain> GetAllFoodDomain();//1
        public IEnumerable<FoundRecordDomain> GetAllFoundRecord();//1
        public IEnumerable<FundsDomain> GetAllFundsDomain();//1
        public IEnumerable<LabsDomain> GetAllLabsDomain();//1
        public IEnumerable<MedicinesDomain> GetAllMedicinesDomain();//1
        public IEnumerable<NewsDomain> GetAllNewsDomain();//1
        public IEnumerable<ParameterDomain> GetAllParameterDomain();
        public IEnumerable<SystemRecordDomain> GetAllSystemRecordDomain();
        public IEnumerable<ToysDomain> GetAllToysDomain();//1
        public IEnumerable<VetVisitsDomain> GetAllVetVisitsDomain();






        //GET BY ID
        //   public MammalDomain GetOne(int id);
        public IEnumerable<ReturnedAnimalDomain> GetAllReturnedAnimalsForAdopter(int adopterId);
        public IEnumerable<AdoptedDomain> GetAllAdoptedDomainForAdopter(int adopterId); 
        public MammalDomain GetAllMammalDomain(int id);
        public BirdDomain GetAllBirdDomain(int id);
        public AmphibianDomain GetAllAmphibianDomain(int id);
        public ReptileDomain GetAllReptileDomain(int id);
        public FishDomain GetAllFishDomain(int id);
        public AnimalDomain GetAnimalById(int animalId);
        public AnimalDomain GetAllAnimalById(int animalId);
        public AdopterDomain GetAdopterByUsername(string username);
        public AdopterDomain GetAdopterById(string id);

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


        //UPDATE ne radi edit za životinje
        public  Task IncrementNumberOfAdoptedAnimalsAsync(string registerId);
        public  Task IncrementNumberOfReturnedAnimalsAsync(string registerId);
        public  Task<AdopterDomain> UpdateAdopterAsync(string registerId, string firstName, string lastName, DateTime dateOfBirth, string residence, string username, string password);
        public  Task<AnimalDomain> UpdateAnimalAsync(int idAnimal, int age, decimal weight, decimal height, decimal length, bool neutered, bool vaccinated, bool microchipped, bool trained, bool socialized, string healthIssues, string personalityDescription);
        public  Task<BirdDomain> UpdateBird(BirdDomain bird);
        public Task<bool> UpdateAdopterFlag(int adopterId);
        public  Task<bool> AdoptionStatus(int animalId);
        public Task<bool> AdoptionStatusFalse(int animalId);


        //update novo
        public Task<AnimalRecordDomain> UpdateAnimalRecordDomain(int id, int recordId);
        public Task<BalansDomain> UpdateAnimalBalansDomain(int id, decimal balance, DateTime lastUpdated, string password);
        public Task<ContageusAnimalsDomain> UpdateContageusAnimalsDomain(int id, bool contageus);

        public Task<EuthanasiaDomain> UpdateEuthanasiaDomain(int id, DateTime date, bool complited);
        public Task<FoodDomain> UpdateFoodDomainIncrement(int id, int quantity);//3
        public Task<FoodDomain> UpdateFoodDomainDecrement(int id, int quantity);
        public Task<FoodDomain> UpdateFoodDomain(int id, string brandName, string name, string foodType, string animalType, string ageGroup, decimal weight, decimal caloriesPerServing, decimal weightPerServing, string measurementPerServing, decimal fatContent, decimal fiberContent, DateTime exporationDate, int quantity, string notes, string measurementWeight);

       public Task<ToysDomain> UpdateToysDomainIncrement(int id, int quantity);
        public Task<ToysDomain> UpdateToysDomainDecrement(int id, int quantity);
        public Task<ToysDomain> UpdateToysDomain(int id, string brandName, string name, string animalType, string toyType, string ageGroup, decimal hight, decimal width, int quantity, string notes);


        public Task<FoundRecordDomain> UpdateFoundRecordDomain(int id, int animalId, DateTime date, string adress, string description, string ownerName, string ownerSurname, string ownerPhoneNumber, string ownerOIB, string registerId);
     


        public Task<LabsDomain> UpdateLabsDomain(int id, List<Parameter> parameters);


        public Task<MedicinesDomain> UpdateMedicinesDomainUsage(int id, bool usage);
        public Task<MedicinesDomain> UpdateMedicinesDomain(int id, decimal amountOfMedicine, string mesurmentUnit, int medicationIntake, string frequencyOfMedicationUse);


        public Task<NewsDomain> UpdateNewsDomain(int id, string name, string description, DateTime dateTime);

 
    
        public Task<VetVisitsDomain> UpdateVetVisitsDomain(int id, DateTime startTime, DateTime endTime, string notes);









        //DODAVANJE
        public Task<bool> CreateReturnedAnimalAsync( int adoptionCode, int animalId, int adopterId, DateTime returnDate, string returnReason);
        public  Task<bool> CreateAdoptedAsync(int animalId, int adopterId, DateTime adoptionDate);
        public Task<bool> AddBirdAsync(BirdDomain birdDomain);
        public  Task<bool> AddMammalAsync(MammalDomain mammalDomain);
        public  Task<bool> AddFishAsync(FishDomain fishDomain);
        public  Task<bool> AddReptileAsync(ReptileDomain reptileDomain);
        public  Task<bool> AddAmphibianAsync(AmphibianDomain amphibianDomain);     
        public  Task<AdopterDomain> CreateAdopterAsync(string firstName, string lastName, DateTime dateOfBirth, string residence, string username, string password, string registerId);
        Task<bool> AddAnimalAsync(
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
          bool adopted
         );



        //Brisanje
        public  Task<bool> DeleteAdoptedAsync(int adoptedId);
        public void DeleteAdoptedReturn(int adoptedId);
        public  Task DeleteAnimal(int idAnimal);// DA MAKNEM OVO POŠTO NEMA SMISLA VIŠE?

        //novo
        public Task DeleteNews(int id);
        //NIŠTA DRGO SE NE SMIJE OBRISAT ZATO ŠT NAM TREBA PPOVIJEST PODATAKA
        //pogledaj  druge klase i napravi da se podatak sakrije ako se to stanje više ne dešava

    }
}
