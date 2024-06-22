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
        public AdopterDomain GetAdopterById(int id)
        {
            var adopterDb = _appDbContext.Adopter.FirstOrDefault(a => a.Id == id);

            if (adopterDb == null)
            {
                return null; // ili obradi situaciju kako želite
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
            var adoptedEntities = _appDbContext.Adopted
                                               .Where(a => a.AdopterId == adopterId)
                                               .Include(a => a.Animal) // Uključi podatke o životinji
                                               .Include(a => a.Adopter) // Uključi podatke o usvojitelju
                                               .ToList();

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
                Flag=false,
                RegisterId=registerId,
                Adopted = new List<AdoptedDomain>(),
                ReturnedAnimal = new List<ReturnedAnimalDomain>()
            };

            var adopter = _mappingService.Map<Adopter>(adopterDomain);

            _appDbContext.Adopter.Add(adopter);
            await _appDbContext.SaveChangesAsync();

            return _mappingService.Map<AdopterDomain>(adopter);
        }
        public void DeleteAnimal(int idAnimal)
        {
            var animal = _appDbContext.Animals.FirstOrDefault(a => a.IdAnimal == idAnimal);
            try
            {
                if (animal == null)
                {
                    throw new Exception($"Životinja s IdAnimal {idAnimal} nije pronađena.");
                }

                // Provjeravamo je li životinja posvojena
                if (animal.Adopted)
                {
                    throw new Exception($"Nije moguće obrisati posvojenu životinju (IdAnimal: {idAnimal}).");
                }

                // Delete from Adopted table
                var adoptedRecord = _appDbContext.Set<Adopted>().FirstOrDefault(ad => ad.AnimalId == idAnimal);
                if (adoptedRecord != null)
                {
                    _appDbContext.Set<Adopted>().Remove(adoptedRecord);
                }

                // Delete from ReturnedAnimal table
                var returnedAnimalRecord = _appDbContext.Set<ReturnedAnimal>().FirstOrDefault(ra => ra.AnimalId == idAnimal);
                if (returnedAnimalRecord != null)
                {
                    _appDbContext.Set<ReturnedAnimal>().Remove(returnedAnimalRecord);
                }

                // Delete from specific animal family table
                switch (animal.Family)
                {
                    case "Reptile":
                        var reptile = _appDbContext.Set<Reptiles>().FirstOrDefault(r => r.AnimalId == idAnimal);
                        if (reptile != null)
                        {
                            _appDbContext.Set<Reptiles>().Remove(reptile);
                        }
                        break;
                    case "Mammal":
                        _appDbContext.Database.ExecuteSqlRaw($"DELETE FROM Mammals WHERE AnimalId = {idAnimal}");
                        break;
                    case "Fish":
                        var fish = _appDbContext.Set<Fish>().FirstOrDefault(f => f.AnimalId == idAnimal);
                        if (fish != null)
                        {
                            _appDbContext.Set<Fish>().Remove(fish);
                        }
                        break;
                    case "Bird":
                        var bird = _appDbContext.Set<Birds>().FirstOrDefault(b => b.AnimalId == idAnimal);
                        if (bird != null)
                        {
                            _appDbContext.Set<Birds>().Remove(bird);
                        }
                        break;
                    case "Amphibian":
                        var amphibian = _appDbContext.Set<Amphibians>().FirstOrDefault(a => a.AnimalId == idAnimal);
                        if (amphibian != null)
                        {
                            _appDbContext.Set<Amphibians>().Remove(amphibian);
                        }
                        break;
                    default:
                        throw new Exception($"Nepoznata family: {animal.Family}");
                }

                // Delete from main Animals table
                _appDbContext.Animals.Remove(animal);

                // Save changes to the database
                _appDbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Catch DbUpdateException that contains details about the inner error
                var innerException = ex.InnerException;
                while (innerException != null)
                {
                    Console.WriteLine(innerException.Message);
                    innerException = innerException.InnerException;
                }
                throw; // Re-throw the exception to be handled at a higher level
            }
        }
      
        AdopterDomain IRepository.GetAdopterByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddAnimalAsync(
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
       string pisture2,
       string personalityDescription,
       bool adopted)
        {
            try
            {
                string imagePathBase = "C:\\Users\\Korisnik\\Documents\\AnimalImg\\";
                string fullImagePath = Path.Combine(imagePathBase, pisture2);

                byte[] pictureBytes = null;
                if (File.Exists(fullImagePath))
                {
                    pictureBytes = File.ReadAllBytes(fullImagePath);
                }

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
                    Picture = pictureBytes,
                    PersonalityDescription = personalityDescription,
                    Adopted = adopted,
                    Picture2= pisture2
                };

                _appDbContext.Animals.Add(newAnimal);
                await _appDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add animal: {ex.Message}");
            }
        }
    }
}
