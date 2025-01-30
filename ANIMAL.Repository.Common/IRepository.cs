
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
        public Task<AnimalRecordDomain> UpdateAnimalRecordDomain(AnimalRecordDomain update);
        public Task<BalansDomain> UpdateAnimalBalansDomain(BalansDomain update);
        public Task<ContactDomain> UpdateContactDomain(ContactDomain update);
        public Task<ContageusAnimalsDomain> UpdateContageusAnimalsDomain(ContageusAnimalsDomain update);
        public Task<EuthanasiaDomain> UpdateEuthanasiaDomain(EuthanasiaDomain update);
        public Task<FoodDomain> UpdateFoodDomain(FoodDomain update);
        public Task<FoundRecordDomain> UpdateFoundRecordDomain(FoundRecordDomain update);
        public Task<FundsDomain> UpdateFundsDomain(FundsDomain update);
        public Task<LabsDomain> UpdateLabsDomain(LabsDomain update);
        public Task<MedicinesDomain> UpdateMedicinesDomain(MedicinesDomain update);
        public Task<NewsDomain> UpdateNewsDomain(NewsDomain update);
        public Task<ParameterDomain> UpdateParameterDomain(ParameterDomain update);
        public Task<SystemRecordDomain> UpdateSystemRecordDomain(SystemRecordDomain update);
        public Task<ToysDomain> UpdateToysDomain(ToysDomain update);
        public Task<VetVisitsDomain> UpdateVetVisitsDomain(VetVisitsDomain update);









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
        public  Task DeleteAnimal(int idAnimal);

        //novo
        public Task DeleteNews(int id);
        public Task DeleteContageusAnimals(int id);
        public Task DeleteEuthanasia(int id);
        //pogledaj  druge klase i napravi da se podatak sakrije ako se to stanje više ne dešava

    }
}
