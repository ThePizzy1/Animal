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

        public IEnumerable<AmphibianDomain> GetAllAmphibianDomain()
        {
            IEnumerable<AmphibianDomain> amphibianDomains = _repository.GetAllAmphibianDomain();
            return amphibianDomains;
        }

        public IEnumerable<AnimalDomain> GetAllAnimalDomain()
        {
            IEnumerable<AnimalDomain> animalDomains = _repository.GetAllAnimalDomain();
            return animalDomains;
            
        }

        public AnimalDomain GetAllAnimalDomainById(int animalId)
        {
         throw new NotImplementedException();
        }

        public IEnumerable<BirdDomain> GetAllBirdDomain()
        {
            IEnumerable<BirdDomain> birdDomains = _repository.GetAllBirdDomain();
            return birdDomains;
        }

        public IEnumerable<FishDomain> GetAllFishDomain()
        {
            IEnumerable<FishDomain> fishDomains = _repository.GetAllFishDomain();
            return fishDomains;
        }

        public IEnumerable<MammalDomain> GetAllMammalDomain()
        {
            IEnumerable<MammalDomain> mamelDomains = _repository.GetAllMammalDomain();
            return mamelDomains;
        }

        public IEnumerable<ReptileDomain> GetAllReptileDomain()
        {
            IEnumerable<ReptileDomain> reptileDomains = _repository.GetAllReptileDomain();
            return reptileDomains;
        }

        IEnumerable<ReturnedAnimalDomain> IService.GetAllReturnedAnimalDomain()
        {
            IEnumerable<ReturnedAnimalDomain> reptileDomains = _repository.GetAllReturnedAnimalDomain();
            return reptileDomains;
        }
    }
}
