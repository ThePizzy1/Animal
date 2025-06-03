using ANIMAL.DAL.DataModel;
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
using DocumentFormat.OpenXml.Wordprocessing;

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
                    try
                    {
                        // Get all adopted animals that have not been returned
                        var animalDb = _appDbContext.Adopted
                            .Where(a => !_appDbContext.ReturnedAnimal.Any(ar => ar.AdoptionCode == a.Code))
                            .Include(a => a.Animal)
                            .ToList();

                        // Filter only those with RecordId == 7 and marked as adopted
                        var adoptedEntities = animalDb
                            .Where(a => _appDbContext.AnimalRecord
                                .Any(an => an.RecordId == 7 && an.AnimalId == a.Animal.IdAnimal && a.Animal.Adopted == true))
                            .ToList();

                        if (adoptedEntities == null || !adoptedEntities.Any())
                        {
                            throw new InvalidOperationException("No currently adopted animals found.");
                        }

                        var adoptedDomains = adoptedEntities.Select(e => new AdoptedDomain
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
                            AdoptionDate = e.AdoptionDate
                        }).ToList();

                        return adoptedDomains;
                    }
                    catch (Exception ex)
                    {
                        // Optional: add logging
                        throw new Exception("Error retrieving adopted animals: " + ex.Message, ex);
                    }
                }

                public IEnumerable<ReturnedAnimalDomain> GetAllReturnedAnimalDomain()
                        {
                            try
                            {
                                var returnedAnimalEntities = _appDbContext.ReturnedAnimal.ToList();

                                if (returnedAnimalEntities == null || !returnedAnimalEntities.Any())
                                {
                                    throw new InvalidOperationException("No returned animals found in the database.");
                                }

                                var returnedAnimalDomains = returnedAnimalEntities
                                    .Select(r => new ReturnedAnimalDomain(r))
                                    .ToList();

                                return returnedAnimalDomains;
                            }
                            catch (Exception ex)
                            {
                                // Optional: log the exception or handle it differently
                                throw new Exception("Error retrieving returned animal data: " + ex.Message, ex);
                            }
                        }

                public IEnumerable<AdopterDomain> GetAllAdopterDomain()
                        {
                            try
                            {
                                var adopterDb = _appDbContext.Adopter.ToList();

                                if (adopterDb == null || !adopterDb.Any())
                                {
                                    throw new InvalidOperationException("No adopters found in the database.");
                                }

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
                            catch (Exception ex)
                            {
                                // Optional: add logging here if needed
                                throw new Exception("Error retrieving adopters: " + ex.Message, ex);
                            }
                        }

                public AmphibianDomain GetAllAmphibianDomain(int id)
                        {
                            try
                            {
                                var amphibian = _appDbContext.Amphibians
                                    .Join(_appDbContext.Animals,
                                          a => a.AnimalId,
                                          an => an.IdAnimal,
                                          (a, an) => new { Amphibian = a, Animal = an })
                                    .Where(x => x.Animal.IdAnimal == id)
                                    .Select(e => new AmphibianDomain(
                                        e.Amphibian.AnimalId,
                                        e.Amphibian.Humidity,
                                        e.Amphibian.Temperature))
                                    .FirstOrDefault();

                                if (amphibian == null)
                                {
                                    throw new InvalidOperationException($"Thers no animal with AnimalId = {id}.");
                                }

                                return amphibian;
                            }
                            catch (Exception ex)
                            {
                                // Opcionalno logiranje
                                throw new Exception( ex.Message, ex);
                            }
                        }

                public IEnumerable<AnimalDomain> GetAllAnimalDomainAdopt()
                {
                    try
                    {
                        var animals = _appDbContext.Animals
                            .Where(a => _appDbContext.AnimalRecord.Any(ar => ar.RecordId == 6 && ar.AnimalId == a.IdAnimal))
                            .ToList();

                        if (animals == null || !animals.Any())
                        {
                            throw new InvalidOperationException("There's no animal with (RecordId == 6).");
                        }

                        var animalDomain = animals.Select(e => new AnimalDomain(
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
                            e.Adopted)).ToList();

                        return animalDomain;
                    }
                    catch (Exception ex)
                    {
                        // Opcionalno: ovdje možeš logirati grešku
                        throw new Exception( ex.Message, ex);
                    }
                }

                //samo životinje koje su broj 6 se smiju prikazati na glavnoj stranici za posvajanje, 6 odobrava veterinar
                public IEnumerable<AnimalDomain> GetAllAnimalDomain()
                {
                    var animals = _appDbContext.Animals
                        .Where(a => !_appDbContext.AnimalRecord.Any(ar => ar.RecordId == 8 && ar.AnimalId == a.IdAnimal))
                        .ToList();

                    if (animals == null || !animals.Any())
                    {
                        throw new InvalidOperationException("There's no animal with ( RecordId == 8).");
                    }

                    var animalDomain = animals.Select(e => new AnimalDomain(
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
                        .ToList();

                    return animalDomain;
                }

                 public IEnumerable<AnimalDomain> GetAllAnimalDomainNoPicture()
        {
            try
            {
                // Get all animals that are NOT marked as deceased (RecordId != 8)
                var animalDb = _appDbContext.Animals
                    .Where(a => _appDbContext.AnimalRecord
                        .Any(ar => ar.RecordId != 8 && ar.AnimalId == a.IdAnimal))
                    .ToList();

                if (animalDb == null || !animalDb.Any())
                {
                    throw new InvalidOperationException("No valid (non-deceased) animals found in the database.");
                }

                // Project to AnimalDomain without the Picture field
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
                    picture: null, // Explicitly omit picture
                    e.PersonalityDescription,
                    e.Adopted
                )).ToList();

                return animalDomain;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving animals without pictures: " + ex.Message, ex);
            }
        }


        //Get all novo
            IEnumerable<AnimalRecordDomain> IRepository.GetAllAnimalRecordDomain()
            {
                try
                {
                    var animalDb = _appDbContext.AnimalRecord.ToList();

                    if (animalDb == null || !animalDb.Any())
                        throw new InvalidOperationException("No animal records found.");

                    return animalDb.Select(e => new AnimalRecordDomain(
                        e.AnimalId,
                        e.RecordId
                    ));
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving animal records: " + ex.Message, ex);
                }
            }

            IEnumerable<BalansDomain> IRepository.GetAllBlansDomain()
            {
                try
                {
                    var balansDb = _appDbContext.Balans.ToList();

                    if (balansDb == null || !balansDb.Any())
                        throw new InvalidOperationException("No balance records found.");

                    return balansDb.Select(e => new BalansDomain(
                        e.Id,
                        e.Iban,
                        e.Balance,
                        e.LastUpdated,
                        e.Password,
                        e.Type
                    ));
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving balance records: " + ex.Message, ex);
                }
            }

            IEnumerable<ContactDomain> IRepository.GetaAllContactDomain()
            {
                try
                {
                    var contactDb = _appDbContext.Contact.ToList();

                    if (contactDb == null || !contactDb.Any())
                        throw new InvalidOperationException("No contact records found.");

                    return contactDb.Select(e => new ContactDomain(
                        e.Id,
                        e.Name,
                        e.Email,
                        e.Description,
                        e.AdopterId,
                        e.Read
                    ));
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving contact records: " + ex.Message, ex);
                }
            }

            IEnumerable<ContageusAnimalsDomain> IRepository.GetAllContageusAnimalsDomain()
            {
                try
                {
                    var contagiousDb = _appDbContext.ContageusAnimals.ToList();

                    if (contagiousDb == null || !contagiousDb.Any())
                        throw new InvalidOperationException("No contagious animal records found.");

                    return contagiousDb.Select(e => new ContageusAnimalsDomain(
                        e.Id,
                        e.AnimalId,
                        e.DesisseName,
                        e.Description,
                        e.Contageus
                    ));
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving contagious animal records: " + ex.Message, ex);
                }
            }

            IEnumerable<EuthanasiaDomain> IRepository.GetAllEuthanasiaDomain()
            {
                try
                {
                    var euthanasiaDb = _appDbContext.Euthanasia.ToList();

                    if (euthanasiaDb == null || !euthanasiaDb.Any())
                        throw new InvalidOperationException("No euthanasia records found.");

                    return euthanasiaDb.Select(e => new EuthanasiaDomain(
                        e.Id,
                        e.AnimalId,
                        e.Date,
                        e.NameOfDesissse
                    ));
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving euthanasia records: " + ex.Message, ex);
                }
            }

            IEnumerable<FoodDomain> IRepository.GetAllFoodDomain()
            {
                try
                {
                    var foodDb = _appDbContext.Food.ToList();

                    if (foodDb == null || !foodDb.Any())
                        throw new InvalidOperationException("No food records found.");

                    return foodDb.Select(e => new FoodDomain(
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
                        e.MeasurementWeight,
                        e.Price
                    ));
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving food records: " + ex.Message, ex);
                }
            }

            IEnumerable<FoundRecordDomain> IRepository.GetAllFoundRecord()
            {
                try
                {
                    var foundDb = _appDbContext.FoundRecord.ToList();

                    if (foundDb == null || !foundDb.Any())
                        throw new InvalidOperationException("No found animal records found.");

                    return foundDb.Select(e => new FoundRecordDomain(
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
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving found records: " + ex.Message, ex);
                }
            }

            IEnumerable<FundsDomain> IRepository.GetAllFundsDomain()
            {
                try
                {
                    var fundDb = _appDbContext.Funds.ToList();

                    if (fundDb == null || !fundDb.Any())
                        throw new InvalidOperationException("No funds records found.");

                    return fundDb.Select(e => new FundsDomain(
                        e.Id,
                        e.AdopterId,
                        e.Amount,
                        e.Purpose,
                        e.DateTimed,
                        e.Iban
                    ));
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving funds records: " + ex.Message, ex);
                }
            }

            IEnumerable<LabsDomain> IRepository.GetAllLabsDomain()
            {
                try
                {
                    var labDb = _appDbContext.Labs.ToList();

                    if (labDb == null || !labDb.Any())
                        throw new InvalidOperationException("No lab records found.");

                    return labDb.Select(e => new LabsDomain(
                        e.Id,
                        e.AnimalId,
                        e.DateTime
                    ));
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving lab records: " + ex.Message, ex);
                }
            }

            IEnumerable<MedicinesDomain> IRepository.GetAllMedicinesDomain()
            {
                try
                {
                    var medicinesDb = _appDbContext.Medicines.ToList();

                    if (medicinesDb == null || !medicinesDb.Any())
                        throw new InvalidOperationException("No medicines records found.");

                    return medicinesDb.Select(e => new MedicinesDomain(
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
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving medicines records: " + ex.Message, ex);
                }
            }

            IEnumerable<NewsDomain> IRepository.GetAllNewsDomain()
            {
                try
                {
                    var newsDb = _appDbContext.News.ToList();

                    if (newsDb == null || !newsDb.Any())
                        throw new InvalidOperationException("No news records found.");

                    return newsDb.Select(e => new NewsDomain(
                        e.Id,
                        e.Name,
                        e.Description,
                        e.DateTime
                    ));
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving news records: " + ex.Message, ex);
                }
            }

            IEnumerable<ParameterDomain> IRepository.GetAllParameterDomain(int id)
            {
                try
                {
                    var parameterDb = _appDbContext.Parameter.Where(a => a.LabId == id).ToList();

                    if (parameterDb == null || !parameterDb.Any())
                        throw new InvalidOperationException($"No parameters found for LabId = {id}.");

                    return parameterDb.Select(e => new ParameterDomain(
                        e.Id,
                        e.LabId,
                        e.ParameterName,
                        e.ParameterValue,
                        e.Remarks,
                        e.MeasurementUnits
                    ));
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error retrieving parameters for LabId {id}: " + ex.Message, ex);
                }
            }

            IEnumerable<SystemRecordDomain> IRepository.GetAllSystemRecordDomain()
            {
                try
                {
                    var systemDb = _appDbContext.SystemRecord.ToList();

                    if (systemDb == null || !systemDb.Any())
                        throw new InvalidOperationException("No system records found.");

                    return systemDb.Select(e => new SystemRecordDomain(
                        e.Id,
                        e.RecordName,
                        e.RecordDescription
                    ));
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving system records: " + ex.Message, ex);
                }
            }

            IEnumerable<ToysDomain> IRepository.GetAllToysDomain()
            {
                try
                {
                    var toysDb = _appDbContext.Toys.ToList();

                    if (toysDb == null || !toysDb.Any())
                        throw new InvalidOperationException("No toys records found.");

                    return toysDb.Select(e => new ToysDomain(
                        e.Id,
                        e.BrandName,
                        e.Name,
                        e.AnimalType,
                        e.ToyType,
                        e.AgeGroup,
                        e.Hight,
                        e.Width,
                        e.Quantity,
                        e.Notes,
                        e.Price
                    ));
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving toys records: " + ex.Message, ex);
                }
            }

            IEnumerable<VetVisitsDomain> IRepository.GetAllVetVisitsDomain()
            {
                try
                {
                    var vetVisitDb = _appDbContext.VetVisits.ToList();

                    if (vetVisitDb == null || !vetVisitDb.Any())
                        throw new InvalidOperationException("No vet visit records found.");

                    return vetVisitDb.Select(e => new VetVisitsDomain(
                        e.Id,
                        e.AnimalId,
                        e.StartTime,
                        e.EndTime,
                        e.TypeOfVisit,
                        e.Notes
                    ));
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving vet visit records: " + ex.Message, ex);
                }
            }

            IEnumerable<TransactionsDomain> IRepository.GetAllTransactionsDomain()
        {
            try
            {
                var transactionsDb = _appDbContext.Transactions.ToList();

                if (transactionsDb == null || !transactionsDb.Any())
                    throw new InvalidOperationException("No transaction records found.");

                var transactionsDomain = transactionsDb.Select(e => new TransactionsDomain(
                    e.Id,
                    e.Iban,
                    e.IbanAnimalShelter,
                    e.Type,
                    e.Date,
                    e.Cost,
                    e.Purpose
                ));

                return transactionsDomain;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving transaction records: " + ex.Message, ex);
            }
        }


        //GET BY ID
        //----------------------------------------------------------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------------------------------------------------------
            public BirdDomain GetAllBirdDomain(int id)
            {
                try
                {
                    var bird = _appDbContext.Birds
                        .Join(_appDbContext.Animals, b => b.AnimalId, a => a.IdAnimal,
                            (b, a) => new { Bird = b, Animal = a })
                        .Where(x => x.Animal.IdAnimal == id)
                        .Select(x => new BirdDomain(
                            x.Animal.IdAnimal,
                            x.Bird.CageSize,
                            x.Bird.RecommendedToys,
                            x.Bird.Sociability))
                        .FirstOrDefault();

                    if (bird == null)
                        throw new KeyNotFoundException($"Bird with AnimalId {id} not found.");

                    return bird;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error retrieving BirdDomain for AnimalId {id}: {ex.Message}", ex);
                }
            }

            public FishDomain GetAllFishDomain(int id)
            {
                try
                {
                    var fish = _appDbContext.Fish
                        .Join(_appDbContext.Animals, f => f.AnimalId, a => a.IdAnimal,
                            (f, a) => new { Fish = f, Animal = a })
                        .Where(x => x.Animal.IdAnimal == id)
                        .Select(x => new FishDomain(
                            x.Animal.IdAnimal,
                            x.Fish.TankSize,
                            x.Fish.CompatibleSpecies,
                            x.Fish.RecommendedItems))
                        .FirstOrDefault();

                    if (fish == null)
                        throw new KeyNotFoundException($"Fish with AnimalId {id} not found.");

                    return fish;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error retrieving FishDomain for AnimalId {id}: {ex.Message}", ex);
                }
            }

            public MammalDomain GetAllMammalDomain(int id)
            {
                try
                {
                    var mammal = _appDbContext.Mammals
                        .Join(_appDbContext.Animals, m => m.AnimalId, a => a.IdAnimal,
                            (m, a) => new { Mammal = m, Animal = a })
                        .Where(x => x.Animal.IdAnimal == id)
                        .Select(x => new MammalDomain(
                            x.Animal.IdAnimal,
                            x.Mammal.CoatType,
                            x.Mammal.GroomingProducts))
                        .FirstOrDefault();

                    if (mammal == null)
                        throw new KeyNotFoundException($"Mammal with AnimalId {id} not found.");

                    return mammal;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error retrieving MammalDomain for AnimalId {id}: {ex.Message}", ex);
                }
            }

            public ReptileDomain GetAllReptileDomain(int id)
            {
                try
                {
                    var reptile = _appDbContext.Reptiles
                        .Join(_appDbContext.Animals, r => r.AnimalId, a => a.IdAnimal,
                            (r, a) => new { Reptile = r, Animal = a })
                        .Where(x => x.Animal.IdAnimal == id)
                        .Select(x => new ReptileDomain(
                            x.Animal.IdAnimal,
                            x.Reptile.TankSize,
                            x.Reptile.Sociability,
                            x.Reptile.CompatibleSpecies,
                            x.Reptile.RecommendedItems))
                        .FirstOrDefault();

                    if (reptile == null)
                        throw new KeyNotFoundException($"Reptile with AnimalId {id} not found.");

                    return reptile;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error retrieving ReptileDomain for AnimalId {id}: {ex.Message}", ex);
                }
            }

            public AnimalDomain GetAnimalById(int animalId)
            {
                try
                {
                    var animalData = _appDbContext.Animals
                        .Where(a => a.IdAnimal == animalId
                                    && _appDbContext.AnimalRecord.Any(an => an.AnimalId == animalId && an.RecordId != 7))
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

                    if (animalData == null)
                        throw new KeyNotFoundException($"Animal with ID {animalId} not found or has RecordId 7 (excluded).");

                    return animalData;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error retrieving AnimalDomain for ID {animalId}: {ex.Message}", ex);
                }
            }

            public AnimalDomain GetAllAnimalById(int animalId)
            {
                if (animalId <= 0)
                    return null;

                var animalData = _appDbContext.Animals
                    .Where(a => a.IdAnimal == animalId)
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
                if (string.IsNullOrWhiteSpace(id))
                    return null;

                var adopterDb = _appDbContext.Adopter.FirstOrDefault(a => a.RegisterId == id);

                if (adopterDb == null)
                    return null;

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
                if (adopterId <= 0)
                    return Enumerable.Empty<AdoptedDomain>();

                // Dohvati posvojene koje nisu vraćene (pretpostavka: Adopted kod nije u ReturnedAnimal)
                var animalDb = _appDbContext.Adopted
                    .Where(a => !_appDbContext.ReturnedAnimal.Any(ar => ar.AdoptionCode == a.Code))
                    .Include(a => a.Animal)
                    .Include(a => a.Adopter)
                    .ToList();

                if (!animalDb.Any())
                    return Enumerable.Empty<AdoptedDomain>();

                // Filtriraj po udomitelju i životinjama sa RecordId 7 (npr. status "posvojeno")
                var adoptedEntities = animalDb
                    .Where(a => _appDbContext.AnimalRecord
                        .Any(an => an.RecordId == 7 && a.AdopterId == adopterId))
                    .ToList();

                if (!adoptedEntities.Any())
                    return Enumerable.Empty<AdoptedDomain>();

                var adoptedDomains = adoptedEntities.Select(e => new AdoptedDomain
                {
                    Code = e.Code,
                    Animal = e.Animal == null ? null : new AnimalDomain(
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
                        e.Animal.Adopted),
                    AdoptionDate = e.AdoptionDate,
                    Adopter = e.Adopter == null ? null : new AdopterDomain(
                        e.Adopter.Id,
                        e.Adopter.FirstName,
                        e.Adopter.LastName,
                        e.Adopter.Residence,
                        e.Adopter.DateOfBirth,
                        e.Adopter.NumAdoptedAnimals,
                        e.Adopter.NumReturnedAnimals)
                }).ToList();

                return adoptedDomains;
            }

            public async Task<Animals> GetByIdAsync(int id)
            {
                if (id <= 0)
                    return null;

                return await _appDbContext.Animals.FirstOrDefaultAsync(a => a.IdAnimal == id);
            }

            public IEnumerable<ReturnedAnimalDomain> GetAllReturnedAnimalsForAdopter(int adopterId)
            {
                if (adopterId <= 0)
                    return Enumerable.Empty<ReturnedAnimalDomain>();

                var returnedAnimalEntities = _appDbContext.ReturnedAnimal
                    .Where(ra => ra.AdopterId == adopterId)
                    .Include(ra => ra.Animal)
                    .Include(ra => ra.Adopter)
                    .ToList();

                if (!returnedAnimalEntities.Any())
                    return Enumerable.Empty<ReturnedAnimalDomain>();

                var returnedAnimalDomains = returnedAnimalEntities.Select(e => new ReturnedAnimalDomain
                {
                    ReturnCode = e.ReturnCode,
                    AdoptionCode = e.AdoptionCode,
                    AnimalId = e.AnimalId,
                    AdopterId = e.AdopterId,
                    ReturnDate = e.ReturnDate,
                    ReturnReason = e.ReturnReason,
                    Animal = e.Animal == null ? null : new AnimalDomain(
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
                        e.Animal.Adopted)
                }).ToList();

                return returnedAnimalDomains;
            }

            AdopterDomain IRepository.GetAdopterByUsername(string username)
            {
                if (string.IsNullOrWhiteSpace(username))
                    return null;

                var adopterDb = _appDbContext.Adopter.FirstOrDefault(a => a.Username == username);

                if (adopterDb == null)
                    return null;

                return new AdopterDomain(
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
            }



        //get by id novo// TREBALO BI BIT GOTOVO
        //---------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------
            AdopterDomain IRepository.GetAdopterByIdInt(int id)
            {
                if (id <= 0)
                    return null;

                var adopterDb = _appDbContext.Adopter.FirstOrDefault(a => a.Id == id);
                if (adopterDb == null) return null;

                return new AdopterDomain(
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
            }

            ToysDomain IRepository.GetOneToysDomain(int id)
            {
                if (id <= 0)
                    return null;

                var toyDb = _appDbContext.Toys.FirstOrDefault(t => t.Id == id);
                if (toyDb == null) return null;

                return new ToysDomain(
                    toyDb.Id,
                    toyDb.BrandName,
                    toyDb.Name,
                    toyDb.AnimalType,
                    toyDb.ToyType,
                    toyDb.AgeGroup,
                    toyDb.Hight,
                    toyDb.Width,
                    toyDb.Quantity,
                    toyDb.Notes,
                    toyDb.Price);
            }

            NewsDomain IRepository.GetOneNewsDomain(int id)
            {
                if (id <= 0)
                    return null;

                var newsDb = _appDbContext.News.FirstOrDefault(n => n.Id == id);
                if (newsDb == null) return null;

                return new NewsDomain(
                    newsDb.Id,
                    newsDb.Name,
                    newsDb.Description,
                    newsDb.DateTime);
            }

            FoodDomain IRepository.GetOneFoodDomain(int id)
            {
                if (id <= 0)
                    return null;

                var foodDb = _appDbContext.Food.FirstOrDefault(f => f.Id == id);
                if (foodDb == null) return null;

                return new FoodDomain(
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
                    foodDb.MeasurementWeight,
                    foodDb.Price);
            }

            BalansDomain IRepository.GetOneBalansDomain(int id)
            {
                if (id <= 0)
                    return null;

                var balansDb = _appDbContext.Balans.FirstOrDefault(b => b.Id == id);
                if (balansDb == null) return null;

                return new BalansDomain(
                    balansDb.Id,
                    balansDb.Iban,
                    balansDb.Balance,
                    balansDb.LastUpdated,
                    balansDb.Password,
                    balansDb.Type);
            }


            //kako složit da includa i podatke iz druge klase
            public MedicinesDomain GetOneMedicinesDomain(int id)
            {
                if (id <= 0)
                    return null;

                var medicine = _appDbContext.Medicines
                    .Where(m => m.Id == id)
                    .Select(m => new MedicinesDomain(
                        m.Id,
                        m.AnimalId,
                        m.NameOfMedicines,
                        m.Description,
                        m.VetUsername,
                        m.AmountOfMedicine,
                        m.MesurmentUnit,
                        m.MedicationIntake,
                        m.FrequencyOfMedicationUse,
                        m.Usage))
                    .FirstOrDefault();

                return medicine;
            }

            public LabsDomain GetOneLabsDomain(int id)
            {
                if (id <= 0)
                    return null;

                var lab = _appDbContext.Labs
                    .Where(l => l.Id == id)
                    .Select(l => new LabsDomain(
                        l.Id,
                        l.AnimalId,
                        l.DateTime))
                    .FirstOrDefault();

                return lab;
            }

            public FundsDomain GetOneFundsDomain(int id)
            {
                if (id <= 0)
                    return null;

                var fund = _appDbContext.Funds
                    .Where(f => f.Id == id)
                    .Select(f => new FundsDomain(
                        f.Id,
                        f.AdopterId,
                        f.Amount,
                        f.Purpose,
                        f.DateTimed,
                        f.Iban))
                    .FirstOrDefault();

                return fund;
            }

            public FoundRecordDomain GetOneFoundRecordDomain(int id)
            {
                if (id <= 0)
                    return null;

                var foundRecord = _appDbContext.FoundRecord
                    .Where(fr => fr.Id == id)
                    .Select(fr => new FoundRecordDomain(
                        fr.Id,
                        fr.AnimalId,
                        fr.Date,
                        fr.Adress,
                        fr.Description,
                        fr.OwnerName,
                        fr.OwnerSurname,
                        fr.OwnerPhoneNumber,
                        fr.OwnerOIB,
                        fr.RegisterId))
                    .FirstOrDefault();

                return foundRecord;
            }

            public EuthanasiaDomain GetOneEuthanasiaDomain(int id)
            {
                if (id <= 0)
                    return null;

                var euthanasia = _appDbContext.Euthanasia
                    .Where(e => e.Id == id)
                    .Select(e => new EuthanasiaDomain(
                        e.Id,
                        e.AnimalId,
                        e.Date,
                        e.NameOfDesissse))
                    .FirstOrDefault();

                return euthanasia;
            }

            public ContageusAnimalsDomain GetOneContageusAnimalsDomain(int id)
            {
                if (id <= 0)
                    return null;

                var contageusAnimal = _appDbContext.ContageusAnimals
                    .Where(ca => ca.Id == id)
                    .Select(ca => new ContageusAnimalsDomain(
                        ca.Id,
                        ca.AnimalId,
                        ca.DesisseName,
                        ca.Description,
                        ca.Contageus))
                    .FirstOrDefault();

                return contageusAnimal;
            }

            public ContactDomain GetOneContactDomain(int id)
            {
                if (id <= 0)
                    return null;

                var contact = _appDbContext.Contact
                    .Where(c => c.Id == id)
                    .Select(c => new ContactDomain(
                        c.Id,
                        c.Name,
                        c.Email,
                        c.Description,
                        c.AdopterId,
                        c.Read))
                    .FirstOrDefault();

                return contact;
            }


        //-----------------------------------------------------------------------------------------------------------------------
        //Get one by id animal
            public MedicinesDomain GetOneMedicinesAnimal(int animalId)
            {
                if (animalId <= 0)
                    return null;

                var meds = _appDbContext.Medicines
                    .Where(m => m.AnimalId == animalId)
                    .Select(m => new MedicinesDomain(
                        m.Id,
                        m.AnimalId,
                        m.NameOfMedicines,
                        m.Description,
                        m.VetUsername,
                        m.AmountOfMedicine,
                        m.MesurmentUnit,
                        m.MedicationIntake,
                        m.FrequencyOfMedicationUse,
                        m.Usage))
                    .FirstOrDefault();

                return meds;
            }

            public ContageusAnimalsDomain GetOneContageusAnimal(int animalId)
            {
                if (animalId <= 0)
                    return null;

                var contageusAnimal = _appDbContext.ContageusAnimals
                    .Where(ca => ca.AnimalId == animalId)
                    .Select(ca => new ContageusAnimalsDomain(
                        ca.Id,
                        ca.AnimalId,
                        ca.DesisseName,
                        ca.Description,
                        ca.Contageus))
                    .FirstOrDefault();

                return contageusAnimal;
            }

            public LabsDomain GetOneLabsAnimal(int animalId)
            {
                if (animalId <= 0)
                    return null;

                var labs = _appDbContext.Labs
                    .Where(l => l.AnimalId == animalId)
                    .Select(l => new LabsDomain(
                        l.Id,
                        l.AnimalId,
                        l.DateTime))
                    .FirstOrDefault();

                return labs;
            }

            public VetVisitsDomain GetOneVetVisitAnimal(int animalId)
            {
                if (animalId <= 0)
                    return null;

                var visit = _appDbContext.VetVisits
                    .Where(v => v.AnimalId == animalId)
                    .Select(v => new VetVisitsDomain(
                        v.Id,
                        v.AnimalId,
                        v.StartTime,
                        v.EndTime,
                        v.TypeOfVisit,
                        v.Notes))
                    .FirstOrDefault();

                return visit;
            }

            public AnimalRecordDomain GetOneAnimalRecord(int animalId)
            {
                if (animalId <= 0)
                    throw new ArgumentException("Invalid animal id");

                var recordEntity = _appDbContext.AnimalRecord
                    .Include(ar => ar.Animal)
                    .Include(ar => ar.Record)
                    .FirstOrDefault(ar => ar.AnimalId == animalId);

                if (recordEntity == null)
                    throw new Exception("Record not found");

                var recordDomain = new AnimalRecordDomain
                {
                    Animal = new AnimalDomain(
                        recordEntity.Animal.IdAnimal,
                        recordEntity.Animal.Name,
                        recordEntity.Animal.Species,
                        recordEntity.Animal.Family,
                        recordEntity.Animal.Subspecies,
                        recordEntity.Animal.Age,
                        recordEntity.Animal.Gender,
                        recordEntity.Animal.Weight,
                        recordEntity.Animal.Height,
                        recordEntity.Animal.Length,
                        recordEntity.Animal.Neutered,
                        recordEntity.Animal.Vaccinated,
                        recordEntity.Animal.Microchipped,
                        recordEntity.Animal.Trained,
                        recordEntity.Animal.Socialized,
                        recordEntity.Animal.HealthIssues,
                        recordEntity.Animal.Picture,
                        recordEntity.Animal.PersonalityDescription,
                        recordEntity.Animal.Adopted
                    ),
                    Record = new SystemRecordDomain(
                        recordEntity.Record.Id,
                        recordEntity.Record.RecordName,
                        recordEntity.Record.RecordDescription
                    )
                };

                return recordDomain;
            }


        //UPDATE
        //----------------------------------------------------------------------------------------------------------------------------------------------

            public async Task<bool> UpdateAdopterFlag(int adopterId)
            {
                var adopter = await _appDbContext.Adopter.FindAsync(adopterId);
                if (adopter == null)
                    return false;

                adopter.Flag = true;
                await _appDbContext.SaveChangesAsync();
                return true;
            }

            public async Task IncrementNumberOfAdoptedAnimalsAsync(string registerId)
            {
                var adopter = await _appDbContext.Adopter.FirstOrDefaultAsync(a => a.RegisterId == registerId);
                if (adopter != null)
                {
                    adopter.NumAdoptedAnimals++;
                    await _appDbContext.SaveChangesAsync();
                }
            }

            public async Task IncrementNumberOfReturnedAnimalsAsync(string registerId)
            {
                var adopter = await _appDbContext.Adopter.FirstOrDefaultAsync(a => a.RegisterId == registerId);
                if (adopter != null)
                {
                    adopter.NumReturnedAnimals++;
                    await _appDbContext.SaveChangesAsync();
                }
            }

            public async Task<AdopterDomain> UpdateAdopterAsync(string registerId, string firstName, string lastName, DateTime dateOfBirth, string residence, string username, string password)
            {
                var adopter = await _appDbContext.Adopter.FirstOrDefaultAsync(a => a.RegisterId == registerId);
                if (adopter == null)
                    throw new Exception("Adopter not found");

                adopter.FirstName = firstName;
                adopter.LastName = lastName;
                adopter.DateOfBirth = dateOfBirth;
                adopter.Residence = residence;
                adopter.Username = username;
                adopter.Password = password;

                await _appDbContext.SaveChangesAsync();

                return _mappingService.Map<AdopterDomain>(adopter);
            }

            public async Task<AnimalDomain> UpdateAnimalAsync(int idAnimal, int age, decimal weight, decimal height, decimal length, bool neutered, bool vaccinated, bool microchipped, bool trained, bool socialized, string healthIssues, string personalityDescription)
            {
                var animal = await _appDbContext.Animals.FindAsync(idAnimal);
                if (animal == null)
                    throw new Exception("Animal not found");

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

                await _appDbContext.SaveChangesAsync();

                return _mappingService.Map<AnimalDomain>(animal);
            }

            public async Task<bool> AdoptionStatus(int animalId)
            {
                var animal = await _appDbContext.Animals.FirstOrDefaultAsync(a => a.IdAnimal == animalId);

                if (animal == null)
                {
                    // Životinja nije pronađena
                    return false;
                }

                if (animal.Adopted == true)
                {
                    // Već je postavljeno na true, nema potrebe za updateom
                    return true;
                }

                animal.Adopted = true;
                await _appDbContext.SaveChangesAsync();
                return true;
            }

            public async Task<bool> AdoptionStatusFalse(int animalId)
            {
                var animal = await _appDbContext.Animals.FirstOrDefaultAsync(a => a.IdAnimal == animalId);

                if (animal == null)
                {
                    // Životinja nije pronađena
                    return false;
                }

                if (animal.Adopted == false)
                {
                    // Već je postavljeno na false, nema potrebe za updateom
                    return true;
                }

                animal.Adopted = false;
                await _appDbContext.SaveChangesAsync();
                return true;
            }



        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //update novo
            async Task<bool> IRepository.UpdateParametar(ParameterDomain p)
            {
                if (p == null)
                {
                    throw new ArgumentNullException(nameof(p), "ParameterDomain cannot be null");
                }

                // Provjeri postoji li parametar s danim ID-em u bazi
                var parametar = await _appDbContext.Parameter.FirstOrDefaultAsync(a => a.Id == p.Id);

                if (parametar == null)
                {
                    // Parametar nije pronađen
                    return false;
                }

                // Opcionalno: možeš dodati validaciju pojedinih svojstava p ovdje, npr.
                if (string.IsNullOrWhiteSpace(p.ParameterName))
                {
                    throw new ArgumentException("ParameterName cannot be empty", nameof(p.ParameterName));
                }

                // Ažuriraj svojstva
                parametar.ParameterValue = p.ParameterValue;
                parametar.ParameterName = p.ParameterName;
                parametar.Remarks = p.Remarks;
                parametar.MeasurementUnits = p.MeasurementUnits;

                _appDbContext.Parameter.Update(parametar);
                await _appDbContext.SaveChangesAsync();

                return true;
            }

            public async Task UpdateAnimalRecordDomain(int animalId, int newRecordId)
            {
                // Fetch required data
                var animalRecord = await _appDbContext.AnimalRecord.FirstOrDefaultAsync(a => a.AnimalId == animalId);
                var euthanasia = await _appDbContext.Euthanasia.FirstOrDefaultAsync(e => e.AnimalId == animalId);
                var hasVetVisit = await _appDbContext.VetVisits.AnyAsync(v => v.AnimalId == animalId);

                if (animalRecord == null)
                    throw new Exception("Animal record not found.");

                if (euthanasia != null)
                    throw new Exception("Animal has been euthanized. Status cannot be changed.");

                var currentStatus = animalRecord.RecordId;

                switch (newRecordId)
                {
                    case 1: // Arrival
                        if (currentStatus == 1)
                            break;
                        throw new Exception("Arrival status can only be set during initial registration.");

                    case 2: // First Vet Visit
                        if (currentStatus == 1 && hasVetVisit)
                            break;
                        throw new Exception("First Vet Visit requires animal to be in Arrival state and have at least one vet visit recorded.");

                    case 3: // Quarantine
                        if (currentStatus >= 2 && currentStatus != 7 && currentStatus != 8)
                            break;
                        throw new Exception("Quarantine can only follow First Vet Visit and not after Adoption or Euthanasia.");

                    case 4: // Shelter
                        if (currentStatus == 3)
                            break;
                        throw new Exception("Shelter status can only follow Quarantine.");

                    case 5: // Socialized
                        if (currentStatus == 4)
                            break;
                        throw new Exception("Socialized status can only follow Shelter.");

                    case 6: // Approved for Adoption
                        if (currentStatus == 5)
                            break;
                        throw new Exception("Approval for adoption requires the animal to be Socialized.");

                    case 7: // Adopted
                        if (currentStatus == 6)
                            break;
                        throw new Exception("Animal must be approved for adoption before it can be adopted.");

                    case 8: // Euthanasia
                        if (currentStatus != 7)
                            break;
                        throw new Exception("Euthanasia can only be performed if the animal has not been adopted.");

                    case 9: // Returned
                        if (currentStatus != 8)
                            break;
                        throw new Exception("Returned status is only valid after euthanasia. Restart process from Quarantine.");

                    default:
                        throw new Exception("Invalid status ID.");
                }

                // Update status
                animalRecord.RecordId = newRecordId;
                _appDbContext.AnimalRecord.Update(animalRecord);
                await _appDbContext.SaveChangesAsync();
            }

            public async Task<bool> UpdateAnimalBalansDomain(int id, decimal balance)
            {
                var balans = await _appDbContext.Balans.FirstOrDefaultAsync(a => a.Id == id);
                if (balans == null)
                    throw new Exception("Balance record not found.");

                if (balans.Balance == null)
                {
                    balans.Balance = balance;
                }
                else
                {
                    balans.Balance = balans.Balance + balance;
                }

                _appDbContext.Balans.Update(balans);
                await _appDbContext.SaveChangesAsync();

                return true;
            }

            public async Task<bool> UpdateContageusAnimalsDomain(int id, bool contageus)
            {
                var animal = await _appDbContext.ContageusAnimals.FirstOrDefaultAsync(a => a.Id == id);
                if (animal == null)
                    throw new Exception("Contagious animal record not found.");

                animal.Contageus = contageus;

                _appDbContext.ContageusAnimals.Update(animal);
                await _appDbContext.SaveChangesAsync();

                return true;
            }

            public async Task<bool> UpdateEuthanasiaDomain(int id, DateTime date, bool complited)
            {
                var animal = await _appDbContext.Euthanasia.FirstOrDefaultAsync(a => a.Id == id);
                if (animal == null)
                    throw new Exception("Euthanasia record not found.");

                animal.Date = date;
                animal.Complited = complited;

                _appDbContext.Euthanasia.Update(animal);
                await _appDbContext.SaveChangesAsync();

                return true;
            }

            public async Task<bool> UpdateFoodDomainIncrement(int id)
            {
                var food = await _appDbContext.Food.FirstOrDefaultAsync(a => a.Id == id);
                if (food == null)
                    throw new Exception("Food record not found.");

                var quantity = food.Quantity + 1;
                food.Quantity = quantity;

                _appDbContext.Food.Update(food);
                await _appDbContext.SaveChangesAsync();

                return true;
            }

            public async Task<bool> UpdateFoodDomainDecrement(int id)
            {
                var food = await _appDbContext.Food.FirstOrDefaultAsync(a => a.Id == id);
                if (food == null)
                    throw new Exception("Food record not found.");

                if (food.Quantity <= 0)
                    throw new Exception("Food quantity cannot go below zero.");

                var quantity = food.Quantity - 1;
                food.Quantity = quantity;

                _appDbContext.Food.Update(food);
                await _appDbContext.SaveChangesAsync();

                return true;
            }

        //ažurira se ako postoji greška u nazivu hrane itd
            public async Task<bool> UpdateFoodDomain(FoodDomain foods)
            {
                var food = await _appDbContext.Food.FirstOrDefaultAsync(a => a.Id == foods.Id);
                if (food == null)
                    throw new Exception($"Food with ID {foods.Id} not found.");

                food.BrandName = foods.BrandName;
                food.Name = foods.Name;
                food.FoodType = foods.FoodType;
                food.AnimalType = foods.AnimalType;
                food.AgeGroup = foods.AgeGroup;
                food.Weight = foods.Weight;
                food.CaloriesPerServing = foods.CaloriesPerServing;
                food.WeightPerServing = foods.WeightPerServing;
                food.MeasurementPerServing = foods.MeasurementPerServing;
                food.FatContent = foods.FatContent;
                food.FiberContent = foods.FiberContent;
                food.ExporationDate = foods.ExporationDate;
                food.Quantity = foods.Quantity;
                food.Notes = foods.Notes;
                food.MeasurementWeight = foods.MeasurementWeight;

                _appDbContext.Food.Update(food);
                await _appDbContext.SaveChangesAsync();
                return true;
            }

            public async Task<bool> UpdateToysDomainIncrement(int id)
            {
                var toy = await _appDbContext.Toys.FirstOrDefaultAsync(a => a.Id == id);
                if (toy == null)
                    throw new Exception($"Toy with ID {id} not found.");

                toy.Quantity = toy.Quantity + 1;

                _appDbContext.Toys.Update(toy);
                await _appDbContext.SaveChangesAsync();
                return true;
            }

            public async Task<bool> UpdateToysDomainDecrement(int id)
            {
                var toy = await _appDbContext.Toys.FirstOrDefaultAsync(a => a.Id == id);
                if (toy == null)
                    throw new Exception($"Toy with ID {id} not found.");

                toy.Quantity = toy.Quantity - 1;

                _appDbContext.Toys.Update(toy);
                await _appDbContext.SaveChangesAsync();
                return true;
            }

            public async Task<bool> UpdateToysDomain(ToysDomain toys)
            {
                var toy = await _appDbContext.Toys.FirstOrDefaultAsync(a => a.Id == toys.Id);
                if (toy == null)
                    throw new Exception($"Toy with ID {toys.Id} not found.");

                toy.BrandName = toys.BrandName;
                toy.Name = toys.Name;
                toy.AnimalType = toys.AnimalType;
                toy.ToyType = toys.ToyType;
                toy.AgeGroup = toys.AgeGroup;
                toy.Hight = toys.Hight;
                toy.Width = toys.Width;
                toy.Quantity = toys.Quantity;
                toy.Notes = toys.Notes;
                toy.Price = toys.Price;

                _appDbContext.Toys.Update(toy);
                await _appDbContext.SaveChangesAsync();
                return true;
            }

            public async Task<bool> UpdateFoundRecordDomain(int id, int animalId, DateTime date, string adress, string description, string ownerName, string ownerSurname, string ownerPhoneNumber, string ownerOIB, string registerId)
            {
                var found = await _appDbContext.FoundRecord.FirstOrDefaultAsync(a => a.Id == id);
                if (found == null)
                    throw new Exception($"Found record with ID {id} not found.");

                found.Date = date;
                found.Adress = adress;
                found.Description = description;
                found.OwnerName = ownerName;
                found.OwnerSurname = ownerSurname;
                found.OwnerPhoneNumber = ownerPhoneNumber;
                found.OwnerOIB = ownerOIB;
                found.RegisterId = registerId;

                _appDbContext.FoundRecord.Update(found);
                await _appDbContext.SaveChangesAsync();
                return true;
            }

            public async Task<bool> UpdateMedicinesDomainUsage(int id, bool usage)  // Updates if animal no longer uses medicine; hides with false instead of deleting
            {
                var meds = await _appDbContext.Medicines.FirstOrDefaultAsync(a => a.Id == id);
                if (meds == null)
                    throw new Exception($"Medicine with ID {id} not found.");

                meds.Usage = usage;

                _appDbContext.Medicines.Update(meds);
                await _appDbContext.SaveChangesAsync();
                return true;
            }

            public async Task<bool> UpdateMedicinesDomain(int id, decimal amountOfMedicine, string mesurmentUnit, int medicationIntake, string frequencyOfMedicationUse) // Updates medicine info if needed
            {
                var meds = await _appDbContext.Medicines.FirstOrDefaultAsync(a => a.Id == id);
                if (meds == null)
                    throw new Exception($"Medicine with ID {id} not found.");

                meds.AmountOfMedicine = amountOfMedicine;
                meds.MesurmentUnit = mesurmentUnit;
                meds.MedicationIntake = medicationIntake;
                meds.FrequencyOfMedicationUse = frequencyOfMedicationUse;

                _appDbContext.Medicines.Update(meds);
                await _appDbContext.SaveChangesAsync();
                return true;
            }

            public async Task<bool> UpdateNewsDomain(int id, string name, string description, DateTime dateTime)  // Updates news if there's an error
            {
                var news = await _appDbContext.News.FirstOrDefaultAsync(a => a.Id == id);
                if (news == null)
                    throw new Exception($"News with ID {id} not found.");

                news.Name = name;
                news.Description = description;
                news.DateTime = dateTime;

                _appDbContext.News.Update(news);
                await _appDbContext.SaveChangesAsync();
                return true;
            }

            public async Task<bool> UpdateVetVisitsDomain(int id, DateTime startTime, DateTime endTime, string notes)  // Updates vet visit if needed
            {
                var visit = await _appDbContext.VetVisits.FirstOrDefaultAsync(a => a.Id == id);
                if (visit == null)
                    throw new Exception($"Vet visit with ID {id} not found.");

                visit.StartTime = startTime;
                visit.EndTime = endTime;
                visit.Notes = notes;

                _appDbContext.VetVisits.Update(visit);
                await _appDbContext.SaveChangesAsync();
                return true;
            }

            public async Task<bool> UpdateContactDomain(int id)
            {
                var contact = await _appDbContext.Contact.FirstOrDefaultAsync(a => a.Id == id);
                if (contact == null)
                    throw new Exception($"Contact with ID {id} not found.");

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
                        if (string.IsNullOrWhiteSpace(name))
                            throw new ArgumentException("Animal name is required.");
                        if (string.IsNullOrWhiteSpace(species))
                            throw new ArgumentException("Species is required.");
                        // Add other validation checks as needed

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

                        // Assuming your _mappingService.Map<T> maps the object correctly
                        var animal = _mappingService.Map<Animals>(newAnimal);
                        if (animal == null)
                            throw new Exception("Mapping failed for new animal.");

                        _appDbContext.Animals.Add(animal);

                        await _appDbContext.SaveChangesAsync();

                        var result = _mappingService.Map<AnimalDomain>(animal);
                        if (result == null)
                            throw new Exception("Mapping failed when returning animal data.");

                        return result;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Failed to add animal: {ex.Message}", ex);
                    }
                }

                public async Task<AdopterDomain> CreateAdopterAsync(string firstName, string lastName, DateTime dateOfBirth, string residence, string username, string password, string registerId)
                {
                    try
                    {
                        if (string.IsNullOrWhiteSpace(firstName))
                            throw new ArgumentException("First name is required.");
                        if (string.IsNullOrWhiteSpace(lastName))
                            throw new ArgumentException("Last name is required.");
                        if (string.IsNullOrWhiteSpace(username))
                            throw new ArgumentException("Username is required.");
                        if (string.IsNullOrWhiteSpace(password))
                            throw new ArgumentException("Password is required.");

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
                        if (adopter == null)
                            throw new Exception("Mapping failed for adopter.");

                        _appDbContext.Adopter.Add(adopter);
                        await _appDbContext.SaveChangesAsync();

                        var result = _mappingService.Map<AdopterDomain>(adopter);
                        if (result == null)
                            throw new Exception("Mapping failed when returning adopter data.");

                        return result;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Failed to create adopter: {ex.Message}", ex);
                    }
                }

                public async Task<bool> CreateReturnedAnimalAsync(int adoptionCode, int animalId, int adopterId, DateTime returnDate, string returnReason)
                {
                    try
                    {
                        if (adoptionCode <= 0)
                            throw new ArgumentException("Invalid adoption code.");
                        if (animalId <= 0)
                            throw new ArgumentException("Invalid animal ID.");
                        if (adopterId <= 0)
                            throw new ArgumentException("Invalid adopter ID.");
                        if (string.IsNullOrWhiteSpace(returnReason))
                            throw new ArgumentException("Return reason is required.");

                        var returnedAnimalDomain = new ReturnedAnimal
                        {
                            AdoptionCode = adoptionCode,
                            AnimalId = animalId,
                            AdopterId = adopterId,
                            ReturnDate = returnDate,
                            ReturnReason = returnReason
                        };

                        var returnedAnimal = _mappingService.Map<ReturnedAnimal>(returnedAnimalDomain);
                        if (returnedAnimal == null)
                            throw new Exception("Mapping failed for returned animal.");

                        _appDbContext.ReturnedAnimal.Add(returnedAnimal);
                        await _appDbContext.SaveChangesAsync();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Failed to create returned animal record: {ex.Message}", ex);
                    }
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
                        };

                        _appDbContext.Adopted.Add(adoptedEntity);
                        await _appDbContext.SaveChangesAsync();

                        var animal = await _appDbContext.Animals.FirstOrDefaultAsync(a => a.IdAnimal == animalId);
                        if (animal == null)
                        {
                            Console.WriteLine($"Animal with ID {animalId} was not found.");
                            return false; // Animal not found
                        }

                        return true; // Success
                    }
                    catch (Exception ex)
                    {
                        // Log the exception or handle it appropriately
                        Console.WriteLine($"Failed to create adopted record: {ex.Message}");
                        return false; // Failed to save
                    }
                }



        //Add novo
        //-----------------------------------------------------------------------------------------

        //Kad admin ili radnik kreiraju životinj odmas se stvori i rekord kojemu je PK isti kao od životinjekako bi imali samo jedan record po životinj koji se updata
            public async Task AddAnimalRecord(int idAnimal)
            {
                var animalExists = await _appDbContext.Animals.FirstOrDefaultAsync(a => a.IdAnimal == idAnimal);

                if (animalExists != null)
                {
                    var animalRecord = new AnimalRecordDomain
                    {
                        RecordId = 1,
                        AnimalId = idAnimal,
                    };

                    var animal = _mappingService.Map<AnimalRecord>(animalRecord);
                    _appDbContext.AnimalRecord.Add(animal);
                    await _appDbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"Animal with ID {idAnimal} does not exist!");
                }
            }

            public async Task AddFoundRecord(int animalId, DateTime date, string address, string description, string ownerName, string ownerSurname, string ownerPhoneNumber, string ownerOIB, string registerId)
            {
                var animalExists = await _appDbContext.Animals.FirstOrDefaultAsync(a => a.IdAnimal == animalId);

                if (animalExists != null)
                {
                    var foundAnimal = new FoundRecordDomain
                    {
                        AnimalId = animalId,
                        Date = date,
                        Adress = address,
                        Description = description,
                        OwnerName = ownerName,
                        OwnerSurname = ownerSurname,
                        OwnerPhoneNumber = ownerPhoneNumber,
                        OwnerOIB = ownerOIB,
                        RegisterId = registerId // This is the user ID
                    };

                    var animal = _mappingService.Map<FoundRecord>(foundAnimal);
                    _appDbContext.FoundRecord.Add(animal);
                    await _appDbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"Animal with ID {animalId} does not exist!");
                }
            }

            public async Task AddFood(string brandName, string name, string foodType, string animalType, string ageGroup,
           decimal weight, decimal caloriesPerServing,
           decimal weightPerServing, string measurementPerServing, decimal fatContent, decimal fiberContent,
           DateTime expirationDate, int quantity, string notes, string measurementWeight)
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
                        ExporationDate = expirationDate,
                        Quantity = quantity,
                        Notes = notes,
                        MeasurementWeight = measurementWeight
                    };

                    var foodResponse = _mappingService.Map<Food>(food);
                    _appDbContext.Food.Add(foodResponse);
                    await _appDbContext.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw new Exception($"Failed to add food: {e.Message}");
                }
            }

            public async Task AddToys(string brandName, string name, string animalType, string toyType, string ageGroup, decimal height, decimal width, int quantity, string notes)
            {
                try
                {
                    var toy = new ToysDomain
                    {
                        BrandName = brandName,
                        Name = name,
                        AnimalType = animalType,
                        ToyType = toyType,
                        AgeGroup = ageGroup,
                        Hight = height,
                        Width = width,
                        Quantity = quantity,
                        Notes = notes
                    };

                    var toyResponse = _mappingService.Map<Toys>(toy);
                    _appDbContext.Toys.Add(toyResponse);
                    await _appDbContext.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw new Exception($"Failed to add toy: {e.Message}");
                }
            }

            public async Task AddNews(string name, string description, DateTime dateTime)
            {
                try
                {
                    var news = new NewsDomain
                    {
                        Name = name,
                        Description = description,
                        DateTime = dateTime
                    };

                    var newsResponse = _mappingService.Map<News>(news);
                    _appDbContext.News.Add(newsResponse);
                    await _appDbContext.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw new Exception($"Failed to add news: {e.Message}");
                }
            }

            public async Task AddVetVsit(int animalId, DateTime startTime, DateTime endTime, string typeOfVisit, string notes)
        {
                var animalExists = await _appDbContext.Animals.FirstOrDefaultAsync(a => a.IdAnimal == animalId);
                if (animalExists != null)
                {
                    var vetVisitDomain = new VetVisitsDomain
                    {
                        AnimalId = animalId,
                        StartTime = startTime,
                        EndTime = endTime,
                        TypeOfVisit = typeOfVisit,
                        Notes = notes
                    };

                    var vetVisit = _mappingService.Map<VetVisits>(vetVisitDomain);
                    _appDbContext.VetVisits.Add(vetVisit);
                    await _appDbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"Animal with ID {animalId} does not exist!");
                }
            }

            public async Task AddSystemRecord(int recordNumber, string recordName, string recordDescription)
            {
                var data = new SystemRecordDomain
                {
                    RecordNumber = recordNumber,
                    RecordName = recordName,
                    RecordDescription = recordDescription
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
                        AnimalId = animalId,
                        NameOfMedicines = nameOfMedicines,
                        Description = descriptio,
                        VetUsername = vetUsername,
                        AmountOfMedicine = amountOfMedicine,
                        MesurmentUnit = mesurmentUnit,
                        FrequencyOfMedicationUse = frequencyOfMedicationUse,
                        Usage = usage
                    };

                    var animal = _mappingService.Map<Medicines>(medicinesAnimal);
                    _appDbContext.Medicines.Add(animal);
                    await _appDbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"Animal with ID {animalId} does not exist!");
                }
            }

            async Task IRepository.AddFunds(int adopterId, decimal amount, string purpose, string iban)
            {
                var adopterExists = await _appDbContext.Adopter.FirstOrDefaultAsync(a => a.Id == adopterId);
                if (adopterExists != null)
                {
                    var funds = new FundsDomain
                    {
                        AdopterId = adopterId,
                        Amount = amount,
                        Purpose = purpose,
                        Iban = iban
                    };
                    var fundsResponse = _mappingService.Map<Funds>(funds);
                    _appDbContext.Funds.Add(fundsResponse);
                    await _appDbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"Adopter with ID {adopterId} does not exist!");
                }
            }

            public async Task AddEuthanasia(int animalId, DateTime date, string nameOfDesissse, bool complited)
            {
                var animalExists = await _appDbContext.Animals.FirstOrDefaultAsync(a => a.IdAnimal == animalId);
                if (animalExists != null)
                {
                    var euthanasiaAnimal = new EuthanasiaDomain
                    {
                        AnimalId = animalId,
                        Date = date,
                        NameOfDesissse = nameOfDesissse,
                        Complited = complited
                    };

                    var animal = _mappingService.Map<Euthanasia>(euthanasiaAnimal);
                    _appDbContext.Euthanasia.Add(animal);
                    await _appDbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"Animal with ID {animalId} does not exist!");
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
                        Contageus = contageus
                    };

                    var animal = _mappingService.Map<ContageusAnimals>(contageusAnimal);
                    _appDbContext.ContageusAnimals.Add(animal);
                    await _appDbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"Animal with ID {animalId} does not exist!");
                }
            }

            public async Task AddContact(string name, string email, string description, int adopterId)
            {
                var adopterExists = await _appDbContext.Adopter.FirstOrDefaultAsync(a => a.Id == adopterId);
                if (adopterExists != null)
                {
                    var contact = new ContactDomain
                    {
                        Name = name,
                        Email = email,
                        Description = description,
                        AdopterId = adopterId
                    };

                    var contactResponse = _mappingService.Map<Contact>(contact);
                    _appDbContext.Contact.Add(contactResponse);
                    await _appDbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"Adopter with ID {adopterId} does not exist!");
                }
            }

            public async Task AddBalans(string iban, string password, string type)
            {
                if (string.IsNullOrWhiteSpace(iban))
                    throw new ArgumentException("IBAN cannot be empty.", nameof(iban));
                if (string.IsNullOrWhiteSpace(password))
                    throw new ArgumentException("Password cannot be empty.", nameof(password));
                if (string.IsNullOrWhiteSpace(type))
                    throw new ArgumentException("Type cannot be empty.", nameof(type));

                var balans = new BalansDomain
                {
                    Iban = iban,
                    Balance = 0,
                    Password = password,
                    Type = type
                };

                var balansResponse = _mappingService.Map<Balans>(balans);
                _appDbContext.Balans.Add(balansResponse);
                await _appDbContext.SaveChangesAsync();
            }

            // Novo 17/3/2025
            async Task<LabsDomain> IRepository.AddLab(int animalId, DateTime date)
            {
                var animalExists = await _appDbContext.Animals.AnyAsync(a => a.IdAnimal == animalId);
                if (!animalExists)
                    throw new Exception($"Animal with ID {animalId} does not exist!");

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
                if (parametar == null)
                    throw new ArgumentNullException(nameof(parametar));

                // Optional: check if the related Lab exists
                var labExists = await _appDbContext.Labs.AnyAsync(l => l.Id == parametar.LabId);
                if (!labExists)
                    throw new Exception($"Lab with ID {parametar.LabId} does not exist!");

                var pResponse = _mappingService.Map<Parameter>(parametar);
                _appDbContext.Parameter.Add(pResponse);
                await _appDbContext.SaveChangesAsync();
            }


            // Novo 3.4.2025
            public async Task AddTransactions(TransactionsDomain transactions)
            {
                if (transactions == null)
                    throw new ArgumentNullException(nameof(transactions));

                // Optional: validate properties if needed, e.g. IBANs not empty
                if (string.IsNullOrWhiteSpace(transactions.Iban))
                    throw new ArgumentException("Iban cannot be empty.", nameof(transactions.Iban));
                if (string.IsNullOrWhiteSpace(transactions.IbanAnimalShelter))
                    throw new ArgumentException("IbanAnimalShelter cannot be empty.", nameof(transactions.IbanAnimalShelter));

                var t = new Transactions
                {
                    Iban = transactions.Iban,
                    IbanAnimalShelter = transactions.IbanAnimalShelter,
                    Type = transactions.Type,
                    Cost = transactions.Cost,
                    Purpose = transactions.Purpose,
                };
                var tResponse = _mappingService.Map<Transactions>(t);
                _appDbContext.Transactions.Add(tResponse);
                await _appDbContext.SaveChangesAsync();
            }

            // Add bird specific characteristics
            public async Task AddBirdAsync(BirdDomain birdDomain)
            {
                if (birdDomain == null)
                    throw new ArgumentNullException(nameof(birdDomain));

                // Check if the Animal exists
                var animalExists = await _appDbContext.Animals.AnyAsync(a => a.IdAnimal == birdDomain.AnimalId);
                if (!animalExists)
                    throw new Exception($"Animal with ID {birdDomain.AnimalId} does not exist!");

                var bird = new Birds
                {
                    AnimalId = Convert.ToInt32(birdDomain.AnimalId),
                    CageSize = birdDomain.CageSize,
                    RecommendedToys = birdDomain.RecommendedToys,
                    Sociability = birdDomain.Sociability
                };

                var birdResponse = _mappingService.Map<Birds>(bird);
                _appDbContext.Birds.Add(birdResponse);
                await _appDbContext.SaveChangesAsync();
            }

            public async Task AddMammalAsync(MammalDomain mammalDomain)
            {
                if (mammalDomain == null)
                    throw new ArgumentNullException(nameof(mammalDomain));

                var animalExists = await _appDbContext.Animals.AnyAsync(a => a.IdAnimal == mammalDomain.AnimalId);
                if (!animalExists)
                    throw new Exception($"Animal with ID {mammalDomain.AnimalId} does not exist!");

                var mammal = new Mammals
                {
                    AnimalId = mammalDomain.AnimalId,
                    CoatType = mammalDomain.CoatType,
                    GroomingProducts = mammalDomain.GroomingProducts
                };

                var mammalResponse = _mappingService.Map<Mammals>(mammal);
                _appDbContext.Mammals.Add(mammalResponse);
                await _appDbContext.SaveChangesAsync();
            }

            public async Task AddFishAsync(FishDomain fishDomain)
            {
                if (fishDomain == null)
                    throw new ArgumentNullException(nameof(fishDomain));

                var animalExists = await _appDbContext.Animals.AnyAsync(a => a.IdAnimal == fishDomain.AnimalId);
                if (!animalExists)
                    throw new Exception($"Animal with ID {fishDomain.AnimalId} does not exist!");

                var fish = new Fish
                {
                    AnimalId = fishDomain.AnimalId,
                    TankSize = fishDomain.TankSize,
                    CompatibleSpecies = fishDomain.CompatibleSpecies,
                    RecommendedItems = fishDomain.RecommendedItems
                };

                var fishResponse = _mappingService.Map<Fish>(fish);
                _appDbContext.Fish.Add(fishResponse);
                await _appDbContext.SaveChangesAsync();
            }

            public async Task AddReptileAsync(ReptileDomain reptileDomain)
            {
                if (reptileDomain == null)
                    throw new ArgumentNullException(nameof(reptileDomain));

                var animalExists = await _appDbContext.Animals.AnyAsync(a => a.IdAnimal == reptileDomain.AnimalId);
                if (!animalExists)
                    throw new Exception($"Animal with ID {reptileDomain.AnimalId} does not exist!");

                var reptile = new Reptiles
                {
                    AnimalId = reptileDomain.AnimalId,
                    TankSize = reptileDomain.TankSize,
                    Sociability = reptileDomain.Sociability,
                    CompatibleSpecies = reptileDomain.CompatibleSpecies,
                    RecommendedItems = reptileDomain.RecommendedItems
                };

                var reptileResponse = _mappingService.Map<Reptiles>(reptile);
                _appDbContext.Reptiles.Add(reptileResponse);
                await _appDbContext.SaveChangesAsync();
            }

            public async Task AddAmphibianAsync(AmphibianDomain amphibianDomain)
            {
                if (amphibianDomain == null)
                    throw new ArgumentNullException(nameof(amphibianDomain));

                var animalExists = await _appDbContext.Animals.AnyAsync(a => a.IdAnimal == amphibianDomain.AnimalId);
                if (!animalExists)
                    throw new Exception($"Animal with ID {amphibianDomain.AnimalId} does not exist!");

                var amphibian = new Amphibians
                {
                    AnimalId = amphibianDomain.AnimalId,
                    Humidity = amphibianDomain.Humidity,
                    Temperature = amphibianDomain.Temperature
                };

                var amphibianResponse = _mappingService.Map<Amphibians>(amphibian);
                _appDbContext.Amphibians.Add(amphibianResponse);
                await _appDbContext.SaveChangesAsync();
            }

        //UPDATE ZASEBNE KARAKTERISTIKE ŽIVOTINJA
        //GOTOVO I SVE RADI
        async Task<bool> IRepository.UpdateMammal(MammalDomain animal)
        {
            var mamel = await _appDbContext.Mammals.FirstOrDefaultAsync(a => a.AnimalId == animal.AnimalId);
            if (mamel == null)
                throw new Exception($"Mammal with AnimalId {animal.AnimalId} not found.");

            mamel.CoatType = animal.CoatType;
            mamel.GroomingProducts = animal.GroomingProducts;
            _appDbContext.Mammals.Update(mamel);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        async Task<bool> IRepository.UpdateFish(FishDomain animal)
        {
            var fish = await _appDbContext.Fish.FirstOrDefaultAsync(a => a.AnimalId == animal.AnimalId);
            if (fish == null)
                throw new Exception($"Fish with AnimalId {animal.AnimalId} not found.");

            fish.TankSize = animal.TankSize;
            fish.CompatibleSpecies = animal.CompatibleSpecies;
            fish.RecommendedItems = animal.RecommendedItems;
            _appDbContext.Fish.Update(fish);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        async Task<bool> IRepository.UpdateReptile(ReptileDomain animal)
        {
            var reptile = await _appDbContext.Reptiles.FirstOrDefaultAsync(a => a.AnimalId == animal.AnimalId);
            if (reptile == null)
                throw new Exception($"Reptile with AnimalId {animal.AnimalId} not found.");

            reptile.TankSize = animal.TankSize;
            reptile.CompatibleSpecies = animal.CompatibleSpecies;
            reptile.RecommendedItems = animal.RecommendedItems;
            reptile.Sociability = animal.Sociability;
            _appDbContext.Reptiles.Update(reptile);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        async Task<bool> IRepository.UpdateAmphibian(AmphibianDomain animal)
        {
            var amphibian = await _appDbContext.Amphibians.FirstOrDefaultAsync(a => a.AnimalId == animal.AnimalId);
            if (amphibian == null)
                throw new Exception($"Amphibian with AnimalId {animal.AnimalId} not found.");

            amphibian.Humidity = animal.Humidity;
            amphibian.Temperature = animal.Temperature;
            _appDbContext.Amphibians.Update(amphibian);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        async Task<bool> IRepository.UpdateBird(BirdDomain animal)
        {
            var bird = await _appDbContext.Birds.FirstOrDefaultAsync(a => a.AnimalId == animal.AnimalId);
            if (bird == null)
                throw new Exception($"Bird with AnimalId {animal.AnimalId} not found.");

            bird.Sociability = animal.Sociability;
            bird.RecommendedToys = animal.RecommendedToys;
            bird.CageSize = animal.CageSize;
            _appDbContext.Birds.Update(bird);
            await _appDbContext.SaveChangesAsync();
            return true;
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
