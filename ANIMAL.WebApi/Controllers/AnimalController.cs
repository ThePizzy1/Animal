﻿using ANIMAL.MODEL;
using ANIMAL.Service.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
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
        public AdopterDomain GetAdopterById(string id)
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
        [HttpPut("updateAdopter/{registerId}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateAdopter(string registerId, [FromBody] AdoptedDomain request)
        {
            if (request == null || request.Adopter == null)
            {
                return BadRequest("Invalid data. Adopter information is missing.");
            }

            try
            {
                var updatedAdopter = await _service.UpdateAdopterAsync(
                    registerId,
                    request.Adopter.FirstName,
                    request.Adopter.LastName,
                    request.Adopter.DateOfBirth,
                    request.Adopter.Residence,
                    request.Adopter.Username,
                    request.Adopter.Password
                );

                return Ok(updatedAdopter); // Return 200 OK with the updated adopter
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating adopter: {ex.Message}");
            }
        }
        [HttpPut("incrementAdopted/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> IncrementNumberOfAdoptedAnimals(string id)
        {
            await _service.IncrementNumberOfAdoptedAnimalsAsync(id);
            return NoContent(); // HTTP 204 No Content
        }

        [HttpPut("incrementReturned/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> IncrementNumberOfReturnedAnimals(string id)
        {
            await _service.IncrementNumberOfReturnedAnimalsAsync(id);
            return NoContent(); // HTTP 204 No Content
        }

        [HttpPut("updateAnimal/{idAnimal}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateAnimal( [FromBody] AdoptedDomain request)
        {
            if (request == null || request.Animal == null) 
            {
                return BadRequest("Invalid data. Animal information is missing.");
            }

            try
            {
                var updatedAnimal = await _service.UpdateAnimalAsync(
                    request.Animal.IdAnimal,
                    request.Animal.Age,
                    request.Animal.Weight,
                    request.Animal.Height,
                    request.Animal.Length,
                    request.Animal.Neutered,
                    request.Animal.Vaccinated,
                    request.Animal.Microchipped,
                    request.Animal.Trained,
                    request.Animal.Socialized,
                    request.Animal.HealthIssues,
                    request.Animal.PersonalityDescription
                );

                return Ok(updatedAnimal); // Return 200 OK with the updated animal
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating animal: {ex.Message}");
            }
        }
        [HttpPut("bird/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateBird(int id, [FromBody] BirdDomain birdUpdateDto)
        {
            try
            {
                var bird =  _service.GetAllBirdDomain(id);
                if (bird == null)
                {
                    return NotFound("Bird not found");
                }

                // Ažuriraj bird entitet s podacima iz birdUpdateDto
                bird.CageSize = birdUpdateDto.CageSize;
                bird.RecommendedToys = birdUpdateDto.RecommendedToys;
                bird.Sociability = birdUpdateDto.Sociability;

                await _service.UpdateBird(bird);
              
                return Ok();
            }
            catch (Exception ex)
            {
                // Zabilježi grešku
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPost("addAnimal")]
        [AllowAnonymous]
        public async Task<IActionResult> AddAnimalAsync(
     [FromForm] string name,
     [FromForm] string family,
     [FromForm] string species,
     [FromForm] string subspecies,
     [FromForm] int age,
     [FromForm] string gender,
     [FromForm] decimal weight,
     [FromForm] decimal height,
     [FromForm] decimal length,
     [FromForm] bool neutered,
     [FromForm] bool vaccinated,
     [FromForm] bool microchipped,
     [FromForm] bool trained,
     [FromForm] bool socialized,
     [FromForm] string healthIssues,
     [FromForm] string personalityDescription,
     [FromForm] bool adopted,
     [FromForm] IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                return BadRequest("No image file provided.");
            }

            try
            {

                byte[] pictureBytes;
                using (var memoryStream = new MemoryStream())
                {
                    await image.CopyToAsync(memoryStream);
                    pictureBytes = memoryStream.ToArray();
                }

                var success = await _service.AddAnimalAsync(
                    name, family, species, subspecies, age, gender, weight, height, length,
                    neutered, vaccinated, microchipped, trained, socialized, healthIssues,pictureBytes,
                    personalityDescription, adopted );

                if (success)
                    return Ok("Animal successfully added.");
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add animal.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to add animal: {ex.Message}");
            }
        }




        [HttpDelete("{idAnimal}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int idAnimal)
        {
            try
            {
               
                // Call the service layer asynchronously
                await _service.DeleteAnimal(idAnimal);

                // Return success message if the operation completes
                return Ok("Animal successfully deleted.");
            }
            catch (KeyNotFoundException)
            {
                // If the animal was not found, return a 404 Not Found
                return NotFound($"Animal with ID {idAnimal} not found.");
            }
            catch (InvalidOperationException ex)
            {
                // Return a BadRequest if the operation was invalid (e.g., animal was adopted)
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                // Catch other exceptions and return a generic server error message
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("code/{code}")]
        [AllowAnonymous]
        public IActionResult DeleteAdoptedReturn(int code)
        {
            try
            {
                _service.DeleteAdoptedReturn(code);
                return Ok("Životinja uspješno obrisana.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Došlo je do greške: {ex.Message}");
            }
        }


        [HttpPost("addAdoptedAnimal")] // Endpoint for adding an adopted animal
        [AllowAnonymous]
        public async Task<IActionResult> AddAdoptedAnimal([FromBody] AdoptedDomain model)
        {
            if (model == null)
            {
                return BadRequest("Invalid data. Adopted animal information is missing.");
            }

            var createdAdoptedAnimal = await _service.CreateAdoptedAsync(
               
                model.AnimalId,
                model.AdopterId,
                model.AdoptionDate
            );

            if (createdAdoptedAnimal == null)
            {
                return StatusCode(500, "Failed to create adopted animal."); // Handle failure scenario
            }

            return Ok();
        }


        [HttpPost("addReaturndAnimal")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateReturnedAnimal([FromBody] ReturnedAnimalDomain  createReturnedAnimalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var returnedAnimal = await _service.CreateReturnedAnimalAsync(
              
                createReturnedAnimalDto.AdoptionCode,
                createReturnedAnimalDto.AnimalId,
                createReturnedAnimalDto.AdopterId,
                createReturnedAnimalDto.ReturnDate,
                createReturnedAnimalDto.ReturnReason
            );

            return Ok();
        }

        [HttpPut("adoptionstatus/{animalId}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateAdoptionStatus(int animalId)
        {
          await  _service.AdoptionStatus(animalId);

            return Ok(new { Message = "Adoption status updated successfully" });
        }
        [HttpPut("adoptionstatusfalse/{animalId}")]
        [AllowAnonymous]
        public async Task<IActionResult> AdoptionStatusFalse(int animalId)
        {
            await _service.AdoptionStatusFalse(animalId);

            return Ok(new { Message = "Adoption status updated successfully" });
        }
        [HttpPut("deladopted/{adopterId}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteAdoptedAsync(int adopterId)
        {
            await _service.DeleteAdoptedAsync(adopterId);

            return Ok(new { Message = "Adoption status updated successfully" });
        }
        [HttpPut("flag/{adopterId}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateAdopterFlag(int adopterId)
        {
            await _service.UpdateAdopterFlag(adopterId);

            return Ok(new { Message = "Adoption status updated successfully" });
        }

        [HttpPost("bird")]
      
        public async Task<IActionResult> AddBirdAsync([FromBody] BirdDomain birdDomain)
        {
            if (birdDomain == null)
            {
                return BadRequest("Bird data is null.");
            }

            try
            {
                var isSuccess = await _service.AddBirdAsync(birdDomain);
                if (isSuccess)
                {
                    return Ok("Bird added successfully.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add bird.");
                }
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to add bird: {ex.Message}");
            }
        }

        [HttpPost("mammal")]
        public async Task<IActionResult> AddMammalAsync([FromBody] MammalDomain mammalDomain)
        {
            if (mammalDomain == null)
            {
                return BadRequest("Mammal data is null.");
            }

            try
            {
                var isSuccess = await _service.AddMammalAsync(mammalDomain);
                if (isSuccess)
                {
                    return Ok("Mammal added successfully.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add mammal.");
                }
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to add mammal: {ex.Message}");
            }
        }

        [HttpPost("fish")]
        public async Task<IActionResult> AddFishAsync([FromBody] FishDomain fishDomain)
        {
            if (fishDomain == null)
            {
                return BadRequest("Fish data is null.");
            }

            try
            {
                var isSuccess = await _service.AddFishAsync(fishDomain);
                if (isSuccess)
                {
                    return Ok("Fish added successfully.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add fish.");
                }
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to add fish: {ex.Message}");
            }
        }

        [HttpPost("addreptile")]
        public async Task<IActionResult> AddReptileAsync([FromBody] ReptileDomain reptileDomain)
        {
            if (reptileDomain == null)
            {
                return BadRequest("Reptile data is null.");
            }

            try
            {
                var isSuccess = await _service.AddReptileAsync(reptileDomain);
                if (isSuccess)
                {
                    return Ok("Reptile added successfully.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add reptile.");
                }
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to add reptile: {ex.Message}");
            }
        }

        [HttpPost("addamphibian")]
        public async Task<IActionResult> AddAmphibianAsync([FromBody] AmphibianDomain amphibianDomain)
        {
            if (amphibianDomain == null)
            {
                return BadRequest("Amphibian data is null.");
            }

            try
            {
                var isSuccess = await _service.AddAmphibianAsync(amphibianDomain);
                if (isSuccess)
                {
                    return Ok("Amphibian added successfully.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add amphibian.");
                }
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to add amphibian: {ex.Message}");
            }
        }


        [HttpGet("returned/{adopterId}")]
        [AllowAnonymous]
     
        public IEnumerable<ReturnedAnimalDomain> GetAllReturnedAnimalsForAdopter(int adopterId)
        {
            IEnumerable<ReturnedAnimalDomain> adoptedDomains = _service.GetAllReturnedAnimalsForAdopter(adopterId);
            return adoptedDomains;
        }

    }
}
