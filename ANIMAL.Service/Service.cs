using ANIMAL.DAL.DataModel;
using ANIMAL.MODEL;
using ANIMAL.Repository.Common;
using ANIMAL.Service.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ANIMAL.Service
{
    public class Service : IService
    {
        readonly IRepository _repository;
        public Service(IRepository repository)
        {
            _repository = repository;

        }

        public IEnumerable<AdoptedDomain> GetAllAdoptedDomain()
        {
            IEnumerable<AdoptedDomain> adoptedDomains = _repository.GetAllAdoptedDomain();
            return adoptedDomains;
        }
      
        public IEnumerable<AdopterDomain> GetAllAdopterDomain()
        {
            IEnumerable<AdopterDomain> adopterDomains = _repository.GetAllAdopterDomain();
            return adopterDomains;
        }

        public AmphibianDomain GetAllAmphibianDomain(int id)
        {
           AmphibianDomain amphibianDomains = _repository.GetAllAmphibianDomain(id);
            return amphibianDomains;
        }

        public IEnumerable<AnimalDomain> GetAllAnimalDomain()
        {
            IEnumerable<AnimalDomain> animalDomains = _repository.GetAllAnimalDomain();
            return animalDomains;
            
        }

         AnimalDomain IService.GetAllAnimalById(int animalId)
        {
            AnimalDomain adoptedDomains = _repository.GetAllAnimalById(animalId);
            return adoptedDomains;
        }

         BirdDomain IService.GetAllBirdDomain(int id)
        {
           BirdDomain birdDomains = _repository.GetAllBirdDomain(id);
            return birdDomains;
        }

        FishDomain IService.GetAllFishDomain(int id)
        {
           FishDomain fishDomains = _repository.GetAllFishDomain(id);
            return fishDomains;
        }

         MammalDomain IService.GetAllMammalDomain(int id)
        {
           MammalDomain mamelDomains = _repository.GetAllMammalDomain(id);
            return mamelDomains;
        }

         ReptileDomain IService.GetAllReptileDomain(int id)
        {
           ReptileDomain reptileDomains = _repository.GetAllReptileDomain(id);
            return reptileDomains;
        }

        IEnumerable<ReturnedAnimalDomain> IService.GetAllReturnedAnimalDomain()
        {
            IEnumerable<ReturnedAnimalDomain> reptileDomains = _repository.GetAllReturnedAnimalDomain();
            return reptileDomains;
        }

        IEnumerable<AnimalDomain> IService.GetAllAnimalDomainAdopt()
        {
            IEnumerable<AnimalDomain> adoptedDomains = _repository.GetAllAnimalDomainAdopt();
            return adoptedDomains;
        }

        AnimalDomain IService.GetAnimalById(int animalId)
        {
          AnimalDomain adoptedDomains = _repository.GetAnimalById(animalId);
            return adoptedDomains;
        }

        AdopterDomain IService.GetAdopterById(int id)
        {
            AdopterDomain adoptedDomains = _repository.GetAdopterById(id);
            return adoptedDomains;
        }

        public IEnumerable<AdoptedDomain> GetAllAdoptedDomainForAdopter(int adopterId)
        {
            IEnumerable<AdoptedDomain> adoptedDomains = _repository.GetAllAdoptedDomainForAdopter(adopterId);
            return adoptedDomains;
        }

        Task<AdopterDomain> IService.CreateAdopterAsync(string firstName, string lastName, DateTime dateOfBirth, string residence, string username, string password, string registerId)
        {
            Task<AdopterDomain> adopter =  _repository.CreateAdopterAsync(firstName, lastName, dateOfBirth, residence, username, password, registerId);
            return adopter;
        }
       
        IEnumerable<AnimalDomain> IService.GetAllAnimalDomainNoPicture()
        {
            IEnumerable<AnimalDomain> animalDomains = _repository.GetAllAnimalDomain();
            return animalDomains;
        }

        void IService.DeleteAnimal(int idAnimal)
        {
            _repository.DeleteAnimal( idAnimal);
        }

        AdopterDomain IService.GetAdopterByUsername(string username)
        {
            AdopterDomain adoptedDomains = _repository.GetAdopterByUsername(username);
            return adoptedDomains;
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
                var isSuccess = await _repository.AddAnimalAsync(
                    name,
                    family,
                    species,
                    subspecies,
                    age,
                    gender,
                    weight,
                    height,
                    length,
                    neutered,
                    vaccinated,
                    microchipped,
                    trained,
                    socialized,
                    healthIssues,
                    pisture2,
                    personalityDescription,
                    adopted
                );

                return isSuccess;
            }
            catch (Exception ex)
            {
                // Handle exception as needed
                throw new Exception($"Failed to add animal: {ex.Message}");
            }
        }
    }
}
