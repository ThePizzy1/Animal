﻿using ANIMAL.DAL.DataModel;
using ANIMAL.MODEL;
using ANIMAL.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ANIMAL.Repository.Automaper;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Security.Policy;
using System.Xml.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace ANIMAL.Repository
{
    public class Repository : IRepository
    {
        private readonly AnimalRescueDbContext _appDbContext;
        private IRepositoryMappingService _mappingService;

        public object AdopterMapper { get; private set; }

        public Repository(AnimalRescueDbContext appDbContext, IRepositoryMappingService mapper)
        {
            _appDbContext = appDbContext;
            _mappingService = mapper;
        }
        //GET ALL
        public IEnumerable<AdoptedDomain> GetAllAdoptedDomain()
        {
            var adoptedEntities = _appDbContext.Adopted.ToList();
            var adoptedDomains = adoptedEntities.Select(a => new AdoptedDomain(a)).ToList();
            return adoptedDomains;
        }
        public IEnumerable<ReturnedAnimalDomain> GetAllReturnedAnimalDomain()
        {
            var returnedAnimalEntities = _appDbContext.ReturnedAnimal.ToList();
            var returnedAnimalDomains = returnedAnimalEntities.Select(r => new ReturnedAnimalDomain(r)).ToList();
            return returnedAnimalDomains;
        }
        public IEnumerable<AdopterDomain> GetAllAdopterDomain()
        {
            var adopterDb = _appDbContext.Adopter.ToList();
            var adopterDomain = adopterDb.Select(a => new AdopterDomain(
                a.Id,
                a.FirstName,
                a.LastName,
                a.DateOfBirth,
                a.Residence,
                a.Username,
                a.Password,
                a.NumAdoptedAnimals,
                a.NumReturnedAnimals,
                a.Flag,
                a.RegisterId
                )).ToList();

            return adopterDomain;
        }



        public AmphibianDomain GetAllAmphibianDomain(int id)
        {
            var amphibian= _appDbContext.Amphibians
                 .Join(_appDbContext.Animals, a => a.AnimalId, an => an.IdAnimal,
                 (a, an) => new { Amphibian = a, Animal = an })
                 .Where(x => x.Animal.IdAnimal == id )
                .Select(e => new AmphibianDomain(
                  
                    e.Amphibian.AnimalId,
                    e.Amphibian.Humidity,
                    e.Amphibian.Temperature))
                 .FirstOrDefault();

            return amphibian;
        }

        public IEnumerable<AnimalDomain> GetAllAnimalDomainAdopt()
        {
            var animalDb = _appDbContext.Animals
                .Where(a => !a.Adopted) // Filtriranje po usvojenim životinjama
                .ToList();

            var animalDomain = animalDb.Select(e => new AnimalDomain(
                e.IdAnimal,
                e.Name,
                e.Family,
                e.Species,
                e.Subspecies,
                e.Age,
                e.Gender,
                e.Weight,
                e.Height,
                e.Length,
                e.Neutered,
                e.Vaccinated,
                e.Microchipped,
                e.Trained,
                e.Socialized,
                e.HealthIssues,
                e.Picture,
                e.PersonalityDescription,
                e.Adopted));

            return animalDomain;
        }
        public IEnumerable<AnimalDomain> GetAllAnimalDomain()
        {
            var animalDb = _appDbContext.Animals.ToList();
            var animalDomain = animalDb.Select(e => new AnimalDomain(
                e.IdAnimal,
                e.Name,
                e.Family,
                e.Species,
                e.Subspecies,
                e.Age,
                e.Gender,
                e.Weight,
                e.Height,
                e.Length,
                e.Neutered,
                e.Vaccinated,
                e.Microchipped,
                e.Trained,
                e.Socialized,
                e.HealthIssues,
                e.Picture,
             
                e.PersonalityDescription,
                e.Adopted));

            return animalDomain;
        }
        public IEnumerable<AnimalDomain> GetAllAnimalDomainNoPicture()
        {
            var animalDb = _appDbContext.Animals.ToList();
            var animalDomain = animalDb.Select(e => new AnimalDomain(
                e.IdAnimal,
                e.Name,
                e.Family,
                e.Species,
                e.Subspecies,
                e.Age,
                e.Gender,
                e.Weight,
                e.Height,
                e.Length,
                e.Neutered,
                e.Vaccinated,
                e.Microchipped,
                e.Trained,
                e.Socialized,
                e.HealthIssues,
               

                e.PersonalityDescription,
                e.Adopted));

            return animalDomain;
        }
        //Get all novo
   

        IEnumerable<AnimalRecordDomain> IRepository.GetAllAnimalRecordDomain()
        {
           var animalDb=_appDbContext.AnimalRecord.ToList();
            var animalDmain = animalDb.Select(e => new AnimalRecordDomain(
              
                e.AnimalId,
                e.RecordId
                ));
            return animalDmain;
        }

        IEnumerable<BalansDomain> IRepository.GetAllBlansDomain()
        {
          var balansDb=_appDbContext.Balans.ToList();
            var balansDomain = balansDb.Select(e => new BalansDomain(
                e.Id,
                e.Iban,
                e.Balance,
                e.LastUpdated,
                e.Password,
                e.Type
                ));
            return balansDomain;
        }

        IEnumerable<ContactDomain> IRepository.GetaAllContactDomain()
        {
           var contentDb=_appDbContext.Contact.ToList();
            var contentDomain = contentDb.Select(e => new ContactDomain(
                e.Id,
                e.Name,
                e.Email,
                e.Description,
                e.AdopterId,
                e.Read
                ));
            return contentDomain;
        }

        IEnumerable<ContageusAnimalsDomain> IRepository.GetAllContageusAnimalsDomain()
        {
           var contageusAnimalsDb=_appDbContext.ContageusAnimals.ToList();
            var contageusAnimalsDomain = contageusAnimalsDb.Select(
                e=>new ContageusAnimalsDomain(
                    e.Id,
                    e.AnimalId,
                    e.DesisseName,
                    e.Description,
                    e.Contageus
                    ));
            return contageusAnimalsDomain;
        }
     
        IEnumerable<EuthanasiaDomain> IRepository.GetAllEuthanasiaDomain()
        {
            var euthanasiaDb=_appDbContext.Euthanasia.ToList();
            var euthanasiaDomain = euthanasiaDb.Select(e=>new EuthanasiaDomain(
                e.Id,
                e.AnimalId,
                e.Date,
                e.NameOfDesissse
                ));

            return euthanasiaDomain;
        }

        IEnumerable<FoodDomain> IRepository.GetAllFoodDomain()
        {
          var foodDb= _appDbContext.Food.ToList();
            var foodDomain = foodDb.Select(e=> new FoodDomain(
                e.Id,
                e.BrandName,
                e.Name,
                e.FoodType,
                e.AnimalType,
                e.AgeGroup,
                e.Weight,
                e.CaloriesPerServing,
                e.WeightPerServing,
                e.MeasurementPerServing,
                e.FatContent,
                e.FiberContent,
                e.ExporationDate,
                e.Quantity,
                e.Notes,
                e.MeasurementWeight
                ));

            return foodDomain;
        }

        IEnumerable<FoundRecordDomain> IRepository.GetAllFoundRecord()
        {
          var foundDb=_appDbContext.FoundRecord.ToList();
            var foundDomain = foundDb.Select(e => new FoundRecordDomain(
                e.Id,
                e.AnimalId,
                e.Date,
                e.Adress,
                e.Description,
                e.OwnerName,
                e.OwnerSurname,
                e.OwnerPhoneNumber,
                e.OwnerOIB,
                e.RegisterId
                ));
            return foundDomain;
        }

        IEnumerable<FundsDomain> IRepository.GetAllFundsDomain()
        {
            var fundDb=_appDbContext.Funds.ToList();
            var fundsDomain = fundDb.Select(
                e=> new FundsDomain(
                    e.Id,
                    e.AdopterId,
                    e.Amount,
                    e.Purpose,
                    e.DateTimed
                ));
            return fundsDomain;
        }

        IEnumerable<LabsDomain> IRepository.GetAllLabsDomain()
        {
            var labDb= _appDbContext.Labs.ToList();
            var labDomain = labDb.Select(e => new LabsDomain(
                e.Id,
                e.AnimalId,          
                e.DateTime
                
                ));
            return labDomain;
        }

        IEnumerable<MedicinesDomain> IRepository.GetAllMedicinesDomain()
        {
          var medicinesDb= _appDbContext.Medicines.ToList();
            var medicinesDomain = medicinesDb.Select(e=> new MedicinesDomain(
                e.Id,
                e.AnimalId,
                e.NameOfMedicines,
                e.Description,
                e.VetUsername,
                e.AmountOfMedicine,
                e.MesurmentUnit,
                e.MedicationIntake,
                e.FrequencyOfMedicationUse,
                e.Usage
                ));
            return medicinesDomain;
        }

        IEnumerable<NewsDomain> IRepository.GetAllNewsDomain()
        {
           var newsDb= _appDbContext.News.ToList();
            var newsDomain = newsDb.Select(e=> new NewsDomain(
                e.Id,
                e.Name,
                e.Description,
                e.DateTime
                ));
            return newsDomain;
        }

        IEnumerable<ParameterDomain> IRepository.GetAllParameterDomain(int id)
        {
            var parameterDb= _appDbContext.Parameter.Where(a=>a.LabId==id).ToList();
            var parameterDomain = parameterDb.Select(e=> new ParameterDomain(
                e.Id,
                e.LabId,
                e.ParameterName,
                e.ParameterValue,
                e.Remarks,
                e.MeasurementUnits
                ));
            return parameterDomain;
        }

        IEnumerable<SystemRecordDomain> IRepository.GetAllSystemRecordDomain()
        {
            var systemDb=_appDbContext.SystemRecord.ToList();
            var systemDomain = systemDb.Select(e => new SystemRecordDomain(
                e.Id,
               
                e.RecordName,
                e.RecordDescription
                ));
            return systemDomain;    
        }

        IEnumerable<ToysDomain> IRepository.GetAllToysDomain()
        {
            var toysDb=_appDbContext.Toys.ToList();
            var toysDomain = toysDb.Select(e => new ToysDomain(
                e.Id,
                e.BrandName,
                e.Name,
                e.AnimalType,
                e.ToyType,
                e.AgeGroup,
                e.Hight,
                e.Width,
                e.Quantity,
                e.Notes
                ));
            return toysDomain;
        }

        IEnumerable<VetVisitsDomain> IRepository.GetAllVetVisitsDomain()
        {
            var vetVisitDb=_appDbContext.VetVisits.ToList();
            var vetVisitDomain = vetVisitDb.Select(
                e=>new VetVisitsDomain(
                    e.Id,
                    e.AnimalId,
                    e.StartTime,
                    e.EndTime,
                    e.TypeOfVisit,
                    e.Notes
                    ));
            return vetVisitDomain;
        }






        //GET BY ID
        //----------------------------------------------------------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------------------------------------------------------
        public BirdDomain GetAllBirdDomain(int id)
        {
            var bird = _appDbContext.Birds
                .Join(_appDbContext.Animals, b => b.AnimalId, a => a.IdAnimal,
                    (b, a) => new { Bird = b, Animal = a })
                .Where(x => x.Animal.IdAnimal == id )
                .Select(x => new BirdDomain(
                    x.Animal.IdAnimal,
                    x.Bird.CageSize,
                    x.Bird.RecommendedToys,
                    x.Bird.Sociability))
                   .FirstOrDefault();

            return bird;
        }



        public FishDomain GetAllFishDomain(int id)
        {
            var fish= _appDbContext.Fish
      .Join(_appDbContext.Animals, f => f.AnimalId, a => a.IdAnimal,
            (f, a) => new { Fish = f, Animal = a })
        .Where(x => x.Animal.IdAnimal == id )
      .Select(x => new FishDomain(
          x.Animal.IdAnimal,
         
          x.Fish.TankSize,
          x.Fish.CompatibleSpecies,
          x.Fish.RecommendedItems
          ))
          .FirstOrDefault();

            return fish;
        }

        public MammalDomain GetAllMammalDomain(int id)
        {
            var mammals = _appDbContext.Mammals
                                 .Join(_appDbContext.Animals, m => m.AnimalId, a => a.IdAnimal,
                                       (m, a) => new { Mammal = m, Animal = a })
                                    .Where(x => x.Animal.IdAnimal == id )
                                 .Select(x => new MammalDomain(
                                     x.Animal.IdAnimal,
                                     x.Mammal.CoatType,
                                     x.Mammal.GroomingProducts
                                 ))
                                    .FirstOrDefault();

            return mammals;
        }

        public ReptileDomain GetAllReptileDomain(int id)
        {
            var reptile= _appDbContext.Reptiles
                              .Join(_appDbContext.Animals, r => r.AnimalId, a => a.IdAnimal,
                                    (r, a) => new { Reptile = r, Animal = a })
                                .Where(x => x.Animal.IdAnimal == id )
                              .Select(x => new ReptileDomain(
                                  x.Animal.IdAnimal,
                                
                                  x.Reptile.TankSize,
                                  x.Reptile.Sociability,
                                  x.Reptile.CompatibleSpecies,
                                  x.Reptile.RecommendedItems
                              ))
                                  .FirstOrDefault();
            return reptile;
        }
        public AnimalDomain GetAnimalById(int animalId)
        {
            var animalData = _appDbContext.Animals
                .Where(a => a.IdAnimal == animalId && !a.Adopted) // Filtriranje po ID-u i neudomljenosti
                .Select(e => new AnimalDomain(
                    e.IdAnimal,
                    e.Name,
                    e.Family,
                    e.Species,
                    e.Subspecies,
                    e.Age,
                    e.Gender,
                    e.Weight,
                    e.Height,
                    e.Length,
                    e.Neutered,
                    e.Vaccinated,
                    e.Microchipped,
                    e.Trained,
                    e.Socialized,
                    e.HealthIssues,
                    e.Picture,
                    e.PersonalityDescription,
                    e.Adopted))
                .FirstOrDefault();

            return animalData;
        }
        public AnimalDomain GetAllAnimalById(int animalId)
        {
            var animalData = _appDbContext.Animals
                .Where(a => a.IdAnimal == animalId ) // Filtriranje po ID-u i neudomljenosti
                .Select(e => new AnimalDomain(
                    e.IdAnimal,
                    e.Name,
                    e.Family,
                    e.Species,
                    e.Subspecies,
                    e.Age,
                    e.Gender,
                    e.Weight,
                    e.Height,
                    e.Length,
                    e.Neutered,
                    e.Vaccinated,
                    e.Microchipped,
                    e.Trained,
                    e.Socialized,
                    e.HealthIssues,
                    e.Picture,
                    e.PersonalityDescription,
                    e.Adopted))
                .FirstOrDefault();

            return animalData;
        }
        public AdopterDomain GetAdopterById(string id)
        {
            var adopterDb = _appDbContext.Adopter.FirstOrDefault(a => a.RegisterId == id);

            if (adopterDb == null)
            {
                return null; 
            }

            var adopterDomain = new AdopterDomain(
                adopterDb.Id,
                adopterDb.FirstName,
                adopterDb.LastName,
                adopterDb.DateOfBirth,
                adopterDb.Residence,
                adopterDb.Username,
                adopterDb.Password,
                adopterDb.NumAdoptedAnimals,
                adopterDb.NumReturnedAnimals,
                adopterDb.Flag,
                adopterDb.RegisterId);

            return adopterDomain;

        }
        public IEnumerable<AdoptedDomain> GetAllAdoptedDomainForAdopter(int adopterId)
        {
            var returnedAnimals = _appDbContext.ReturnedAnimal
       .Select(r => r.AnimalId) // Pretpostavljamo da 'Code' identificira vraćene životinje
       .ToList();
            var adoptedEntities = _appDbContext.Adopted
                                               .Where(a => a.AdopterId == adopterId && a.Animal.Adopted == true)
                                               .Include(a => a.Animal) // Uključi podatke o životinji
                                               .Include(a => a.Adopter) // Uključi podatke o usvojitelju
                                               .ToList();

            var adoptedDomains = adoptedEntities.Where(e => !returnedAnimals.Contains(e.Code)) // Filtriraj životinje koje nisu vraćene
    .Select(e => new AdoptedDomain
            {
                Code = e.Code,
                Animal = new AnimalDomain(
                    e.Animal.IdAnimal,
                    e.Animal.Name,
                    e.Animal.Species,
                    e.Animal.Family,
                    e.Animal.Subspecies,
                    e.Animal.Age,
                    e.Animal.Gender,
                    e.Animal.Weight,
                    e.Animal.Height,
                    e.Animal.Length,
                    e.Animal.Neutered,
                    e.Animal.Vaccinated,
                    e.Animal.Microchipped,
                    e.Animal.Trained,
                    e.Animal.Socialized,
                    e.Animal.HealthIssues,
                    e.Animal.Picture,
                    e.Animal.PersonalityDescription,
                    e.Animal.Adopted
                ),
                AdoptionDate = e.AdoptionDate,
                 Adopter = new AdopterDomain(
            e.Adopter.Id,
            e.Adopter.FirstName,
            e.Adopter.LastName,
            e.Adopter.Residence,
            e.Adopter.DateOfBirth,
            e.Adopter.NumAdoptedAnimals,
            e.Adopter.NumReturnedAnimals
            
            
        ),

            }).ToList();

            return adoptedDomains;
        } 
        public async Task<Animals> GetByIdAsync(int id)
        {
            return await _appDbContext.Animals.FirstOrDefaultAsync(a => a.IdAnimal == id);
        }
        public IEnumerable<ReturnedAnimalDomain> GetAllReturnedAnimalsForAdopter(int adopterId)
        {
            // Retrieve the returned animals from the database, filtering by adopterId
            var returnedAnimalEntities = _appDbContext.ReturnedAnimal
                                                      .Where(ra => ra.AdopterId == adopterId)
                                                      .Include(ra => ra.Animal) // Include animal data
                                                      .Include(ra => ra.Adopter) // Include adopter data
                                                      .ToList();

            // Map the returned entities to the domain model
            var returnedAnimalDomains = returnedAnimalEntities.Select(e => new ReturnedAnimalDomain
            {
                ReturnCode = e.ReturnCode,
                AdoptionCode = e.AdoptionCode,
                AnimalId = e.AnimalId,
                AdopterId = e.AdopterId,
                ReturnDate = e.ReturnDate,
                ReturnReason = e.ReturnReason,
                Animal = new AnimalDomain
                (
                    e.Animal.IdAnimal,
                    e.Animal.Name,
                    e.Animal.Species,
                    e.Animal.Family,
                    e.Animal.Subspecies,
                    e.Animal.Age,
                    e.Animal.Gender,
                    e.Animal.Weight,
                    e.Animal.Height,
                    e.Animal.Length,
                    e.Animal.Neutered,
                    e.Animal.Vaccinated,
                    e.Animal.Microchipped,
                    e.Animal.Trained,
                    e.Animal.Socialized,
                    e.Animal.HealthIssues,
                    e.Animal.Picture,
                    e.Animal.PersonalityDescription,
                    e.Animal.Adopted
                )
            }).ToList();

            return returnedAnimalDomains;
        }

    
      


        AdopterDomain IRepository.GetAdopterByUsername(string username)
        {
            throw new NotImplementedException();
        }



        //get by id novo// TREBALO BI BIT GOTOVO
        //---------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------
        AdopterDomain IRepository.GetAdopterByIdInt(int id)
        {
            var adopterDb = _appDbContext.Adopter.FirstOrDefault(a => a.Id == id);

            if (adopterDb == null)
            {
                return null;
            }

            var adopterDomain = new AdopterDomain(
                adopterDb.Id,
                adopterDb.FirstName,
                adopterDb.LastName,
                adopterDb.DateOfBirth,
                adopterDb.Residence,
                adopterDb.Username,
                adopterDb.Password,
                adopterDb.NumAdoptedAnimals,
                adopterDb.NumReturnedAnimals,
                adopterDb.Flag,
                adopterDb.RegisterId);

            return adopterDomain;
        }

        ToysDomain IRepository.GetOneToysDomain(int id)
        {
            var toyDb = _appDbContext.Toys.FirstOrDefault(a => a.Id == id);

            if (toyDb == null)
            {
                return null; 
            }

            var toyDomain = new ToysDomain(
                toyDb.Id,
                toyDb.BrandName,
                toyDb.Name,
                toyDb.AnimalType,
                toyDb.ToyType,
                toyDb.AgeGroup,
                toyDb.Hight,
                toyDb.Width,
                toyDb.Quantity,
                toyDb.Notes
               );

            return toyDomain;

        }

        NewsDomain IRepository.GetOneNewsDomain(int id)
        {
            var newsDb = _appDbContext.News.FirstOrDefault(a => a.Id == id);

            if (newsDb == null)
            {
                return null;
            }

            var newsDomain = new NewsDomain(
                newsDb.Id,
                newsDb.Name,
                newsDb.Description,
                newsDb.DateTime
              
               );

            return newsDomain;
        }
        FoodDomain IRepository.GetOneFoodDomain(int id)
        {
            var foodDb = _appDbContext.Food.FirstOrDefault(a => a.Id == id);

            if (foodDb == null)
            {
                return null;
            }

            var foodDomain = new FoodDomain(
                foodDb.Id,
                foodDb.BrandName,
                foodDb.Name,
                foodDb.FoodType,
                foodDb.AnimalType,
                foodDb.AgeGroup,
                foodDb.Weight,
               
                foodDb.CaloriesPerServing,
                foodDb.WeightPerServing,
                foodDb.MeasurementPerServing,
                foodDb.FatContent,
                foodDb.FiberContent,
                foodDb.ExporationDate,
                foodDb.Quantity,
                foodDb.Notes,
                foodDb.MeasurementWeight


               );

            return foodDomain;
        }
        BalansDomain IRepository.GetOneBalansDomain(int id)//ništa
        {
            var balansDb = _appDbContext.Balans.FirstOrDefault(a => a.Id == id);

            if (balansDb == null)
            {
                return null;
            }

            var balansDomain = new BalansDomain(
               balansDb.Id,
               balansDb.Iban,
               balansDb.Balance,
               balansDb.LastUpdated,
               balansDb.Password,
               balansDb.Type


               );

            return balansDomain;
        }

        //kako složit da includa i podatke iz druge klase
        public   MedicinesDomain GetOneMedicinesDomain(int id)
        {
            var medicinesdb = _appDbContext.Medicines
                .Join(_appDbContext.Animals, r => r.AnimalId, a => a.IdAnimal,
                                    (r, a) => new { Medicines = r, Animal = a })
                                .Where(x => x.Medicines.Id == id)
                             .Select(x => new MedicinesDomain(
                              x.Medicines.Id,
                              x.Medicines.AnimalId,
                         x.Medicines.NameOfMedicines,
                         x.Medicines.Description,
                         x.Medicines.VetUsername,
                         x.Medicines.AmountOfMedicine,
                         x.Medicines.MesurmentUnit,
                         x.Medicines.MedicationIntake,
                         x.Medicines.FrequencyOfMedicationUse,
                         x.Medicines.Usage
                              ))
                                  .FirstOrDefault();
         
            return medicinesdb;

        }

       public LabsDomain GetOneLabsDomain(int id)
        {
            var labs = _appDbContext.Labs
               .Join(_appDbContext.Animals, r => r.AnimalId, a => a.IdAnimal,
                                   (r, a) => new { Labs = r, Animal = a })
                               .Where(x => x.Labs.Id == id)
                            .Select(x => new LabsDomain(
                                 x.Labs.Id,
                                 x.Labs.AnimalId,
                             
                                 x.Labs.DateTime

                             ))
                                 .FirstOrDefault();

            return labs;
        }

       public FundsDomain GetOneFundsDomain(int id)//Adopter
        {
            var funds = _appDbContext.Funds
                .Join(_appDbContext.Adopter, r => r.AdopterId, a => a.Id,
                                    (r, a) => new { Funds = r, Adopter = a })
                                .Where(x => x.Funds.Id == id)
                                .Select(x => new FundsDomain(
                                x.Funds.Id,
                                x.Funds.AdopterId,
                                x.Funds.Amount,
                                x.Funds.Purpose,
                                x.Funds.DateTimed
                              ))
                                  .FirstOrDefault();

            return funds;
        }

      public  FoundRecordDomain GetOneFoundRecordDomain(int id)
        {
            var foundRecord = _appDbContext.FoundRecord
             .Join(_appDbContext.Animals, r => r.AnimalId, a => a.IdAnimal,
                                 (r, a) => new { FoundRecord = r, Animal = a })
                             .Where(x => x.FoundRecord.AnimalId == id)
                          .Select(x => new FoundRecordDomain(
                               x.FoundRecord.Id,
                               x.FoundRecord.AnimalId,
                               x.FoundRecord.Date,
                               x.FoundRecord.Adress,
                               x.FoundRecord.Description,
                               x.FoundRecord.OwnerName,
                               x.FoundRecord.OwnerSurname,
                               x.FoundRecord.OwnerPhoneNumber,
                               x.FoundRecord.OwnerOIB,
                               x.FoundRecord.RegisterId
                               

                           ))
                               .FirstOrDefault();

            return foundRecord;
        }

      

       public EuthanasiaDomain GetOneEuthanasiaDomain(int id)
        {
            var euthanasia = _appDbContext.Euthanasia
              .Join(_appDbContext.Animals, r => r.AnimalId, a => a.IdAnimal,
                                  (r, a) => new { Euthanasia = r, Animal = a })
                              .Where(x => x.Euthanasia.Id == id)
                           .Select(x => new EuthanasiaDomain(
                                x.Euthanasia.Id,
                                x.Euthanasia.AnimalId,
                                x.Euthanasia.Date,
                                x.Euthanasia.NameOfDesissse


                            ))
                                .FirstOrDefault();

            return euthanasia;
        }

      public  ContageusAnimalsDomain GetOneContageusAnimalsDomain(int id)
        {

            var contageusAnimals = _appDbContext.ContageusAnimals
              .Join(_appDbContext.Animals, r => r.AnimalId, a => a.IdAnimal,
                                  (r, a) => new { ContageusAnimals = r, Animal = a })
                              .Where(x => x.ContageusAnimals.Id == id)
                           .Select(x => new ContageusAnimalsDomain(
                                x.ContageusAnimals.Id,
                                x.ContageusAnimals.AnimalId,
                                x.ContageusAnimals.DesisseName,
                                x.ContageusAnimals.Description,
                                x.ContageusAnimals.Contageus


                            ))
                                .FirstOrDefault();

            return contageusAnimals;
        }

      public  ContactDomain GetOneContactDomain(int id)//Aadopter
        {
            var contact = _appDbContext.Contact
           .Join(_appDbContext.Adopter, r => r.AdopterId, a => a.Id,
                               (r, a) => new { Contact = r, Adopter = a })
                           .Where(x => x.Contact.Id == id)
                           .Select(x => new ContactDomain(
                           x.Contact.Id,
                           x.Contact.Name,
                           x.Contact.Email,
                           x.Contact.Description,
                           x.Contact.AdopterId,
                           x.Contact.Read



                         ))
                             .FirstOrDefault();

            return contact;
        }

        //-----------------------------------------------------------------------------------------------------------------------
        //Get oneby id animal
     public   MedicinesDomain GetOneMedicinesAnimal(int id)
        {
            var meds = _appDbContext.Medicines
            .Join(_appDbContext.Animals, r => r.AnimalId, a => a.IdAnimal,
                                (r, a) => new { Medicines = r, Animals = a })
                            .Where(x => x.Medicines.AnimalId == id)
                            .Select(x => new MedicinesDomain(
                           x.Medicines.Id,
                           x.Medicines.AnimalId,
                           x.Medicines.NameOfMedicines,
                           x.Medicines.Description,
                           x.Medicines.VetUsername,
                           x.Medicines.AmountOfMedicine,
                           x.Medicines.MesurmentUnit,
                           x.Medicines.MedicationIntake,
                           x.Medicines.FrequencyOfMedicationUse,
                           x.Medicines.Usage

                          ))
                              .FirstOrDefault();

            return meds;
        }

       public ContageusAnimalsDomain GetOneContageusAnimal(int id)
        {
            var contageusAnimal = _appDbContext.ContageusAnimals
              .Join(_appDbContext.Animals, r => r.AnimalId, a => a.IdAnimal,
                                  (r, a) => new { ContageusAnimals = r, Animals = a })
                              .Where(x => x.ContageusAnimals.AnimalId == id)
                              .Select(x => new ContageusAnimalsDomain(
                             x.ContageusAnimals.Id,
                             x.ContageusAnimals.AnimalId,
                             x.ContageusAnimals.DesisseName,
                             x.ContageusAnimals.Description,
                             x.ContageusAnimals.Contageus
                           
                            

                            ))
                                .FirstOrDefault();

            return contageusAnimal;
        }

      public  LabsDomain GetOneLabsAnimal(int id)
        {
            var labs = _appDbContext.Labs
             .Join(_appDbContext.Animals, r => r.AnimalId, a => a.IdAnimal,
                                 (r, a) => new { Labs = r, Animals = a })
                             .Where(x => x.Labs.AnimalId == id)
                             .Select(x => new LabsDomain(
                            x.Labs.Id,
                            x.Labs.AnimalId,
                          
                            x.Labs.DateTime



                           ))
                               .FirstOrDefault();

            return labs;
        }

      public  VetVisitsDomain GetOneVetVisitAnimal(int id)
        {
            var visit = _appDbContext.VetVisits
             .Join(_appDbContext.Animals, r => r.AnimalId, a => a.IdAnimal,
                                 (r, a) => new { VetVisits = r, Animals = a })
                             .Where(x => x.VetVisits.AnimalId == id)
                             .Select(x => new VetVisitsDomain(
                            x.VetVisits.Id,

                            x.VetVisits.AnimalId,
                            x.VetVisits.StartTime,
                            x.VetVisits.EndTime,
                            x.VetVisits.TypeOfVisit,
                            x.VetVisits.Notes



                           ))
                               .FirstOrDefault();

            return visit;
        }



        public AnimalRecordDomain GetOneAnimalRecord(int id)//ne radi
        {

            var record = _appDbContext.AnimalRecord.Select(r => r.AnimalId).ToList();

           
            if (record == null)
            {
                throw new Exception("Record not found");
            }
            else
            {

                var recordEntities = _appDbContext.AnimalRecord
                                                   .Where(a => a.AnimalId == id)
                                                   .Include(a => a.Animal) // Uključi podatke o životinji
                                                   .Include(a => a.Record) // Uključi podatke o podacima gdijeje životinja
                                                   .ToList();
                var recordDomains = recordEntities.Where(e => record.Contains(id))
                 .Select(e => new AnimalRecordDomain
                 {  
                    
                 

                     Animal = new AnimalDomain(
                        e.Animal.IdAnimal,
                        e.Animal.Name,
                        e.Animal.Species,
                        e.Animal.Family,
                        e.Animal.Subspecies,
                        e.Animal.Age,
                        e.Animal.Gender,
                        e.Animal.Weight,
                        e.Animal.Height,
                        e.Animal.Length,
                        e.Animal.Neutered,
                        e.Animal.Vaccinated,
                        e.Animal.Microchipped,
                        e.Animal.Trained,
                        e.Animal.Socialized,
                        e.Animal.HealthIssues,
                        e.Animal.Picture,
                        e.Animal.PersonalityDescription,
                        e.Animal.Adopted
                    ),
                     Record = new SystemRecordDomain(
                          e.Record.Id,
                      
                          e.Record.RecordName,
                          e.Record.RecordDescription


                          ),
                 })
                .FirstOrDefault();


             
                return recordDomains;
            }
        
            }
















































        //UPDATE
        //----------------------------------------------------------------------------------------------------------------------------------------------
       
        public async Task<bool> UpdateAdopterFlag(int adopterId)
        {

            var adopter = await _appDbContext.Adopter.FirstOrDefaultAsync(a => a.Id == adopterId);

            if (adopter == null)
            {
                return false;
            }
            adopter.Flag = true;


            _appDbContext.Adopter.Update(adopter);

            await _appDbContext.SaveChangesAsync();

            return true;
        }



        public async Task IncrementNumberOfAdoptedAnimalsAsync(string registerId)
        {
            

            var adopter = await _appDbContext.Adopter.FirstOrDefaultAsync(a => a.RegisterId == registerId);
            if (adopter != null)
            {
                adopter.NumAdoptedAnimals = adopter.NumAdoptedAnimals + 1;
                _appDbContext.Adopter.Update(adopter);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task IncrementNumberOfReturnedAnimalsAsync(string registerId)
        {
            var adopter = await _appDbContext.Adopter.FirstOrDefaultAsync(a => a.RegisterId == registerId);
            if (adopter != null)
            {
                adopter.NumReturnedAnimals = adopter.NumReturnedAnimals + 1;
                _appDbContext.Adopter.Update(adopter);
                await _appDbContext.SaveChangesAsync();
            }
        }
        public async Task<AdopterDomain> UpdateAdopterAsync(string registerId, string firstName, string lastName, DateTime dateOfBirth, string residence, string username, string password)
        {
            // Fetch the existing adopter from the database using registerId
            var adopter = await _appDbContext.Adopter.FirstOrDefaultAsync(a => a.RegisterId == registerId);

            if (adopter == null)
            {
                throw new Exception("Adopter not found");
            }

            // Update the adopter's details
            adopter.FirstName = firstName;
            adopter.LastName = lastName;
            adopter.DateOfBirth = dateOfBirth;
            adopter.Residence = residence;
            adopter.Username = username;
            adopter.Password = password;

            // Save the changes to the database
            _appDbContext.Adopter.Update(adopter);
            await _appDbContext.SaveChangesAsync();

            // Map the updated adopter back to the domain model and return it
            return _mappingService.Map<AdopterDomain>(adopter);
        }
        public async Task<AnimalDomain> UpdateAnimalAsync(int idAnimal, int age, decimal weight, decimal height, decimal length, bool neutered, bool vaccinated, bool microchipped, bool trained, bool socialized, string healthIssues, string personalityDescription)
        {
            // Fetch the existing animal from the database using idAnimal
            var animal = await _appDbContext.Animals.FirstOrDefaultAsync(a => a.IdAnimal == idAnimal);

            if (animal == null)
            {
                throw new Exception("Animal not found");
            }

            // Update the animal's details
            animal.Age = age;
            animal.Weight = weight;
            animal.Height = height;
            animal.Length = length;
            animal.Neutered = neutered;
            animal.Vaccinated = vaccinated;
            animal.Microchipped = microchipped;
            animal.Trained = trained;
            animal.Socialized = socialized;
            animal.HealthIssues = healthIssues;
            animal.PersonalityDescription = personalityDescription;

            // Save the changes to the database
            _appDbContext.Animals.Update(animal);
            await _appDbContext.SaveChangesAsync();

            // Map the updated animal back to the domain model and return it
            return _mappingService.Map<AnimalDomain>(animal);
        }

        public async Task<bool> AdoptionStatus(int animalId)
        {
            // Fetch the existing adopter from the database using registerId
            var animal = await _appDbContext.Animals.FirstOrDefaultAsync(a => a.IdAnimal == animalId);

            animal.Adopted = true;
           

            _appDbContext.Animals.Update(animal);
            await _appDbContext.SaveChangesAsync();

            return true;
        }
        public async Task<bool> AdoptionStatusFalse(int animalId)
        {
            // Fetch the existing adopter from the database using registerId
            var animal = await _appDbContext.Animals.FirstOrDefaultAsync(a => a.IdAnimal == animalId);

            animal.Adopted = false;


            _appDbContext.Animals.Update(animal);
            await _appDbContext.SaveChangesAsync();

            return true;
        }
       //Ovo ne radi svejedno
        public async Task<BirdDomain> UpdateBird(BirdDomain birdDomain)
        {
            return _mappingService.Map<BirdDomain>(birdDomain);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //update novo

       public async Task<bool>  UpdateAnimalRecordDomain(int id, int recordId)//To je ono što je životinja prošla to jest ažurira na kojem je dijelu, ušla u azil, kod veterinara itd
        {
            //potrebno složiti provjeru na kojem je trenutno statusu kako bi onemogučili da životinja koja je tek došla može odmah i otići
            /* 
             * napraviti da se pokretanjem migracije isto kao role i ovo automatski sprema
             1	Arivall	                pokreće se prilikom prve registracije životinje
            2	First Vet Visit 	    pokreće se kad prvi put dodamo životinju u vet visit checkup - provjeri u bazi dali ima ta životinja koji checkup ako ne dodaje se tu ili mogu provjerit ako je životinje u systemu 1, a dodaje se novi vet visit
            3	Quarantine 	            Problem: životinja može uvijek bit u ovom stanju, ali nekako moram smislit da barem jednom mora bit
            4	Shelter 	            pokreće se automatski nakon što prođe datum Quarantine ili možda dodavanjem buttona da je to završilo
            5	Socialized 	            mora imat preduvjet prva 4 minimum
            6	Approve for Adoption	pokreće se na button Approve na stranici od veterinara// možeš samo ako ima prvih pet prođenih //omogućuje korisnicima da vide životinju da je za posvajanje
            7	Adopted  	            pokreće se kad korisnik posvoji životinju  
            8	Euthanasia 	Euthanasia  pokreće se kad se izvrši eutanazija
            9	Returnd	Returnd         pokreće se kad osoba vrati životinju*/
            /*
             *  ako je stanje 9 proces kreće od 3
             * primjer u bazi se zapiše 9 ta životinja iskoči veterinaru negdje, veterinar ju doda u Quarantine 
             * Rješenje bi moglo biti u Switch Case, za svaku opciju napravit koje su mogućnosti
             * problem 2: u teoriji samo prva dva stanja se ne mogu ponovit i 8 jel očit razlog
             */
            var eutanasia = await _appDbContext.Euthanasia.FirstOrDefaultAsync(v => v.AnimalId == id);
           var vetVisit = _appDbContext.VetVisits.ToList().Where(a=> a.AnimalId==id);
         
             var animal = await _appDbContext.AnimalRecord.FirstOrDefaultAsync(a => a.AnimalId == id);
            try
            {
                if (animal == null || eutanasia != null)
                {
                    return false;
                }
                switch(recordId)
                {
                    
                    case 2:
                        if(animal.RecordId == 1 && vetVisit==null)
                        {
                            animal.RecordId = recordId;
                            _appDbContext.AnimalRecord.Update(animal);
                            await _appDbContext.SaveChangesAsync();
                        }
                        break;
                    case 3:
                        if(animal.RecordId >=2 && animal.RecordId!=7 && animal.RecordId !=8 )//bitno je samo da životinja iz stanja 1 ne ide u stanje 3.7 ne smije bit zato što životinja nijeu u vlasništvu skloništa, a 8 zato što je uginula
                        {
                            animal.RecordId = recordId;
                            _appDbContext.AnimalRecord.Update(animal);
                            await _appDbContext.SaveChangesAsync();
                        }
                        break;
                    case 4:
                        if (animal.RecordId >=3 && animal.RecordId != 7  && animal.RecordId != 8)
                        {
                            animal.RecordId = recordId;
                            _appDbContext.AnimalRecord.Update(animal);
                            await _appDbContext.SaveChangesAsync();
                        }
                        break;
                    case 5:
                        if (animal.RecordId == 4)
                        {
                            animal.RecordId = recordId;
                            _appDbContext.AnimalRecord.Update(animal);
                            await _appDbContext.SaveChangesAsync();
                        }
                        break;
                    case 6:
                        if(animal.RecordId== 5 )
                        {
                            animal.RecordId = recordId;
                            _appDbContext.AnimalRecord.Update(animal);
                            await _appDbContext.SaveChangesAsync();
                        }
                        break;
                    case 7:
                        if (animal.RecordId == 6)
                        {
                            animal.RecordId = recordId;
                            _appDbContext.AnimalRecord.Update(animal);
                            await _appDbContext.SaveChangesAsync();
                        }
                        break;
                    case 8://uvjet je da je životinja u tablici eutanazija i da je complited true i nekako moram napravit da ako životinja ima ovu oznaku da se ne pokazuje nigdje osim u tablici eutanazia. ili u listi kod admina
                        break;
                    case 9:
                        if(animal.RecordId == 7)
                        {
                            animal.RecordId = recordId;
                            _appDbContext.AnimalRecord.Update(animal);
                            await _appDbContext.SaveChangesAsync();
                        }
                        break;

                    default:
                        break;
                }
            }
            catch
            {
                throw new Exception("Animal record not found");
            }
           
           
            return true;
        }
      
        public async Task<bool> UpdateAnimalBalansDomain(int id, decimal balance)//izmjena podataka na računu od donacija
        {
            var balans = await _appDbContext.Balans.FirstOrDefaultAsync(a => a.Id == id);

            balans.Balance = balans.Balance+balance;
        

            _appDbContext.Balans.Update(balans);
            await _appDbContext.SaveChangesAsync();


            return true;
        }

        public async Task<bool> UpdateContageusAnimalsDomain(int id, bool contageus)//ažurira se ako životinja nije više zarzazna
        {
            var animal = await _appDbContext.ContageusAnimals.FirstOrDefaultAsync(a => a.Id == id);

            animal.Contageus= contageus;

            _appDbContext.ContageusAnimals.Update(animal);
            await _appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateEuthanasiaDomain(int id, DateTime date, bool complited)// ažurira se ako je radnja izvršena ili ako nije za produženje vremena
        {
            var animal = await _appDbContext.Euthanasia.FirstOrDefaultAsync(a => a.Id == id);
            animal.Date= date;
            animal.Complited= complited;
            _appDbContext.Euthanasia.Update(animal);
            await _appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateFoodDomainIncrement(int id)//ažurira se nakon što dođe narudžba nove hrane
        {
            var food = await _appDbContext.Food.FirstOrDefaultAsync(a => a.Id == id);
            var quontiy = food.Quantity + 1;
            food.Quantity= quontiy;

            _appDbContext.Food.Update(food);
            await _appDbContext.SaveChangesAsync();


            return true;
        }

        public async Task<bool> UpdateFoodDomainDecrement(int id)//ažurira se kad se određena hrana potroši
        {
            var food = await _appDbContext.Food.FirstOrDefaultAsync(a => a.Id == id);
            var quontiy = food.Quantity - 1;
            food.Quantity = quontiy;

            _appDbContext.Food.Update(food);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        //ažurira se ako postoji greška u nazivu hrane itd
        public async Task<bool> UpdateFoodDomain(int id, string brandName, string name, string foodType, string animalType, string ageGroup, decimal weight, decimal caloriesPerServing, decimal weightPerServing, string measurementPerServing, decimal fatContent, decimal fiberContent, DateTime exporationDate, int quantity, string notes, string measurementWeight)
        {
            var food = await _appDbContext.Food.FirstOrDefaultAsync(a => a.Id == id);
            food.BrandName=brandName;
            food.Name = name;
            food.FoodType=foodType;
            food.AnimalType=animalType;
            food.AgeGroup=ageGroup;
            food.Weight=weight;
            food.CaloriesPerServing=caloriesPerServing;
            food.WeightPerServing=weightPerServing;
            food.MeasurementPerServing=measurementPerServing;
            food.FatContent=fatContent;
            food.FiberContent=fiberContent;
            food.ExporationDate=exporationDate;
            food.Quantity=quantity;
            food.Notes=notes;
            food.MeasurementWeight=measurementWeight;

            _appDbContext.Food.Update(food);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateToysDomainIncrement(int id)//ažurira se nakon što dođe narudžba nove igračaka za životnje
        {
            var toy = await _appDbContext.Toys.FirstOrDefaultAsync(a => a.Id == id);
            var quontiy = toy.Quantity + 1;
            toy.Quantity = quontiy;

            _appDbContext.Toys.Update(toy);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateToysDomainDecrement(int id)//ažurira se nakon što dođe se određena  igračaka podjeli
        {
            var toy = await _appDbContext.Toys.FirstOrDefaultAsync(a => a.Id == id);
            var quontiy = toy.Quantity  -1;
            toy.Quantity = quontiy;

            _appDbContext.Toys.Update(toy);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        //ažurira se ako postoji greška 
        public async Task<bool> UpdateToysDomain(int id, string brandName, string name, string animalType, string toyType, string ageGroup, decimal hight, decimal width, int quantity, string notes)
        {
            var toy = await _appDbContext.Toys.FirstOrDefaultAsync(a => a.Id == id);

            toy.BrandName= brandName;
            toy.Name= name;
            toy.AnimalType= animalType;
            toy.ToyType= toyType;
            toy.AgeGroup= ageGroup;
            toy.Hight= hight;
            toy.Width= width;
            toy.Quantity= quantity;
            toy.Notes= notes;

            _appDbContext.Toys.Update(toy);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        //ažurira se ako postoji greška 
        public async Task<bool> UpdateFoundRecordDomain(int id, int animalId, DateTime date, string adress, string description, string ownerName, string ownerSurname, string ownerPhoneNumber, string ownerOIB, string registerId)
        {
            var found = await _appDbContext.FoundRecord.FirstOrDefaultAsync(a => a.Id == id);

            found.Date=date;
            found.Adress= adress;
            found.Description = description;
            found.OwnerName= ownerName;
            found.OwnerSurname= ownerSurname;
            found.OwnerPhoneNumber= ownerPhoneNumber;
           found.OwnerOIB= ownerOIB;
            found.RegisterId= registerId;


            _appDbContext.FoundRecord.Update(found);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

     

        public async Task<bool> UpdateMedicinesDomainUsage(int id, bool usage)  //ažurira se ako životinja ne koristi te ljekove, umjesto brisanja se životinje sa false sakriju
        {
            var meds= await _appDbContext.Medicines.FirstOrDefaultAsync(a => a.Id == id);
            meds.Usage = usage;

            _appDbContext.Medicines.Update(meds);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateMedicinesDomain(int id, decimal amountOfMedicine, string mesurmentUnit, int medicationIntake, string frequencyOfMedicationUse)//ažurira se ako je potrebna izmjena ljekova tj količine ljekova
        {
            var meds = await _appDbContext.Medicines.FirstOrDefaultAsync(a => a.Id == id);

            meds.AmountOfMedicine=amountOfMedicine;
            meds.MesurmentUnit=mesurmentUnit;
            meds.MedicationIntake=medicationIntake;
            meds.FrequencyOfMedicationUse=frequencyOfMedicationUse;


            _appDbContext.Medicines.Update(meds);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateNewsDomain(int id, string name, string description, DateTime dateTime)  //ažurira se ako postoji greška 
        {
            var news = await _appDbContext.News.FirstOrDefaultAsync(a => a.Id == id);
            news.Name=name;
            news.Description=description;
            news.DateTime=dateTime;

            _appDbContext.News.Update(news);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateVetVisitsDomain(int id, DateTime startTime, DateTime endTime, string notes)  //ažurira se ako postoji greška 
        {
            var visit = await _appDbContext.VetVisits.FirstOrDefaultAsync(a => a.Id == id);
          
            visit.StartTime=startTime;
            visit.EndTime=endTime;
            visit.Notes=notes;


            _appDbContext.VetVisits.Update(visit);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

      public async  Task<bool> UpdateContactDomain(int id)
        {
            var contact = await _appDbContext.Contact.FirstOrDefaultAsync(a => a.Id == id);

            contact.Read = true;
          

            _appDbContext.Contact.Update(contact);
            await _appDbContext.SaveChangesAsync();
            return true;
        }




        //ADD
        //----------------------------------------------------------------------------------------------------------------------------------------------

        //----------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------
        //ADD
        public async Task<AnimalDomain> AddAnimalAsync(
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
        )
        {
            try
            {
                var newAnimal = new Animals
                {
                    Name = name,
                    Family = family,
                    Species = species,
                    Subspecies = subspecies,
                    Age = age,
                    Gender = gender,
                    Weight = weight,
                    Height = height,
                    Length = length,
                    Neutered = neutered,
                    Vaccinated = vaccinated,
                    Microchipped = microchipped,
                    Trained = trained,
                    Socialized = socialized,
                    HealthIssues = healthIssues,
                    Picture = picture,
                    PersonalityDescription = personalityDescription,
                    Adopted = adopted
                };
                var animal = _mappingService.Map<Animals>(newAnimal);
                _appDbContext.Animals.Add(animal);

                await _appDbContext.SaveChangesAsync();
                return _mappingService.Map<AnimalDomain>(animal);//Neka mi vrati sve podatke životinje kao bih mogla uzeti id i provjeriti dali su podaci dobro uneseni
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add animal: {ex.Message}");
            }
        }
        public async Task<AdopterDomain> CreateAdopterAsync(string firstName, string lastName, DateTime dateOfBirth, string residence, string username, string password, string registerId)
        {
            var adopterDomain = new AdopterDomain
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Residence = residence,
                Username = username,
                Password = password,
                NumberOfAdoptedAnimals = 0,
                NumberOfReturnedAnimals = 0,
                Flag = false,
                RegisterId = registerId,
                Adopted = new List<AdoptedDomain>(),
                ReturnedAnimal = new List<ReturnedAnimalDomain>()
            };

            var adopter = _mappingService.Map<Adopter>(adopterDomain);

            _appDbContext.Adopter.Add(adopter);
            await _appDbContext.SaveChangesAsync();

            return _mappingService.Map<AdopterDomain>(adopter);
        }








        public async Task<bool> AddBirdAsync(BirdDomain birdDomain)
        {
            var bird = new Birds
            {
                AnimalId = birdDomain.AnimalId,
                CageSize = birdDomain.CageSize,
                RecommendedToys = birdDomain.RecommendedToys,
                Sociability = birdDomain.Sociability
            };

            await _appDbContext.Birds.AddAsync(bird);
            return await _appDbContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> AddMammalAsync(MammalDomain mammalDomain)
        {
            var mammal = new Mammals
            {
                AnimalId = mammalDomain.AnimalId,
                CoatType = mammalDomain.CoatType,
                GroomingProducts = mammalDomain.GroomingProducts
            };

            await _appDbContext.Mammals.AddAsync(mammal);
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddFishAsync(FishDomain fishDomain)
        {
            var fish = new Fish
            {
                AnimalId = fishDomain.AnimalId,
                TankSize = fishDomain.TankSize,
                CompatibleSpecies = fishDomain.CompatibleSpecies,
                RecommendedItems = fishDomain.RecommendedItems
            };

            await _appDbContext.Fish.AddAsync(fish);
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddReptileAsync(ReptileDomain reptileDomain)
        {
            var reptile = new Reptiles
            {
                AnimalId = reptileDomain.AnimalId,
                TankSize = reptileDomain.TankSize,
                Sociability = reptileDomain.Sociability,
                CompatibleSpecies = reptileDomain.CompatibleSpecies,
                RecommendedItems = reptileDomain.RecommendedItems
            };

            await _appDbContext.Reptiles.AddAsync(reptile);
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddAmphibianAsync(AmphibianDomain amphibianDomain)
        {
            var amphibian = new Amphibians
            {
                AnimalId = amphibianDomain.AnimalId,
                Humidity = amphibianDomain.Humidity,
                Temperature = amphibianDomain.Temperature
            };

            await _appDbContext.Amphibians.AddAsync(amphibian);
            return await _appDbContext.SaveChangesAsync() > 0;
        }


    
  













        public async Task<bool> CreateReturnedAnimalAsync(int adoptionCode, int animalId, int adopterId, DateTime returnDate, string returnReason)
        {
         
            var returnedAnimalDomain = new ReturnedAnimal
            {
              
                AdoptionCode = adoptionCode,
                AnimalId = animalId,
                AdopterId = adopterId,
                ReturnDate = returnDate,
                ReturnReason = returnReason
            };

            var returnedAnimal = _mappingService.Map<ReturnedAnimal>(returnedAnimalDomain);

            _appDbContext.ReturnedAnimal.Add(returnedAnimal);
            await _appDbContext.SaveChangesAsync();
         
            return true;
        }
        
          

        public async Task<bool> CreateAdoptedAsync(int animalId, int adopterId, DateTime adoptionDate)
        {
            try
            {
                var adoptedEntity = new Adopted
                {
                    AnimalId = animalId,
                    AdopterId = adopterId,
                    AdoptionDate = adoptionDate
                    // Don't set Code explicitly if it's an identity column
                };

                _appDbContext.Adopted.Add(adoptedEntity);
                await _appDbContext.SaveChangesAsync();

                var animal = await _appDbContext.Animals.FirstOrDefaultAsync(a => a.IdAnimal == animalId);
                if (animal == null)
                {
                    Console.WriteLine($"Životinja s ID-om {animalId} nije pronađena.");
                    return false; // Životinja nije pronađena
                }
               

                return true; // Success
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return false; // Failed to save
            }
        }


        //Add novo
        //-----------------------------------------------------------------------------------------

        //Kad admin ili radnik kreiraju životinj odmas se stvori i rekord kojemu je PK isti kao od životinjekako bi imali samo jedan record po životinj koji se updata
       public async Task AddAnimalRecord(int idAnimal)
        {
           
                var animalExists=await _appDbContext.Animals.FirstOrDefaultAsync(a=> a.IdAnimal ==  idAnimal);//vratio mi je null :o// radi bio je krivi request pa je slalo 0
          
            if (animalExists !=null)
                { var animalRecord = new AnimalRecordDomain
                {    
                    RecordId = 1,
                    AnimalId=idAnimal,
                 
              
                  
                   
                };
                var animal = _mappingService.Map<AnimalRecord>(animalRecord);
                _appDbContext.AnimalRecord.Add(animal);
                var input =  await _appDbContext.SaveChangesAsync(); 
          
                }
                else
                {
                    throw new Exception($"Životinj {animalExists.IdAnimal} ne postoji!" );
                  
                }

           
        }


      public async  Task AddFoundRecord( int animalId, DateTime date, string adress, string description, string ownerName, string ownerSurname, string ownerPhoneNumber, string ownerOIB, string registerId)
        {
            var animalExists = await _appDbContext.Animals.FirstOrDefaultAsync(a => a.IdAnimal == animalId);
            if (animalExists != null)
            {
                var faundAnimal = new FoundRecordDomain
                {
                    AnimalId = animalId,
                    Date = date,
                    Adress = adress,
                    Description = description,
                    OwnerName = ownerName,
                    OwnerSurname = ownerSurname,
                    OwnerPhoneNumber = ownerPhoneNumber,
                    OwnerOIB = ownerOIB,
                    RegisterId = registerId//ovo j euser id
                };

                var animal = _mappingService.Map<FoundRecord>(faundAnimal);
                _appDbContext.FoundRecord.Add(animal);
                 await _appDbContext.SaveChangesAsync();

            }
            else
            {
                throw new Exception($"Životinj {animalExists.IdAnimal} ne postoji!");
            }

        }




     public async Task AddFood(string brandName, string name, string foodType, string animalType, string ageGroup, decimal weight, decimal caloriesPerServing,
         decimal weightPerServing, string measurementPerServing, decimal fatContent, decimal fiberContent,
         DateTime exporationDate, int quantity, string notes, string measurementWeight)
        {
            try
            {
                var food = new FoodDomain
                {
                    BrandName = brandName,
                    Name = name,
                    FoodType = foodType,
                    AnimalType = animalType,
                    AgeGroup = ageGroup,
                    Weight = weight,
                    CaloriesPerServing = caloriesPerServing,
                    WeightPerServing = weightPerServing,
                    MeasurementPerServing = measurementPerServing,
                    FatContent = fatContent,
                    FiberContent = fiberContent,
                    ExporationDate = exporationDate,
                    Quantity = quantity,
                    Notes = notes,
                    MeasurementWeight = measurementWeight
                };

                var foodResponse = _mappingService.Map<Food>(food);
                _appDbContext.Food.Add(foodResponse);
                await _appDbContext.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }







       public async Task AddToys(string brandName, string name, string animalType, string toyType, string ageGroup, decimal hight, decimal width, int quantity, string notes)
        {
                var toy = new ToysDomain
                {
                    BrandName = brandName,
                    Name = name,
                    AnimalType = animalType,
                    ToyType=toyType,
                    AgeGroup = ageGroup,
                    Hight=hight,
                    Width=width,
                    Quantity=quantity,
                    Notes=notes
                };

                var toyResponse = _mappingService.Map<Toys>(toy);
                _appDbContext.Toys.Add(toyResponse);
                await _appDbContext.SaveChangesAsync();
          
        }


     public async   Task AddNews(string name, string description, DateTime dateTime)
        {
            var news = new NewsDomain
            {
              Name= name,
              Description = description,
              DateTime = dateTime
            };

            var newsResponse = _mappingService.Map<News>(news);
            _appDbContext.News.Add(newsResponse);
            await _appDbContext.SaveChangesAsync();
        }

     async   Task IRepository.AddVetVsit(int animalId, DateTime startTime, DateTime endTime, string typeOfVisit, string notes)
        {
            var animalExists = await _appDbContext.Animals.FirstOrDefaultAsync(a => a.IdAnimal == animalId);
            if (animalExists != null)
            {
                var faundAnimal = new VetVisitsDomain
                {
                    AnimalId = animalId,
                    StartTime=startTime,
                    EndTime=endTime,
                    TypeOfVisit = typeOfVisit,
                    Notes = notes
          
                };

                var animal = _mappingService.Map<VetVisits>(faundAnimal);
                _appDbContext.VetVisits.Add(animal);
                await _appDbContext.SaveChangesAsync();

            }
            else
            {
                throw new Exception($"Životinj {animalExists.IdAnimal} ne postoji!");
            }
        }




   public   async  Task AddSystemRecord(int recordNumber, string recordName, string recordDescription)
        {
            var data = new SystemRecordDomain
            {
               RecordNumber=recordNumber,
               RecordName=recordName,
               RecordDescription=recordDescription
            };

            var dataResponse = _mappingService.Map<SystemRecord>(data);
            _appDbContext.SystemRecord.Add(dataResponse);
            await _appDbContext.SaveChangesAsync();
        }


        public async Task AddMedicines(int animalId, string nameOfMedicines, string descriptio, string vetUsername,
            decimal amountOfMedicine, string mesurmentUnit, int medicationIntake, string frequencyOfMedicationUse, bool usage)
        {
            var animalExists = await _appDbContext.Animals.FirstOrDefaultAsync(a => a.IdAnimal == animalId);
            if (animalExists != null)
            {
                var medicinesAnimal = new MedicinesDomain
                {
                    AnimalId=animalId,
                    NameOfMedicines=nameOfMedicines,
                    Description=descriptio,
                    VetUsername=vetUsername,
                    AmountOfMedicine=amountOfMedicine,
                    MesurmentUnit=mesurmentUnit,
                    FrequencyOfMedicationUse=frequencyOfMedicationUse,
                    Usage=usage
                  


                };

                var animal = _mappingService.Map<Medicines>(medicinesAnimal);
                _appDbContext.Medicines.Add(animal);
                await _appDbContext.SaveChangesAsync();

            }
            else
            {
                throw new Exception($"Životinj {animalExists.IdAnimal} ne postoji!");
            }
        }



        async Task IRepository.AddFunds(int adopterId, decimal amount, string purpose)
        {
            var adopterExists = await _appDbContext.Adopter.FirstOrDefaultAsync(a => a.Id == adopterId);
            if (adopterExists != null)
            {
                var  funds = new FundsDomain
                {
                    AdopterId=adopterId,
                    Amount=amount,
                    Purpose=purpose,

                    


                };

                var fundsResponse = _mappingService.Map<Funds>(funds);
                _appDbContext.Funds.Add(fundsResponse);
                await _appDbContext.SaveChangesAsync();

            }
            else
            {
                throw new Exception($"Adopter {adopterExists.Id} ne postoji!");
            }
        }



   public   async  Task AddEuthanasia(int animalId, DateTime date, string nameOfDesissse, bool complited)
        {
            var animalExists = await _appDbContext.Animals.FirstOrDefaultAsync(a => a.IdAnimal == animalId);
            if (animalExists != null)
            {
                var euthanasiaAnimal = new EuthanasiaDomain
                {
                    AnimalId=animalId,
                    Date=date,
                    NameOfDesissse=nameOfDesissse,
                    Complited=complited

                };

                var animal = _mappingService.Map<Euthanasia>(euthanasiaAnimal);
                _appDbContext.Euthanasia.Add(animal);
                await _appDbContext.SaveChangesAsync();

            }
            else
            {
                throw new Exception($"Životinj {animalExists.IdAnimal} ne postoji!");
            }
        }



       public async Task AddContageus(int animalId, string desisseName, DateTime startTime, string description, bool contageus)
        {
            var animalExists = await _appDbContext.Animals.FirstOrDefaultAsync(a => a.IdAnimal == animalId);
            if (animalExists != null)
            {
                var contageusAnimal = new ContageusAnimalsDomain
                {
                   AnimalId = animalId,
                   DesisseName = desisseName,
                   StartTime = startTime,
                   Description = description,
                   Contageus=contageus

                };

                var animal = _mappingService.Map<ContageusAnimals>(contageusAnimal);
                _appDbContext.ContageusAnimals.Add(animal);
                await _appDbContext.SaveChangesAsync();

            }
            else
            {
                throw new Exception($"Životinj {animalExists.IdAnimal} ne postoji!");
            }
        }


      public async  Task AddContact(string name, string email, string description, int adopterId)
        {
            var adopterExists = await _appDbContext.Adopter.FirstOrDefaultAsync(a => a.Id == adopterId);
            if (adopterExists != null)
            {
                var contact = new ContactDomain
                {
                  Name= name,
                  Email= email,
                  Description= description,
                  AdopterId= adopterId



                };

                var contactResponse = _mappingService.Map<Contact>(contact);
                _appDbContext.Contact.Add(contactResponse);
                await _appDbContext.SaveChangesAsync();

            }
            else
            {
                throw new Exception($"Adopter {adopterExists.Id} ne postoji!");
            }
        }




     public async   Task AddBalans(string iban, string password, string type)
        {
            var balans = new BalansDomain
            {
              Iban = iban,
              Balance= 0,
           
              Password= password,
              Type= type



            };

            var balansResponse = _mappingService.Map<Balans>(balans);
            _appDbContext.Balans.Add(balansResponse);
            await _appDbContext.SaveChangesAsync();
        }

        //Novo 17/3/2025
        async Task<LabsDomain> IRepository.AddLab(int animalId, DateTime date)
        {

            var labs = new Labs
            {
                AnimalId = animalId,
                DateTime = date
            };

            var labResponse = _mappingService.Map<Labs>(labs);
            _appDbContext.Labs.Add(labResponse);
            await _appDbContext.SaveChangesAsync();
            return _mappingService.Map<LabsDomain>(labResponse);

        }

        async Task IRepository.AddParametar(ParameterDomain parametar)
        {
            var p = new ParameterDomain
            {
               LabId=parametar.LabId,
               ParameterName=parametar.ParameterName,
               ParameterValue=parametar.ParameterValue,
               Remarks=parametar.Remarks,
               MeasurementUnits=parametar.MeasurementUnits
            };

            var pResponse = _mappingService.Map<Parameter>(p);
            _appDbContext.Parameter.Add(pResponse);
            await _appDbContext.SaveChangesAsync();
        }



     
































































        //DELETE
        //----------------------------------------------------------------------------------------------------------------------------------------------


        async Task IRepository.DeleteNews(int id)
        {
            var newsRecord = await _appDbContext.News.FirstOrDefaultAsync(a => a.Id == id);

            if (newsRecord != null)
            {
               
             var response=   _appDbContext.News.Remove(newsRecord);
                await _appDbContext.SaveChangesAsync();
                

            }
        }






        public async void DeleteAdoptedReturn(int adoptedId)
        {

            var adoptedRecord = await _appDbContext.Adopted.FirstOrDefaultAsync(a => a.Code == adoptedId);

            if (adoptedRecord != null)
            {
                adoptedRecord.AdopterId = 0;
                _appDbContext.Adopted.Update(adoptedRecord);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAnimal(int idAnimal)
        {
            using var transaction = await _appDbContext.Database.BeginTransactionAsync();

            try
            {
                var animal = await _appDbContext.Animals.FirstOrDefaultAsync(a => a.IdAnimal == idAnimal);

                if (animal == null)
                {
                    throw new Exception($"Animal with IdAnimal {idAnimal} not found.");
                }

                // Log animal details
                Console.WriteLine($"Deleting animal: {animal.IdAnimal}, Family: {animal.Family}");

                if (animal.Adopted)
                {
                    throw new Exception($"Cannot delete an adopted animal (IdAnimal: {idAnimal}).");
                }

                var adoptedRecord = await _appDbContext.Set<Adopted>().FirstOrDefaultAsync(ad => ad.AnimalId == idAnimal);
                if (adoptedRecord != null)
                {
                    _appDbContext.Set<Adopted>().Remove(adoptedRecord);
                }

                var returnedAnimalRecord = await _appDbContext.Set<ReturnedAnimal>().FirstOrDefaultAsync(ra => ra.AnimalId == idAnimal);
                if (returnedAnimalRecord != null)
                {
                    _appDbContext.Set<ReturnedAnimal>().Remove(returnedAnimalRecord);
                }

                switch (animal.Family)
                {
                    case "Reptile":
                        var reptile = await _appDbContext.Set<Reptiles>().FirstOrDefaultAsync(r => r.AnimalId == idAnimal);
                        if (reptile != null)
                        {
                            _appDbContext.Set<Reptiles>().Remove(reptile);
                        }
                        break;

                    case "Mammal":
                        await _appDbContext.Database.ExecuteSqlRawAsync($"DELETE FROM Mammals WHERE AnimalId = {idAnimal}");
                        break;

                    case "Fish":
                        var fish = await _appDbContext.Set<Fish>().FirstOrDefaultAsync(f => f.AnimalId == idAnimal);
                        if (fish != null)
                        {
                            _appDbContext.Set<Fish>().Remove(fish);
                        }
                        break;

                    case "Bird":
                        var bird = await _appDbContext.Set<Birds>().FirstOrDefaultAsync(b => b.AnimalId == idAnimal);
                        if (bird != null)
                        {
                            _appDbContext.Set<Birds>().Remove(bird);
                        }
                        break;

                    case "Amphibian":
                        var amphibian = await _appDbContext.Set<Amphibians>().FirstOrDefaultAsync(a => a.AnimalId == idAnimal);
                        if (amphibian != null)
                        {
                            _appDbContext.Set<Amphibians>().Remove(amphibian);
                        }
                        break;

                    default:
                        throw new Exception($"Unknown animal family: {animal.Family}");
                }

                _appDbContext.Animals.Remove(animal);
                await _appDbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (DbUpdateException ex)
            {
                await transaction.RollbackAsync();
                var innerException = ex.InnerException;
                while (innerException != null)
                {
                    Console.WriteLine($"DbUpdateException Inner Exception: {innerException.Message}");
                    innerException = innerException.InnerException;
                }
                throw;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Console.WriteLine($"General Exception: {ex.Message}");
                throw new Exception($"Error occurred while deleting the animal: {ex.Message}");
            }
        }

        public async Task<bool> DeleteAdoptedAsync(int adoptedId)
        {
            var adopted = await _appDbContext.Adopted.FirstOrDefaultAsync(a => a.AnimalId == adoptedId);
            if (adopted == null)
            {
                return false;
            }

             _appDbContext.Adopted.Remove(adopted);
            _appDbContext.SaveChanges();
            return true;
        }

       
    }
}
