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
        public IEnumerable<ParameterDomain> GetAllParameterDomain();
        public IEnumerable<SystemRecordDomain> GetAllSystemRecordDomain();
        public IEnumerable<ToysDomain> GetAllToysDomain();
        public IEnumerable<VetVisitsDomain> GetAllVetVisitsDomain();





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

        //ADD
        public Task<AdopterDomain> CreateAdopterAsync(string firstName, string lastName, DateTime dateOfBirth, string residence, string username, string password, string registerId);
     
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
        bool adopted)
        ;
         public Task<bool> CreateReturnedAnimalAsync( int adoptionCode, int animalId, int adopterId, DateTime returnDate, string returnReason);
         public  Task<bool> CreateAdoptedAsync(int animalId, int adopterId, DateTime adoptionDate);
         public Task<bool> AddBirdAsync(BirdDomain birdDomain);
         public Task<bool> AddMammalAsync(MammalDomain mammalDomain);
         public Task<bool> AddFishAsync(FishDomain fishDomain);
         public Task<bool> AddReptileAsync(ReptileDomain reptileDomain);
         public Task<bool> AddAmphibianAsync(AmphibianDomain amphibianDomain);
     

        //UPDATE
        public Task IncrementNumberOfAdoptedAnimalsAsync(string registerId);
        public Task IncrementNumberOfReturnedAnimalsAsync(string registerId);
        public Task<AdopterDomain> UpdateAdopterAsync(string registerId, string firstName, string lastName, DateTime dateOfBirth, string residence, string username, string password);
        public Task<AnimalDomain> UpdateAnimalAsync(int idAnimal, int age, decimal weight, decimal height, decimal length, bool neutered, bool vaccinated, bool microchipped, bool trained, bool socialized, string healthIssues, string personalityDescription);
        public Task<BirdDomain> UpdateBird(BirdDomain bird);
        public  Task<bool> AdoptionStatus(int animalId);
        public Task<bool> UpdateAdopterFlag(int adopterId);
        public  Task<bool> AdoptionStatusFalse(int animalId);
      

     


        //DELETE
        public  Task<bool> DeleteAdoptedAsync(int adoptedId);
        public  void DeleteAdoptedReturn(int adoptedId); 
        public  Task DeleteAnimal(int idAnimal);

    }
}
