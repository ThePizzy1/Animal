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
        public AdopterDomain GetAdopterById(string id)
        {
            var adopterDb = _appDbContext.Adopter.FirstOrDefault(a => a.RegisterId == id);

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

                _appDbContext.Animals.Add(newAnimal);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add animal: {ex.Message}");
            }
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
                AnimalId= amphibianDomain.AnimalId,
                Humidity = amphibianDomain.Humidity,
                Temperature = amphibianDomain.Temperature
            };

            await _appDbContext.Amphibians.AddAsync(amphibian);
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<Animals> GetByIdAsync(int id)
        {
            return await _appDbContext.Animals.FirstOrDefaultAsync(a => a.IdAnimal == id);
        }
        public async Task<BirdDomain> UpdateBird(BirdDomain birdDomain)
        {
            if (birdDomain == null)
            {
                throw new ArgumentException("Bird not found");
            }

            // Mapiraj BirdDomain u Bird entitet
            var bird = _mappingService.Map<Birds>(birdDomain);

            // Preuzmi postojeći entitet iz baze
            var existingBird = await _appDbContext.Birds.FirstOrDefaultAsync(b => b.AnimalId == bird.AnimalId);

            if (existingBird == null)
            {
                throw new Exception("Bird not found in the database");
            }

            // Ažuriraj postojeći entitet s novim podacima
            existingBird.CageSize = bird.CageSize;
            existingBird.RecommendedToys = bird.RecommendedToys;
            existingBird.Sociability = bird.Sociability;

            // Spremi promjene u bazu podataka
            _appDbContext.Birds.Update(existingBird);
            await _appDbContext.SaveChangesAsync();

            // Mapiraj ažurirani entitet natrag u BirdDomain
            return _mappingService.Map<BirdDomain>(existingBird);
        }

    }
}
