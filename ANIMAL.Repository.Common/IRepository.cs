
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
        //izbacuje sve životinje koje su bileposvojene umjesto one koja je trenutno
        IEnumerable<AnimalDomain> GetAllAnimalDomainAdopt();
        IEnumerable<AnimalDomain> GetAllAnimalDomainUserAdopt();
        IEnumerable<AnimalDomain> GetAllAnimalDomainSocial();
        IEnumerable<AdopterDomain> GetAllAdopterDomain();
        IEnumerable<ReturnedAnimalDomain> GetAllReturnedAnimalDomain();
        public IEnumerable<AnimalDomain> GetAllAnimalDomainNoPicture();     
        IEnumerable<AdoptedDomain> GetAllAdoptedDomain();
        IEnumerable<AnimalDomain> GetAllAnimalVetDomain();

         //novo
        public IEnumerable<AnimalRecordDomain> GetAllAnimalRecordDomain();
        public IEnumerable<BalansDomain> GetAllBlansDomain();
        public IEnumerable<ContactDomain>GetaAllContactDomain();
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
        //   public MammalDomain GetOne(int id);
        public AdoptedDomain GetOneAdoptedAnimal(int adoptionCode);
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
        public AdopterDomain GetAdopterByIdNumber(int id);
        //get by id novo
        //ispisuje se kad u tablici sa tim parametrima kliknemo na jedan
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
        public MedicinesDomain GetOneMedicinesAnimal(int id);
        public ContageusAnimalsDomain GetOneContageusAnimal(int id);
        public LabsDomain GetOneLabsAnimal(int id);
        public VetVisitsDomain GetOneVetVisitAnimal(int id);
        public AnimalRecordDomain GetOneAnimalRecord(int id);
        public AdopterDomain GetAdopterByIdInt(int id);



        //UPDATE ne radi edit za životinje
        public Task IncrementNumberOfAdoptedAnimalsAsync(string registerId);
        public  Task IncrementNumberOfReturnedAnimalsAsync(string registerId);
        public  Task<AdopterDomain> UpdateAdopterAsync(string registerId, string firstName, string lastName, DateTime dateOfBirth, string residence, string username, string password);
        public  Task<AnimalDomain> UpdateAnimalAsync(int idAnimal, int age, decimal weight, decimal height, decimal length, bool neutered, bool vaccinated, bool microchipped, bool trained, bool socialized, string healthIssues, string personalityDescription);     
        public Task<bool> UpdateAdopterFlag(int adopterId);
        public  Task<bool> AdoptionStatus(int animalId);
        public Task<bool> AdoptionStatusFalse(int animalId);


        //update novo
        // 15 novih tablica  15/15
        /*1.animalrecord-                             --RADI 
         *2. Balans-                                  --RADI
         * 3.Contact-                                 -NE TREBA                                            
         * 4.contageus animals-                       --RADI
         * 5 euthanasia-                              --RADI
         * 6.found record-                            --RADI                                      - NE SMIJEŠ POSLAT KRIVI REGISTER ID
         * 7.funds-                                   --NE TREBA- nemože osoba mjenjat količinu nocaca koje je poslala
         * 8.labs-                                    --NE TREBA                                    
         * 9.parametar-                               --RADI                                           
         * 10.medicines-                              --RADI
         * 11.news-                                   --RADI
         * 12.system record-                          --NE TREBA
         * 13.toys-                                   --RADI
         * 14.food-                                   --RADI
         * 15.vet visit-                              --RADI
        */
        //
        public Task<int> UpdateAnimalRecordDomain(int id, int recordId);
        public  Task<bool> UpdateAnimalBalansDomain(int id, decimal balance);
        public  Task<bool> UpdateContageusAnimalsDomain(int id);
        public  Task<bool> UpdateEuthanasiaDomain(int id, DateTime date);
        public Task<bool> UpdateEuthanasiaDomainDone(int id,  bool complited);
        public  Task<bool> UpdateFoodDomainIncrement(int id);
        public  Task<bool> UpdateFoodDomainDecrement(int id );
        public Task<bool> UpdateFoodDomain(FoodDomain food);
        public Task<bool> UpdateToysDomainIncrement(int id);
        public Task<bool> UpdateToysDomainDecrement(int id);
        public Task<bool> UpdateToysDomain(ToysDomain toy);
        public Task<bool> UpdateFoundRecordDomain(int id, int animalId, DateTime date, string adress, string description, string ownerName, string ownerSurname, string ownerPhoneNumber, string ownerOIB, string registerId);
        public  Task<bool> UpdateMedicinesDomainUsage(int id, bool usage);
        public Task<bool> UpdateMedicinesDomain(int id, decimal amountOfMedicine, string mesurmentUnit, int medicationIntake, string frequencyOfMedicationUse);
        public Task<bool> UpdateNewsDomain(int id, string name, string description, DateTime dateTime, byte[] picture);
        public Task<bool> UpdateVetVisitsDomain(int id, DateTime startTime, DateTime endTime, string notes);
        public Task<bool> UpdateContactDomain(int id);
        public Task<bool> UpdateParametar(ParameterDomain p);







        //DODAVANJE
        public Task<bool> CreateReturnedAnimalAsync( int adoptionCode, int animalId, int adopterId,  string returnReason);
        //nakon ovoga i dalje vidimživotinju u ponudi za posvajanje
        public  Task<bool> CreateAdoptedAsync(int animalId, int adopterId, DateTime adoptionDate);    
        public  Task<AdopterDomain> CreateAdopterAsync(string firstName, string lastName, DateTime dateOfBirth, string residence, string username, string password, string registerId);   
        Task<AnimalDomain> AddAnimalAsync(int idAnimal, string name, string family,  string species,  string subspecies,  int age, string gender, decimal weight, decimal height, decimal length,      bool neutered, bool vaccinated,   bool microchipped,   bool trained,  bool socialized,   string healthIssues,   byte[] picture, string personalityDescription, bool adopted);




        //dodavanje novo 15 novih tablica 15/15
        /*1.animalrecord- samo za dodavanje prve                   --RADI                                                   
         *2. Balans-mislim da ne treba add samo update.            --RADI
         * 3.Contact-potreban add i update za pročitano            --RADI
         * 4.contageus animals-potrebno add                        --RADI
         * 5 euthanasia-potreban add                               --RADI
         * 6.found record- potreban add                            --RADI
         * 7.funds-potreban add                                    --RADI
         * 8.labs-potreban add                                     --RADI
         * 9.parametar-potreban add                                --RADI
         * 10.medicines-potreban add                               --RADI
         * 11.news-potreban add                                    --RADI
         * 12.system record- potreban add samo admin               --RADI
         * 13.toys-potreban add                                    --RADI
         * 14.food-add                                             --RADI
         * 15.vet visit-potreban add                               --RADI
         * 16.Transactions
        */

        //Ovo oboje treba kad se životinja dodaje
        public Task AddAnimalRecord(int idAnimal);
        public Task AddFoundRecord( int animalId, DateTime date, string adress, string description, string ownerName, string ownerSurname, string ownerPhoneNumber, string ownerOIB, string registerId);//RADI
        public Task AddFood(string brandName, string name, string foodType, string animalType, string ageGroup, decimal weight, decimal caloriesPerServing, decimal weightPerServing, string measurementPerServing, decimal fatContent, decimal fiberContent, DateTime exporationDate, int quantity, string notes, string measurementWeight, decimal price);
        public Task AddToys(string brandName, string name, string animalType, string toyType, string ageGroup, decimal hight, decimal width, int quantity, string notes, decimal price);
        public Task AddNews(string name, string description, DateTime dateTime, byte[] picture);
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








        //Brisanje
        public  Task<bool> DeleteAdoptedAsync(int adoptedId);
        public void DeleteAdoptedReturn(int adoptedId);
        public  Task DeleteAnimal(int idAnimal);// DA MAKNEM OVO POŠTO NEMA SMISLA VIŠE?

        //novo
        public Task DeleteNews(int id);
        //NIŠTA DRUGO SE NE SMIJE OBRISAT ZATO ŠTO NAM TREBA PPOVIJEST PODATAKA
        //pogledaj  druge klase i napravi da se podatak sakrije ako se to stanje više ne dešava

        //GLUPOSTI KOJE NE RADE ALI SU TREBALE OD PRIJE
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
    }
}
