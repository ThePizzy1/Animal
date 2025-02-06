using ANIMAL.DAL.DataModel;
using ANIMAL.MODEL;
using ANIMAL.Repository.Common;
using ANIMAL.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
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
     public IEnumerable<AnimalDomain> GetAllAnimalDomain()
            {
                IEnumerable<AnimalDomain> animalDomains = _repository.GetAllAnimalDomain();
                return animalDomains;

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
        IEnumerable<AnimalDomain> IService.GetAllAnimalDomainNoPicture()
        {
            IEnumerable<AnimalDomain> animalDomains = _repository.GetAllAnimalDomain();
            return animalDomains;
        }


        //novo

        IEnumerable<AnimalRecordDomain> IService.GetAllAnimalRecordDomain()
        {
            IEnumerable<AnimalRecordDomain> recordDomains = _repository.GetAllAnimalRecordDomain();
            return recordDomains;
        }

        IEnumerable<BalansDomain> IService.GetAllBlansDomain()
        {
            IEnumerable<BalansDomain> balansDomains = _repository.GetAllBlansDomain();
            return balansDomains;
        }

        IEnumerable<ContactDomain> IService.GetaAllContactDomain()
        {
            IEnumerable<ContactDomain> contactDomains = _repository.GetaAllContactDomain();
            return contactDomains;
        }

        IEnumerable<ContageusAnimalsDomain> IService.GetAllContageusAnimalsDomain()
        {
            IEnumerable<ContageusAnimalsDomain> contageusAnimalsDomains = _repository.GetAllContageusAnimalsDomain();
            return contageusAnimalsDomains;
        }

        IEnumerable<EuthanasiaDomain> IService.GetAllEuthanasiaDomain()
        {
            IEnumerable<EuthanasiaDomain> euthanasiaDomains = _repository.GetAllEuthanasiaDomain();
            return euthanasiaDomains;
        }

        IEnumerable<FoodDomain> IService.GetAllFoodDomain()
        {
            IEnumerable<FoodDomain> foodDomains = _repository.GetAllFoodDomain();
            return foodDomains;
        }

        IEnumerable<FoundRecordDomain> IService.GetAllFoundRecord()
        {
            IEnumerable<FoundRecordDomain> fundRecordDomains = _repository.GetAllFoundRecord();
            return fundRecordDomains;
        }

        IEnumerable<FundsDomain> IService.GetAllFundsDomain()
        {
            IEnumerable<FundsDomain> funsdDomains = _repository.GetAllFundsDomain();
            return funsdDomains;
        }

        IEnumerable<LabsDomain> IService.GetAllLabsDomain()
        {
            IEnumerable<LabsDomain> labsDomains = _repository.GetAllLabsDomain();
            return labsDomains;
        }

        IEnumerable<MedicinesDomain> IService.GetAllMedicinesDomain()
        {
            IEnumerable<MedicinesDomain> medicinesDomains = _repository.GetAllMedicinesDomain();
            return medicinesDomains;
        }

        IEnumerable<NewsDomain> IService.GetAllNewsDomain()
        {
            IEnumerable<NewsDomain> newsDomains = _repository.GetAllNewsDomain();
            return newsDomains;
        }

        IEnumerable<ParameterDomain> IService.GetAllParameterDomain()
        {
            IEnumerable<ParameterDomain> parametarDomains = _repository.GetAllParameterDomain();
            return parametarDomains;
        }

        IEnumerable<SystemRecordDomain> IService.GetAllSystemRecordDomain()
        {
             IEnumerable<SystemRecordDomain> systemRecordDomains = _repository.GetAllSystemRecordDomain();
            return systemRecordDomains;
        }

        IEnumerable<ToysDomain> IService.GetAllToysDomain()
        {
            IEnumerable<ToysDomain> toysDomains = _repository.GetAllToysDomain();
            return toysDomains;
        }

        IEnumerable<VetVisitsDomain> IService.GetAllVetVisitsDomain()
        {
            IEnumerable<VetVisitsDomain> vetDomains = _repository.GetAllVetVisitsDomain();
            return vetDomains;
        }






        //GET BY ID
        public AmphibianDomain GetAllAmphibianDomain(int id)
        {
            AmphibianDomain amphibianDomains = _repository.GetAllAmphibianDomain(id);
            return amphibianDomains;
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
        AnimalDomain IService.GetAnimalById(int animalId)
        {
            AnimalDomain adoptedDomains = _repository.GetAnimalById(animalId);
            return adoptedDomains;
        }

        AdopterDomain IService.GetAdopterById(string id)
        {
            AdopterDomain adoptedDomains = _repository.GetAdopterById(id);
            return adoptedDomains;
        }

        public IEnumerable<AdoptedDomain> GetAllAdoptedDomainForAdopter(int adopterId)
        {
            IEnumerable<AdoptedDomain> adoptedDomains = _repository.GetAllAdoptedDomainForAdopter(adopterId);
            return adoptedDomains;
        }

        AdopterDomain IService.GetAdopterByUsername(string username)
        {
            AdopterDomain adoptedDomains = _repository.GetAdopterByUsername(username);
            return adoptedDomains;
        }

        //get by id novo
        ToysDomain IService.GetOneToysDomain(int id)
        {
            ToysDomain toysDomain = _repository.GetOneToysDomain(id);
            return toysDomain;
        }

        NewsDomain IService.GetOneNewsDomain(int id)
        {
            NewsDomain newsDomain = _repository.GetOneNewsDomain(id);
            return newsDomain;
        }

        MedicinesDomain IService.GetOneMedicinesDomain(int id)
        {
            MedicinesDomain MedicinesDomain = _repository.GetOneMedicinesDomain(id);
            return MedicinesDomain;
        }

        LabsDomain IService.GetOneLabsDomain(int id)
        {
            LabsDomain labsDomain = _repository.GetOneLabsDomain(id);
            return labsDomain;
        }

        FundsDomain IService.GetOneFundsDomain(int id)
        {
            FundsDomain fundsDomain = _repository.GetOneFundsDomain(id);
            return fundsDomain;
        }

        FoundRecordDomain IService.GetOneFoundRecordDomain(int id)
        {
            FoundRecordDomain foundRecordDomain = _repository.GetOneFoundRecordDomain(id);
            return foundRecordDomain;
        }

        FoodDomain IService.GetOneFoodDomain(int id)
        {
            FoodDomain foodDomain = _repository.GetOneFoodDomain(id);
            return foodDomain;
        }

        EuthanasiaDomain IService.GetOneEuthanasiaDomain(int id)
        {
            EuthanasiaDomain euthanasiaDomain = _repository.GetOneEuthanasiaDomain(id);
            return euthanasiaDomain;
        }

        ContageusAnimalsDomain IService.GetOneContageusAnimalsDomain(int id)
        {
            ContageusAnimalsDomain contageusAnimalsDomain = _repository.GetOneContageusAnimalsDomain(id);
            return contageusAnimalsDomain;
        }

        ContactDomain IService.GetOneContactDomain(int id)
        {
            ContactDomain contactDomain = _repository.GetOneContactDomain(id);
            return contactDomain;
        }

        BalansDomain IService.GetOneBalansDomain(int id)
        {
            BalansDomain balansDomain = _repository.GetOneBalansDomain(id);
            return balansDomain;
        }









        //ADD
        Task<AdopterDomain> IService.CreateAdopterAsync(string firstName, string lastName, DateTime dateOfBirth, string residence, string username, string password, string registerId)
        {
            Task<AdopterDomain> adopter = _repository.CreateAdopterAsync(firstName, lastName, dateOfBirth, residence, username, password, registerId);
            return adopter;
        }

        async Task<bool> IService.AddBirdAsync(BirdDomain birdDomain)
        {
            try
            {
                var isSuccess = await _repository.AddBirdAsync(birdDomain);
                return isSuccess;
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception($"Failed to add amphibian: {ex.Message}", ex);
            }
        }

        async Task<bool> IService.AddMammalAsync(MammalDomain mammalDomain)
        {
            try
            {
                var isSuccess = await _repository.AddMammalAsync(mammalDomain);
                return isSuccess;
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception($"Failed to add amphibian: {ex.Message}", ex);
            }
        }

        async Task<bool> IService.AddFishAsync(FishDomain fishDomain)
        {
            try
            {
                var isSuccess = await _repository.AddFishAsync(fishDomain);
                return isSuccess;
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception($"Failed to add amphibian: {ex.Message}", ex);
            }
        }

        async Task<bool> IService.AddReptileAsync(ReptileDomain reptileDomain)
        {
            try
            {
                var isSuccess = await _repository.AddReptileAsync(reptileDomain);
                return isSuccess;
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception($"Failed to add amphibian: {ex.Message}", ex);
            }

        }

        async Task<bool> IService.AddAmphibianAsync(AmphibianDomain amphibianDomain)
        {
            try
            {
                var isSuccess = await _repository.AddAmphibianAsync(amphibianDomain);
                return isSuccess;
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception($"Failed to add amphibian: {ex.Message}", ex);
            }

        }
        public IEnumerable<ReturnedAnimalDomain> GetAllReturnedAnimalsForAdopter(int adopterId)
        {
            IEnumerable<ReturnedAnimalDomain> animalDomains = _repository.GetAllReturnedAnimalsForAdopter(adopterId);
            return animalDomains;
        }

        public async Task<bool> AddAnimalAsync(string name, string family, string species, string subspecies, int age, string gender, decimal weight, decimal height, decimal length, bool neutered, bool vaccinated, bool microchipped, bool trained, bool socialized, string healthIssues, byte[] picture, string personalityDescription, bool adopted)
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

                      picture,
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

        async Task<bool> IService.CreateReturnedAnimalAsync(int adoptionCode, int animalId, int adopterId, DateTime returnDate, string returnReason)
        {
            await _repository.CreateReturnedAnimalAsync(adoptionCode, animalId, adopterId, returnDate, returnReason);
            return true;
        }

        async Task<bool> IService.CreateAdoptedAsync(int animalId, int adopterId, DateTime adoptionDate)
        {
            await _repository.CreateAdoptedAsync(animalId, adopterId, adoptionDate);
            return true;
        }





        //UPDATE
        public Task IncrementNumberOfAdoptedAnimalsAsync(string registerId)
        {
            Task adopter = _repository.IncrementNumberOfAdoptedAnimalsAsync( registerId);
            return adopter;
        }
        public Task IncrementNumberOfReturnedAnimalsAsync(string registerId)
        {
            Task adopter = _repository.IncrementNumberOfReturnedAnimalsAsync( registerId);
            return adopter;
        }
        Task<AdopterDomain> IService.UpdateAdopterAsync(string registerId, string firstName, string lastName, DateTime dateOfBirth, string residence, string username, string password)
        {
            Task<AdopterDomain> adopter = _repository.UpdateAdopterAsync(registerId, firstName, lastName, dateOfBirth, residence, username, password);
            return adopter;
        }
        public Task<AnimalDomain> UpdateAnimalAsync(int idAnimal, int age, decimal weight, decimal height, decimal length, bool neutered, bool vaccinated, bool microchipped, bool trained, bool socialized, string healthIssues, string personalityDescription)
        {
            Task<AnimalDomain> aniimal = _repository.UpdateAnimalAsync( idAnimal,  age,  weight,  height,  length,  neutered,  vaccinated,  microchipped,  trained,  socialized,  healthIssues,  personalityDescription);
            return aniimal;
        }
        public async Task<BirdDomain> UpdateBird(BirdDomain bird)
        {
           BirdDomain aniimal = await _repository.UpdateBird(bird);
            return aniimal;
        }

        async Task<bool> IService.AdoptionStatus(int animalId)
        {
            await _repository.AdoptionStatus(animalId);
            return true;

        }

        async Task<bool> IService.UpdateAdopterFlag(int adopterId)
        {
          await  _repository.UpdateAdopterFlag(adopterId);
            return true;
        }

        async Task<bool> IService.AdoptionStatusFalse(int animalId)
        {
            await _repository.AdoptionStatusFalse(animalId);
            return true;
        }



        //DELETE

        async Task<bool> IService.DeleteAdoptedAsync(int adoptedId)
        {
            await _repository.DeleteAdoptedAsync(adoptedId);
            return true;
        }
        public  void DeleteAdoptedReturn(int adoptedId)
        {
             _repository.DeleteAdoptedReturn(adoptedId);
            
        }

           
        public async Task DeleteAnimal(int idAnimal)
        {
            try
            {
                // Ensure that the idAnimal is valid (Optional)
                if (idAnimal <= 0)
                {
                    throw new ArgumentException("Invalid animal ID.");
                }

                // Delegate to the repository's DeleteAnimal method
                await _repository.DeleteAnimal(idAnimal);
            }
            catch (Exception ex)
            {
                // Log the exception (replace Console.WriteLine with proper logging)
                Console.WriteLine($"Error deleting animal with ID {idAnimal}: {ex.Message}");

                // Optionally, rethrow the exception if it needs to be handled at a higher level
                throw;
            }
        }

    }
}
