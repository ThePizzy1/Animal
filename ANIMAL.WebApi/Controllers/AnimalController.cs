using ANIMAL.MODEL;
using ANIMAL.Service.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANIMAL.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {

        protected IService _service { get; private set; }
        public AnimalController(IService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("animal_db")]
        public IEnumerable<AnimalDomain> GetAnimalDomains()
        {
            IEnumerable<AnimalDomain> animalDb = _service.GetAllAnimalDomain();
            return animalDb;
        }
        [HttpGet]
        [Route("adopter_db")]
        public IEnumerable<AdopterDomain> GetAdopterDomains()
        {
            IEnumerable<AdopterDomain> adopterDb =_service.GetAllAdopterDomain();
            return adopterDb;
        }
        [HttpGet]
        [Route("mammel_db")]
        public IEnumerable<MammalDomain> GetMammalDomains()
        {
            IEnumerable<MammalDomain> mammelDb = _service.GetAllMammalDomain();
            return mammelDb;
        }
        [HttpGet]
        [Route("bird_db")]
        public IEnumerable<BirdDomain> GetBirdDomains()
        {
            IEnumerable<BirdDomain> birdDb = _service.GetAllBirdDomain();
            return birdDb;
        }
        [HttpGet]
        [Route("fish_db")]
        public IEnumerable<FishDomain> GetFishDomains()
        {
            IEnumerable<FishDomain> fishDb = _service.GetAllFishDomain();
            return fishDb;
        }
        [HttpGet]
        [Route("amphibian_db")] 
        public IEnumerable<AmphibianDomain> GetAmphibianDomains()
        {
            IEnumerable<AmphibianDomain> amphibianDb = _service.GetAllAmphibianDomain();
            return amphibianDb;
        }
        [HttpGet]
        [Route("reptile_db")]
        public IEnumerable<ReptileDomain> GetReptileDomains()
        {
            IEnumerable<ReptileDomain> reptileDb = _service.GetAllReptileDomain();
            return reptileDb;
        }
        [HttpGet]
        [Route("adopted_db")]
        public IEnumerable<AdoptedDomain> GetAdoptedDomains()
        {
            IEnumerable<AdoptedDomain> adoptedDb = _service.GetAllAdoptedDomain();
            return adoptedDb;
        }
    }
}
