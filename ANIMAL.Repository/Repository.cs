using ANIMAL.DAL.DataModel;
using ANIMAL.MODEL;
using ANIMAL.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ANIMAL.Repository.Automaper;
using System.Linq;

namespace ANIMAL.Repository
{
    public class Repository : IRepository
    {
        private readonly AnimalRescueDbContext _appDbContext;
        private IRepositoryMappingService _mappingService;
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
                a.NumReturnedAnimals)).ToList();

            return adopterDomain;
        }



        public IEnumerable<AmphibianDomain> GetAllAmphibianDomain()
        {
            var amphibianList = _appDbContext.Amphibians
                .Join(_appDbContext.Animals, a => a.AnimalId, an => an.IdAnimal,
                    (a, an) => new { Amphibian = a, Animal = an })
                .Select(x => new AmphibianDomain(
                    x.Animal.IdAnimal,
                    x.Animal.Name,
                    x.Animal.Family,
                    x.Animal.Species,
                    x.Animal.Subspecies,
                    x.Animal.Age,
                    x.Animal.Gender,
                    x.Animal.Weight,
                    x.Animal.Height,
                    x.Animal.Length,
                    x.Animal.Neutered,
                    x.Animal.Vaccinated,
                    x.Animal.Microchipped,
                    x.Animal.Trained,
                    x.Animal.Socialized,
                    x.Animal.HealthIssues,
                    x.Animal.Picture,
                    x.Animal.PersonalityDescription,
                    x.Animal.Adopted,
                    x.Amphibian.AnimalId,
                    x.Amphibian.Humidity,
                    x.Amphibian.Temperature))
                .ToList();

            return amphibianList;
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

        public IEnumerable<BirdDomain> GetAllBirdDomain()
        {
            var birdList = _appDbContext.Birds
                .Join(_appDbContext.Animals, b => b.AnimalId, a => a.IdAnimal,
                    (b, a) => new { Bird = b, Animal = a })
                .Select(x => new BirdDomain(
                    x.Animal.IdAnimal,
                    x.Animal.Name,
                    x.Animal.Family,
                    x.Animal.Species,
                    x.Animal.Subspecies,
                    x.Animal.Age,
                    x.Animal.Gender,
                    x.Animal.Weight,
                    x.Animal.Height,
                    x.Animal.Length,
                    x.Animal.Neutered,
                    x.Animal.Vaccinated,
                    x.Animal.Microchipped,
                    x.Animal.Trained,
                    x.Animal.Socialized,
                    x.Animal.HealthIssues,
                       x.Animal.Picture,
                    x.Animal.PersonalityDescription,
                    x.Animal.Adopted,
                    x.Bird.AnimalId,
                    x.Bird.CageSize,
                    x.Bird.RecommendedToys,
                    x.Bird.Sociability))
                .ToList();

            return birdList;
        }



        public IEnumerable<FishDomain> GetAllFishDomain()
        {
            var fishList = _appDbContext.Fish
      .Join(_appDbContext.Animals, f => f.AnimalId, a => a.IdAnimal,
            (f, a) => new { Fish = f, Animal = a })
      .Select(x => new FishDomain(
          x.Animal.IdAnimal,
          x.Animal.Name,
          x.Animal.Family,
          x.Animal.Species,
          x.Animal.Subspecies,
          x.Animal.Age,
          x.Animal.Gender,
          x.Animal.Weight,
          x.Animal.Height,
          x.Animal.Length,
          x.Animal.Neutered,
          x.Animal.Vaccinated,
          x.Animal.Microchipped,
          x.Animal.Trained,
          x.Animal.Socialized,
          x.Animal.HealthIssues,
             x.Animal.Picture,
          x.Animal.PersonalityDescription,
          x.Animal.Adopted,
          x.Fish.AnimalId,
          x.Fish.TankSize,
          x.Fish.CompatibleSpecies,
          x.Fish.RecommendedItems))
      .ToList();

            return fishList;
        }

        public IEnumerable<MammalDomain> GetAllMammalDomain()
        {
            var mammals = _appDbContext.Mammals
                                 .Join(_appDbContext.Animals, m => m.AnimalId, a => a.IdAnimal,
                                       (m, a) => new { Mammal = m, Animal = a })
                                 .Select(x => new MammalDomain(
                                     x.Animal.IdAnimal,
                                     x.Animal.Name,
                                     x.Animal.Family,
                                     x.Animal.Species,
                                     x.Animal.Subspecies,
                                     x.Animal.Age,
                                     x.Animal.Gender,
                                     x.Animal.Weight,
                                     x.Animal.Height,
                                     x.Animal.Length,
                                     x.Animal.Neutered,
                                     x.Animal.Vaccinated,
                                     x.Animal.Microchipped,
                                     x.Animal.Trained,
                                     x.Animal.Socialized,
                                     x.Animal.HealthIssues,
                                        x.Animal.Picture,
                                     x.Animal.PersonalityDescription,
                                     x.Animal.Adopted,
                                     x.Mammal.AnimalId,
                                     x.Mammal.CoatType,
                                     x.Mammal.GroomingProducts
                                 ))
                                 .ToList();

            return mammals;
        }

        public IEnumerable<ReptileDomain> GetAllReptileDomain()
        {
            var reptiles = _appDbContext.Reptiles
                              .Join(_appDbContext.Animals, r => r.AnimalId, a => a.IdAnimal,
                                    (r, a) => new { Reptile = r, Animal = a })
                              .Select(x => new ReptileDomain(
                                  x.Animal.IdAnimal,
                                  x.Animal.Name,
                                  x.Animal.Family,
                                  x.Animal.Species,
                                  x.Animal.Subspecies,
                                  x.Animal.Age,
                                  x.Animal.Gender,
                                  x.Animal.Weight,
                                  x.Animal.Height,
                                  x.Animal.Length,
                                  x.Animal.Neutered,
                                  x.Animal.Vaccinated,
                                  x.Animal.Microchipped,
                                  x.Animal.Trained,
                                  x.Animal.Socialized,
                                  x.Animal.HealthIssues,
                                     x.Animal.Picture,
                                  x.Animal.PersonalityDescription,
                                  x.Animal.Adopted,
                                  x.Reptile.AnimalId,
                                  x.Reptile.TankSize,
                                  x.Reptile.Sociability,
                                  x.Reptile.CompatibleSpecies,
                                  x.Reptile.RecommendedItems
                              ))
                              .ToList();

            return reptiles;
        }
    }
}
