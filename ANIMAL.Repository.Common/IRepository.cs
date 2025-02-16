﻿
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

        //get by id od životinje
        //napravi za ljekove, vet visit, animal record, contageus animals, labs
        //potrebno za ispis podatak povjest bolesti
        public MedicinesDomain GetOneMedicinesAnimal(int id);
        public ContageusAnimalsDomain GetOneContageusAnimal(int id);
        public LabsDomain GetOneLabsAnimal(int id);
        public VetVisitsDomain GetOneVetVisitAnimal(int id);
        public IEnumerable<AnimalRecordDomain> GetOneAnimalRecord(int id);//ne radi ništa se ne ispiše





        //UPDATE ne radi edit za životinje
        public Task IncrementNumberOfAdoptedAnimalsAsync(string registerId);
        public  Task IncrementNumberOfReturnedAnimalsAsync(string registerId);
        public  Task<AdopterDomain> UpdateAdopterAsync(string registerId, string firstName, string lastName, DateTime dateOfBirth, string residence, string username, string password);
        public  Task<AnimalDomain> UpdateAnimalAsync(int idAnimal, int age, decimal weight, decimal height, decimal length, bool neutered, bool vaccinated, bool microchipped, bool trained, bool socialized, string healthIssues, string personalityDescription);
        public  Task<BirdDomain> UpdateBird(BirdDomain bird);
        public Task<bool> UpdateAdopterFlag(int adopterId);
        public  Task<bool> AdoptionStatus(int animalId);
        public Task<bool> AdoptionStatusFalse(int animalId);


        //update novo
        public Task<bool> UpdateAnimalRecordDomain(int id, int recordId);
        public  Task<bool> UpdateAnimalBalansDomain(int id, decimal balance, DateTime lastUpdated, string password);
        public  Task<bool> UpdateContageusAnimalsDomain(int id, bool contageus);

        public  Task<bool> UpdateEuthanasiaDomain(int id, DateTime date, bool complited);
        public  Task<bool> UpdateFoodDomainIncrement(int id);//3
        public  Task<bool> UpdateFoodDomainDecrement(int id );
        public Task<bool> UpdateFoodDomain(int id, string brandName, string name, string foodType, string animalType, string ageGroup, decimal weight, decimal caloriesPerServing, decimal weightPerServing, string measurementPerServing, decimal fatContent, decimal fiberContent, DateTime exporationDate, int quantity, string notes, string measurementWeight);

        public Task<bool> UpdateToysDomainIncrement(int id);
        public Task<bool> UpdateToysDomainDecrement(int id);
        public Task<bool> UpdateToysDomain(int id, string brandName, string name, string animalType, string toyType, string ageGroup, decimal hight, decimal width, int quantity, string notes);


        public Task<bool> UpdateFoundRecordDomain(int id, int animalId, DateTime date, string adress, string description, string ownerName, string ownerSurname, string ownerPhoneNumber, string ownerOIB, string registerId);



        public  Task<bool> UpdateLabsDomain(int id, List<Parameter> parameters);


        public  Task<bool> UpdateMedicinesDomainUsage(int id, bool usage);
        public Task<bool> UpdateMedicinesDomain(int id, decimal amountOfMedicine, string mesurmentUnit, int medicationIntake, string frequencyOfMedicationUse);


        public Task<bool> UpdateNewsDomain(int id, string name, string description, DateTime dateTime);



        public Task<bool> UpdateVetVisitsDomain(int id, DateTime startTime, DateTime endTime, string notes);









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

        //dodavanje novo
        /*animalrecord- samo za dodavanje prve funkcije koja se pokreće samo kod unosa životinje, sve ostalo je update
         * Balans-mislim da ne treba add samo update. Stvorila bih jedan račun i na njemu ddavala i uzimala- Ako dodam još neku osobu koja će se bavit sa time dodat ću i add
         * Contact-potreban add i update za pročitano
         * contageus animals-potrebno add
         * euthanasia-potreban add
         * found record- potreban add
         * funds-potreban add
         * labs-potreban add
         * parametar-potreban add 
         * medicines-potreban add
         * news-potreban add
         * system record- potreban add samo admin
         * toys-potreban add
         * vet visit-potreban add
        */








        //Brisanje
        public  Task<bool> DeleteAdoptedAsync(int adoptedId);
        public void DeleteAdoptedReturn(int adoptedId);
        public  Task DeleteAnimal(int idAnimal);// DA MAKNEM OVO POŠTO NEMA SMISLA VIŠE?

        //novo
        public Task DeleteNews(int id);
        //NIŠTA DRUGO SE NE SMIJE OBRISAT ZATO ŠT NAM TREBA PPOVIJEST PODATAKA
        //pogledaj  druge klase i napravi da se podatak sakrije ako se to stanje više ne dešava

    }
}
