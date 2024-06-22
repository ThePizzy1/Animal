using ANIMAL.MODEL;
using ANIMAL.Service.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Authorize]
    public class AnimalController : ControllerBase
    {

        protected IService _service { get; private set; }
        
        public AnimalController(IService service)
        {
            _service = service;
         
        }
        [HttpGet]
        [Route("animal_db")]
        [AllowAnonymous]
        public IEnumerable<AnimalDomain> GetAnimalDomains()
        {
            IEnumerable<AnimalDomain> animalDb = _service.GetAllAnimalDomain();
            return animalDb;
        }
        [HttpGet]
        [Route("animal_pc")]
        [AllowAnonymous]
        public IEnumerable<AnimalDomain> GetAllAnimalDomainNoPicture()
        {
            IEnumerable<AnimalDomain> animalDb = _service.GetAllAnimalDomainNoPicture();
            return animalDb;
        }
        [HttpGet]
        [Route("animalA_db")]
        [AllowAnonymous]
        public IEnumerable<AnimalDomain> GetAnimalDomainsAdopt()
        {
            IEnumerable<AnimalDomain> animalDb = _service.GetAllAnimalDomainAdopt();
            return animalDb;
        }
        [HttpGet]
        [Route("animal/{animalId}")]
        [AllowAnonymous]
        public AnimalDomain GetAnimalById(int animalId)
        {
           AnimalDomain animalDb = _service.GetAnimalById(animalId);
            return animalDb;
        }
        [HttpGet]
        [Route("allanimal/{animalId}")]
        [AllowAnonymous]
        public AnimalDomain GetAllAnimalById(int animalId)
        {
            AnimalDomain animalDb = _service.GetAllAnimalById(animalId);
            return animalDb;
        }
        [HttpGet]
        [Route("adopter/{id}")]
        [AllowAnonymous]
        public AdopterDomain GetAdopterById(int id)
        {
            AdopterDomain animalDb = _service.GetAdopterById(id);
            return animalDb;
        }
        [HttpGet]
        [Route("adopted/{adopterId}")]
        [AllowAnonymous]
        public IEnumerable<AdoptedDomain> GetAllAdoptedDomainForAdopter(int adopterId)
        {
            IEnumerable<AdoptedDomain> adoptedDomains = _service.GetAllAdoptedDomainForAdopter(adopterId);
            return adoptedDomains;
        }
        [HttpGet]
        [Route("adopter_db")]
        [AllowAnonymous]
        public IEnumerable<AdopterDomain> GetAdopterDomains()
        {
            IEnumerable<AdopterDomain> adopterDb =_service.GetAllAdopterDomain();
            return adopterDb;
        }
        [HttpGet]
        [Route("mammel_db/{id}")]
        [AllowAnonymous]
        public MammalDomain GetMammalDomains(int id)
        {
            MammalDomain mammelDb = _service.GetAllMammalDomain(id);
            return mammelDb;
        }
        [HttpGet]
        [Route("bird_db/{id}")]
        [AllowAnonymous]
        public BirdDomain GetBirdDomains(int id)
        {
            BirdDomain birdDb = _service.GetAllBirdDomain(id);
            return birdDb;
        }
        [HttpGet]
        [Route("fish_db/{id}")]
        [AllowAnonymous]
        public FishDomain GetFishDomains(int id)
        {
            FishDomain fishDb = _service.GetAllFishDomain(id);
            return fishDb;
        }
        [HttpGet]
        [Route("amphibian_db/{id}")]
        [AllowAnonymous]
        public AmphibianDomain GetAmphibianDomains(int id)
        {
           AmphibianDomain amphibianDb = _service.GetAllAmphibianDomain(id);
            return amphibianDb;
        }
        [HttpGet] 
        [Route("reptile_db/{id}")]
        [AllowAnonymous]
        public ReptileDomain GetReptileDomains(int id)
        {
            ReptileDomain reptileDb = _service.GetAllReptileDomain(id);
            return reptileDb;
        }
        [HttpGet]
        [Route("adopted_db")]
        [AllowAnonymous]
        public IEnumerable<AdoptedDomain> GetAdoptedDomains()
        {
            IEnumerable<AdoptedDomain> adoptedDb = _service.GetAllAdoptedDomain();
            return adoptedDb;
        }
        [HttpGet]
        [Route("reaturned_db")]
        [AllowAnonymous]
        public IEnumerable<ReturnedAnimalDomain> GetReaturnedDomains()
        {
            IEnumerable<ReturnedAnimalDomain> returnedDb = _service.GetAllReturnedAnimalDomain();
            return returnedDb;
        }
  

        [HttpPost("addAdopter")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAdopter([FromBody] AdoptedDomain request)
        {
            if (request == null || request.Adopter == null)
            {
                return BadRequest("Invalid data. Adopter information is missing.");
            }

            var createdAdopter = await _service.CreateAdopterAsync(
                request.Adopter.FirstName,
                request.Adopter.LastName,
                request.Adopter.DateOfBirth,
                request.Adopter.Residence,
                request.Adopter.Username,
                request.Adopter.Password,
                request.Adopter.RegisterId
            );

            return CreatedAtAction(nameof(GetAdopterById), new { id = createdAdopter.Id }, createdAdopter);
        }
        [HttpPut("addAnimal")]
        [AllowAnonymous]
        public async Task<IActionResult> AddAnimalAsync([FromBody] AnimalDomain request)
        {
            if (request == null)
            {
                return BadRequest("Invalid data. Animal information is missing.");
            }

            try
            {
                var createdAnimal = await _service.AddAnimalAsync(
                    request.Name,
                    request.Family,
                    request.Species,
                    request.Subspecies,
                    request.Age,
                    request.Gender,
                    request.Weight,
                    request.Height,
                    request.Length,
                    request.Neutered,
                    request.Vaccinated,
                    request.Microchipped,
                    request.Trained,
                    request.Socialized,
                    request.HealthIssues,
                    request.Pisture2,
                    request.PersonalityDescription,
                    request.Adopted
                );

                // Check if createdAnimal is null or not
                if (createdAnimal == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Animal could not be added.");
                }

                // Return CreatedAtAction with the details of the created animal
                return CreatedAtAction(nameof(GetAnimalById), createdAnimal);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{idAnimal}")]
        [AllowAnonymous]
        public IActionResult Delete(int idAnimal)
        {
            try
            {
                _service.DeleteAnimal(idAnimal);
                return Ok("Životinja uspješno obrisana.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Došlo je do greške: {ex.Message}");
            }
        }
    }
}
