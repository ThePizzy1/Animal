using ANIMAL.DAL.DataModel;
using ANIMAL.MODEL;
using ANIMAL.Service.Common;
using AutoMapper.Execution;
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
        [HttpGet("animal_db")]
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
        [Route("adopter_db")]
        [AllowAnonymous]
        public IEnumerable<AdopterDomain> GetAdopterDomains()
        {
            IEnumerable<AdopterDomain> adopterDb =_service.GetAllAdopterDomain();
            return adopterDb;
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


        //NOVO GET
        //-----------------------------------------------------------------------------------------------------------------------------------------------
        // 15 novih tablica  15/15
        /*1.animalrecord-                             --RADI 
         *2. Balans-                                  --RADI
         * 3.Contact-                                 --RADI                                         
         * 4.contageus animals-                       --RADI
         * 5 euthanasia-                              --RADI
         * 6.found record-                            --RADI                                     
         * 7.funds-                                   --RADI                                         
         * 8.labs-                                    --RADI                                        
         * 9.parametar-                               --RADI                                       
         * 10.medicines-                              --RADI
         * 11.news-                                   --RADI
         * 12.system record-                          --RADI                                         
         * 13.toys-                                   --RADI
         * 14.food-                                   --RADI
         * 15.vet visit-                              --RADI
        */
        //--------------------------------------------------------------------------------------------------------------
        [HttpGet]
        [Route("animalrecord_db")]
        [AllowAnonymous]
        public IEnumerable<AnimalRecordDomain> GetAllAnimalRecordDomain()
        {
            IEnumerable<AnimalRecordDomain> animalDb = _service.GetAllAnimalRecordDomain();
            return animalDb;
        }

        [HttpGet]
        [Route("balans_db")]
        [AllowAnonymous]
        public IEnumerable<BalansDomain> GetAllBlansDomain()
        {
            IEnumerable<BalansDomain> animalDb = _service.GetAllBlansDomain();
            return animalDb;
        }

        [HttpGet]
        [Route("contact_db")]
        [AllowAnonymous]
        public IEnumerable<ContactDomain> GetaAllContactDomain()
        {
            IEnumerable<ContactDomain> animalDb = _service.GetaAllContactDomain();
            return animalDb;
        }

        [HttpGet]
        [Route("contageusanimals_db")]
        [AllowAnonymous]
        public IEnumerable<ContageusAnimalsDomain> GetAllContageusAnimalsDomain()
        {
            IEnumerable<ContageusAnimalsDomain> animalDb = _service.GetAllContageusAnimalsDomain();
            return animalDb;
        }

        [HttpGet]
        [Route("euthanasia_db")]
        [AllowAnonymous]
        public IEnumerable<EuthanasiaDomain> GetAllEuthanasiaDomain()
        {
            IEnumerable<EuthanasiaDomain> animalDb = _service.GetAllEuthanasiaDomain();
            return animalDb;
        }

        [HttpGet]
        [Route("food_db")]
        [AllowAnonymous]
        public IEnumerable<FoodDomain> GetAllFoodDomain()
        {
            IEnumerable<FoodDomain> animalDb = _service.GetAllFoodDomain();
            return animalDb;
        }

        [HttpGet]
        [Route("foundrecord_db")]
        [AllowAnonymous]
        public IEnumerable<FoundRecordDomain> GetAllFoundRecord()
        {
            IEnumerable<FoundRecordDomain> animalDb = _service.GetAllFoundRecord();
            return animalDb;
        }

        [HttpGet]
        [Route("funds_db")]
        [AllowAnonymous]
        public IEnumerable<FundsDomain> GetAllFundsDomain()
        {
            IEnumerable<FundsDomain> animalDb = _service.GetAllFundsDomain();
            return animalDb;
        }

        [HttpGet]
        [Route("labs_db")]
        [AllowAnonymous]
        public IEnumerable<LabsDomain> GetAllLabsDomain()
        {
            IEnumerable<LabsDomain> animalDb = _service.GetAllLabsDomain();
            return animalDb;
        }

        [HttpGet]
        [Route("medicines_db")]
        [AllowAnonymous]
        public IEnumerable<MedicinesDomain> GetAllMedicinesDomain()
        {
            IEnumerable<MedicinesDomain> animalDb = _service.GetAllMedicinesDomain();
            return animalDb;
        }

        [HttpGet]
        [Route("news_db")]
        [AllowAnonymous]
        public IEnumerable<NewsDomain> GetAllNewsDomain()
        {
            IEnumerable<NewsDomain> animalDb = _service.GetAllNewsDomain();
            return animalDb;
        }

        [HttpGet]
        [Route("parameter_db/{id}")]
        [AllowAnonymous]
        public IEnumerable<ParameterDomain> GetAllParameterDomain(int id)
        {
            IEnumerable<ParameterDomain> animalDb = _service.GetAllParameterDomain(id);
            return animalDb;
        }

        [HttpGet]
        [Route("systemrecord_db")]
        [AllowAnonymous]
        public IEnumerable<SystemRecordDomain> GetAllSystemRecordDomain()
        {
            IEnumerable<SystemRecordDomain> animalDb = _service.GetAllSystemRecordDomain();
            return animalDb;
        }

        [HttpGet]
        [Route("toys_db")]
        [AllowAnonymous]
        public IEnumerable<ToysDomain> GetAllToysDomain()
        {
            IEnumerable<ToysDomain> animalDb = _service.GetAllToysDomain();
            return animalDb;
        }

        [HttpGet]
        [Route("vetvisit_db")]
        [AllowAnonymous]
        public IEnumerable<VetVisitsDomain> GetAllVetVisitsDomain()
        {
            IEnumerable<VetVisitsDomain> animalDb = _service.GetAllVetVisitsDomain();
            return animalDb;
        }


        [HttpGet]
        [Route("transaction_db")]
        [AllowAnonymous]
        public IEnumerable<TransactionsDomain> GetAllTransactionsDomain()
        {
            IEnumerable<TransactionsDomain> animalDb = _service.GetAllTransactionsDomain();
            return animalDb;
        }


        //get with id
        //-----------------------------------------------------------------------------------------------------------------------------------------------



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
        [HttpGet("returned/{adopterId}")]
        [AllowAnonymous]
        public IEnumerable<ReturnedAnimalDomain> GetAllReturnedAnimalsForAdopter(int adopterId)
        {
            IEnumerable<ReturnedAnimalDomain> adoptedDomains = _service.GetAllReturnedAnimalsForAdopter(adopterId);
            return adoptedDomains;
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

        //--------------------------------------------------------------------------------------------------------------
        //novo get by id
        // 15 novih tablica  15/15
        /*1.animalrecord-                             --RADI 
         *2. Balans-                                  --RADI
         * 3.Contact-                                 --RADI                                         
         * 4.contageus animals-                       --RADI
         * 5 euthanasia-                              --RADI
         * 6.found record-                            --RADI                                     
         * 7.funds-                                   --RADI                                         
         * 8.labs-                                    --RADI                                        
         * 9.parametar-                               --Nije potrebno                                       
         * 10.medicines-                              --RADI
         * 11.news-                                   --RADI
         * 12.system record-                          --RADI                                         
         * 13.toys-                                   --RADI
         * 14.food-                                   --RADI
         * 15.vet visit-                              --RADI
        */
        //--------------------------------------------------------------------------------------------------------------
        [HttpGet]
        [Route("adopterId/{id}")]
        [AllowAnonymous]
        public AdopterDomain GetAdopterByIdInt(int id)
        {
            AdopterDomain parametar = _service.GetAdopterByIdInt(id);
            return parametar;
        }
        //-----------------------------------------------------------------------------------------------------------------------------

        [HttpGet]
        [Route("toy/{id}")]
        [AllowAnonymous]
        public ToysDomain GetOneToysDomain(int id)
        {
            ToysDomain parametar = _service.GetOneToysDomain(id);
            return parametar;
        }

        [HttpGet]
        [Route("news/{id}")]
        [AllowAnonymous]
        public NewsDomain GetOneNewsDomain(int id)
        {
            NewsDomain parametar = _service.GetOneNewsDomain(id);
            return parametar;
        }

        [HttpGet]
        [Route("meds/{id}")]
        [AllowAnonymous]
        public MedicinesDomain GetOneMedicinesDomain(int id)
        {
            MedicinesDomain parametar = _service.GetOneMedicinesDomain(id);
            return parametar;
        }

        [HttpGet]
        [Route("labs/{id}")]
        [AllowAnonymous]
        public LabsDomain GetOneLabsDomain(int id)
        {
            LabsDomain parametar = _service.GetOneLabsDomain(id);
            return parametar;
        }

        [HttpGet]
        [Route("funds/{id}")]
        [AllowAnonymous]
        public FundsDomain GetOneFundsDomain(int id)
        {
            FundsDomain parametar = _service.GetOneFundsDomain(id);
            return parametar;
        }

        [HttpGet]
        [Route("found/{id}")]//ID ŽIVOTINJE
        [AllowAnonymous]
        public FoundRecordDomain GetOneFoundRecordDomain(int id)
        {
            FoundRecordDomain parametar = _service.GetOneFoundRecordDomain(id);
            return parametar;
        }

        [HttpGet]
        [Route("food/{id}")]
        [AllowAnonymous]
        public FoodDomain GetOneFoodDomain(int id)
        {
            FoodDomain parametar = _service.GetOneFoodDomain(id);
            return parametar;
        }

        [HttpGet]
        [Route("euthanasia/{id}")]
        [AllowAnonymous]
        public EuthanasiaDomain GetOneEuthanasiaDomain(int id)
        {
            EuthanasiaDomain parametar = _service.GetOneEuthanasiaDomain(id);
            return parametar;
        }

        [HttpGet]
        [Route("contageus/{id}")]
        [AllowAnonymous]
        public ContageusAnimalsDomain GetOneContageusAnimalsDomain(int id)
        {
            ContageusAnimalsDomain parametar = _service.GetOneContageusAnimalsDomain(id);
            return parametar;
        }

        [HttpGet]
        [Route("contact/{id}")]
        [AllowAnonymous]
        public ContactDomain GetOneContactDomain(int id)
        {
            ContactDomain parametar = _service.GetOneContactDomain(id);
            return parametar;
        }

        [HttpGet]
        [Route("balans/{id}")]
        [AllowAnonymous]
        public BalansDomain GetOneBalansDomain(int id)
        {
            BalansDomain parametar = _service.GetOneBalansDomain(id);
            return parametar;
        }


        //--------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------
        //get by id novo novo
        //--------------------------------------------------------------------------------------------------------------
        [HttpGet]
        [Route("medsAnimal/{id}")]
        [AllowAnonymous]
        public MedicinesDomain GetOneMedicinesAnimal(int id)
        {
            MedicinesDomain parametar = _service.GetOneMedicinesAnimal(id);
            return parametar;
        }
        [HttpGet]
        [Route("contageusAnimal/{id}")]
        [AllowAnonymous]
        public ContageusAnimalsDomain GetOneContageusAnimal(int id)
        {
            ContageusAnimalsDomain parametar = _service.GetOneContageusAnimal(id);
            return parametar;
        }
        [HttpGet]
        [Route("labsAnimal/{id}")]
        [AllowAnonymous]
        public LabsDomain GetOneLabsAnimal(int id)
        {
            LabsDomain parametar = _service.GetOneLabsAnimal(id);
            return parametar;
        }
        [HttpGet]
        [Route("vetVisitAnimal/{id}")]
        [AllowAnonymous]
        public VetVisitsDomain GetOneVetVisitAnimal(int id)
        {
            VetVisitsDomain parametar = _service.GetOneVetVisitAnimal(id);
            return parametar;
        }

        [HttpGet]
        [Route("recordAnimal/{id}")]//ID ŽVOTINJE
        [AllowAnonymous]
        public AnimalRecordDomain GetOneAnimalRecord(int id)
            {
                AnimalRecordDomain parametar = _service.GetOneAnimalRecord(id);
                return parametar;
            }





        //PUT I POSTE
        //-----------------------------------------------------------------------------------------------------------------------------------------------

        //STARO
        //-----------------------------------------------------------------------------------------------------------------------------



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

                AnimalDomain success = await _service.AddAnimalAsync(
                    name, family, species, subspecies, age, gender, weight, height, length,
                    neutered, vaccinated, microchipped, trained, socialized, healthIssues, pictureBytes,
                    personalityDescription, adopted);

            if (success != null) {
                return Ok(success);
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add animal.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to add animal: {ex.Message}");
               }
           }

        [HttpPost("addAdoptedAnimal")] 
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
                 await _service.CreateReturnedAnimalAsync(
              
                createReturnedAnimalDto.AdoptionCode,
                createReturnedAnimalDto.AnimalId,
                createReturnedAnimalDto.AdopterId,
                createReturnedAnimalDto.ReturnDate,
                createReturnedAnimalDto.ReturnReason
            );

            return Ok();
        }


        //---------------------------------------------------------------------------------------------------------------------------------------------------
        //NOVO add
        //dodavanje novo 15 novih tablica 13/15
        /*1.animalrecord- samo za dodavanje prve                   --RADI                                                      
         *2. Balans-mislim da ne treba add samo update.            --RADI 
         * 3.Contact-potreban add i update za pročitano            --RADI
         * 4.contageus animals-potrebno add                        --RADI
         * 5 euthanasia-potreban add                               --RADI
         * 6.found record- potreban add                            --RADI
         * 7.funds-potreban add                                    --RADI
         * 8.labs-potreban                                         --RADI
         * 9.parametar-potreban add                                --RADI
         * 10.medicines-potreban add                               --RADI
         * 11.news-potreban add                                    --RADI
         * 12.system record- potreban add samo admin               --RADI
         * 13.toys-potreban add                                    --RADI
         * 14.food-add                                             --RADI
         * 15.vet visit-potreban add                               --RADI
        */

        //Ovo oboje treba kad se životinja dodaje

        [HttpPost("addAnimalRecord")]
        [AllowAnonymous]
        public async Task AddAnimalAsync([FromBody] AnimalRecordDomain record)
        {
            await _service.AddAnimalRecord(record.AnimalId);
        }

        [HttpPost("addAnimalFound")]
        [AllowAnonymous]
        public async Task AddFoundRecord([FromBody] FoundRecordDomain record)
        {
            await _service.AddFoundRecord(record.AnimalId, record.Date, record.Adress, record.Description, record.OwnerName, record.OwnerSurname, record.OwnerPhoneNumber, record.OwnerOIB, record.RegisterId);
        }

        [HttpPost("addFood")]
        [AllowAnonymous]
        public async Task<IActionResult> AddFood([FromBody] FoodDomain response)
        {
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.AddFood(
                response.BrandName,
                response.Name,
                response.FoodType,
                response.AnimalType,
                response.AgeGroup,
                response.Weight,
                response.CaloriesPerServing,
                response.WeightPerServing,
                response.MeasurementPerServing,
                response.FatContent,
                response.FiberContent,
                response.ExporationDate,
                response.Quantity,
                response.Notes,
                response.MeasurementWeight

            );
            
            return Ok();
        }

        [HttpPost("addToy")]
        [AllowAnonymous]
        public async Task<IActionResult> AddToy([FromBody] ToysDomain response)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.AddToys(
               response.BrandName,
               response.Name,
               response.AnimalType,
               response.ToyType,
               response.AgeGroup,
              response.Hight,
              response.Width,
              response.Quantity,
              response.Notes

            );

            return Ok();
        }

        [HttpPost("addNews")]
        [AllowAnonymous]
        public async Task<IActionResult> AddNews([FromBody] NewsDomain response)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.AddNews(
           response.Name,
           response.Description,
           response.DateTime

            );

            return Ok();
        }

        [HttpPost("addVetVisit")]
        [AllowAnonymous]
        public async Task AddVetVisit([FromBody] VetVisitsDomain record)
        {
            await _service.AddVetVsit(
                record.AnimalId,
                record.StartTime,
                record.EndTime,
                record.TypeOfVisit,
                record.Notes
                
                );
        }

        [HttpPost("addSystemRecord")]
        [AllowAnonymous]
        public async Task AddSystemRecord([FromBody] SystemRecordDomain record)
        {
            await _service.AddSystemRecord(
                record.RecordNumber,
                record.RecordName,
                record.RecordDescription
                );
        }

        [HttpPost("addMedicines")]
        [AllowAnonymous]
        public async Task AddMedicines([FromBody] MedicinesDomain record)
        {
            await _service.AddMedicines(
               record.AnimalId,
               record.NameOfMedicines,
               record.Description,
               record.VetUsername,
               record.AmountOfMedicine,
               record.MesurmentUnit,
               record.MedicationIntake,
               record.FrequencyOfMedicationUse,
               record.Usage
                );
        }
        
        [HttpPost("addFunds")]
        [AllowAnonymous]
        public async Task AddFunds([FromBody] FundsDomain record)
        {
            await _service.AddFunds(
              record.AdopterId,
              record.Amount,
              record.Purpose,
              record.Iban
     
                );
        }


        [HttpPost("addEuthanasia")]
        [AllowAnonymous]
        public async Task AddEuthanasia([FromBody] EuthanasiaDomain record)
        {
            await _service.AddEuthanasia(
                record.AnimalId,
                record.Date,
                record.NameOfDesissse,
                record.Complited
             
                );
        }

        [HttpPost("addContageus")]
        [AllowAnonymous]
        public async Task AddContageus([FromBody] ContageusAnimalsDomain record)
        {
            await _service.AddContageus(
              record.AnimalId,
              record.DesisseName,
              record.StartTime,
              record.Description,
              record.Contageus
                );
        }


        [HttpPost("addContact")]
        [AllowAnonymous]
        public async Task AddContact([FromBody] ContactDomain record)
        {
            await _service.AddContact(
            record.Name,
            record.Email,
            record.Description,
            record.AdopterId
                );
        }

        [HttpPost("addBalans")]
        [AllowAnonymous]
        public async Task AddBalans([FromBody] BalansDomain record)
        {
            await _service.AddBalans(
        record.Iban,
  
        record.Password,
        record.Type
                );
        }

        [HttpPost("addLabs")]
        [AllowAnonymous]
        public async Task<IActionResult> AddLab([FromBody] LabsDomain lab)
        {

            LabsDomain success = await _service.AddLab(lab.AnimalId, lab.DateTime);

            if (success != null)
            {
                return Ok(success);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("addParametar")]
        [AllowAnonymous]
        public async Task AddParametar([FromBody] ParameterDomain record)
        {
            await _service.AddParametar(record);
        }

        [HttpPost("addTransactions")]
        [AllowAnonymous]
        public async Task AddTransactions([FromBody] TransactionsDomain record)
        {
            await _service.AddTransactions(record);
        }










        //UPDATE
        //---------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------

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
        public async Task<IActionResult> UpdateAnimal([FromBody] AdoptedDomain request)
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
      
        [HttpPut("flag/{adopterId}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateAdopterFlag(int adopterId)
        {
            await _service.UpdateAdopterFlag(adopterId);

            return Ok(new { Message = "Adoption status updated successfully" });
        }






        //ubdate novo
        //---------------------------------------------------------------------------------------------------------------------------
        //update novo
        // 15 novih tablica  13/15
        /*1.animalrecord-                             --RADI 
         *2. Balans-                                  --RADI
         * 3.Contact-                                 --NE TREBA-osoba nemože  mjenjat oruku koju je poslala
         * 4.contageus animals-                       --RADI
         * 5 euthanasia-                              --RADI
         * 6.found record-                            --RADI                                      - NE SMIJEŠ POSLAT KRIVI REGISTER ID
         * 7.funds-                                   --NE TREBA-  osoba nemože mjenjat količinu novca koju je poslala
         * 8.labs-                                    --NE TREBA
         * 9.parametar-                               --RADI
         * 10.medicines-                              --RADI
         * 11.news-                                   --RADI
         * 12.system record-                          --NE TREBA
         * 13.toys-                                   --RADI
         * 14.food-                                   --RADI
         * 15.vet visit-                              --RADI
        */
        [HttpPut("updateAnimalRecord")]
        [AllowAnonymous]
        public async Task UpdateAnimalRecordDomain([FromBody] AnimalRecordDomain record)
        {            
                 await _service.UpdateAnimalRecordDomain(
                      record.AnimalId,
                      record.RecordId);
        }

        [HttpPut("updateBalansDomain")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateAnimalBalansDomain([FromBody] BalansDomain record)
        {
            try
            {
                await _service.UpdateAnimalBalansDomain(
               record.Id,
               record.Balance
         

                      );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating animal record: {ex.Message}");
            }
            return Ok(new { Message = "Animal record updated successfully" });
        }

        [HttpPut("updateContageusAnimalsDomain")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateContageusAnimalsDomain([FromBody] ContageusAnimalsDomain record)
        {
            try
            {
                await _service.UpdateContageusAnimalsDomain(
             record.Id,
             record.Contageus
                      );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating animal record: {ex.Message}");
            }
            return Ok(new { Message = "Animal record updated successfully" });
        }

        [HttpPut("updateEuthanasiaDomain")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateEuthanasiaDomain([FromBody] EuthanasiaDomain record)
        {
            try
            {
                await _service.UpdateEuthanasiaDomain(
             record.Id,
            record.Date,
            record.Complited
                      );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating animal record: {ex.Message}");
            }
            return Ok(new { Message = "Animal record updated successfully" });
        }

        [HttpPut("updateFoodDomainIncrement")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateFoodDomainIncrement([FromBody] FoodDomain record)
        {
            try
            {
                await _service.UpdateFoodDomainIncrement(
                      record.Id );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating animal record: {ex.Message}");
            }
            return Ok(new { Message = "Animal record updated successfully" });
        }

        [HttpPut("updateFoodDomainDecrement")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateFoodDomainDecrement([FromBody] FoodDomain record)
        {
            try
            {
                await _service.UpdateFoodDomainDecrement(
             record.Id

                      );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating animal record: {ex.Message}");
            }
            return Ok(new { Message = "Animal record updated successfully" });
        }

        [HttpPut("updateFoodDomain")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateFoodDomain([FromBody] FoodDomain record)
        {
            try
            {
                await _service.UpdateFoodDomain(record );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating animal record: {ex.Message}");
            }
            return Ok(new { Message = "Animal record updated successfully" });
        }

        [HttpPut("updateToyDomainIncrement")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateToysDomainIncrement([FromBody] ToysDomain record)
        {
            try
            {
                await _service.UpdateToysDomainIncrement(
             record.Id

                      );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating animal record: {ex.Message}");
            }
            return Ok(new { Message = "Animal record updated successfully" });
        }

        [HttpPut("updateToysDomainDecrement")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateToysDomainDecrement([FromBody] ToysDomain record)
        {
            try
            {
                await _service.UpdateToysDomainDecrement(
             record.Id

                      );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating animal record: {ex.Message}");
            }
            return Ok(new { Message = "Animal record updated successfully" });
        }

        [HttpPut("updateToysDomain")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateToysDomain([FromBody] ToysDomain record)
        {
            try
            {
                await _service.UpdateToysDomain(
             record

                      );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating animal record: {ex.Message}");
            }
            return Ok(new { Message = "Animal record updated successfully" });
        }

        [HttpPut("updateFoundRecordDomain")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateFoundRecordDomain([FromBody] FoundRecordDomain record)
        {
            try
            {
                await _service.UpdateFoundRecordDomain(
                    record.Id,
                    record.AnimalId,
                    record.Date,
                    record.Adress,
                    record.Description,
                    record.OwnerName,
                    record.OwnerSurname,
                    record.OwnerPhoneNumber,
                    record.OwnerOIB,
                    record.RegisterId

                      );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating animal record: {ex.Message}");
            }
            return Ok(new { Message = "Animal record updated successfully" });
        }

        [HttpPut("updateMedicinesDomainUsage")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateMedicinesDomainUsage([FromBody] MedicinesDomain record)
        {
            try
            {
                await _service.UpdateMedicinesDomainUsage(
                    record.Id,
                    record.Usage

                   

                      );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating animal record: {ex.Message}");
            }
            return Ok(new { Message = "Animal record updated successfully" });
        }

        [HttpPut("updateMedicinesDomain")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateMedicinesDomain([FromBody] MedicinesDomain record)
        {
            try
            {
                await _service.UpdateMedicinesDomain(
                    record.Id,
                    record.AmountOfMedicine,
                    record.MesurmentUnit,
                    record.MedicationIntake,
                    record.FrequencyOfMedicationUse
                      );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating animal record: {ex.Message}");
            }
            return Ok(new { Message = "Animal record updated successfully" });
        }

        [HttpPut("updateNewsDomain")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateNewsDomain([FromBody] NewsDomain record)
        {
            try
            {
                await _service.UpdateNewsDomain(
                    record.Id,
                    record.Name,
                    record.Description,
                    record.DateTime
                      );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating animal record: {ex.Message}");
            }
            return Ok(new { Message = "Animal record updated successfully" });
        }

        [HttpPut("updateVetVisitsDomain")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateVetVisitsDomain([FromBody] VetVisitsDomain record)
        {
            try
            {
                await _service.UpdateVetVisitsDomain(
                    record.Id,
                    record.StartTime,
                    record.EndTime,
                    record.Notes
                      );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating animal record: {ex.Message}");
            }
            return Ok(new { Message = "Animal record updated successfully" });
        }
        
        [HttpPut("updateContactDomain")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateContactDomain([FromBody] ContactDomain record)
        {
            try
            {
                await _service.UpdateContactDomain(
                    record.Id
                  
                      );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating animal record: {ex.Message}");
            }
            return Ok(new { Message = "Animal record updated successfully" });
        }

        [HttpPut("updateParametar")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateParametar([FromBody] ParameterDomain record)
        {
            try
            {
                await _service.UpdateParametar(record);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating animal record: {ex.Message}");
            }
            return Ok(new { Message = "Animal record updated successfully" });
        }





        //Zasebni podaci za životinje Update i Add

  
        [HttpPost("addBird")]
        [AllowAnonymous]
        public async Task<IActionResult> AddBirdAsync([FromBody] BirdDomain record)
        {
            try
            {
             await _service.AddBirdAsync(record);
                return Ok();
            }
            catch(Exception ex)
            {
                throw new Exception(" "+ex.InnerException);
            }
        }
        [HttpPost("addMammal")]
        [AllowAnonymous]
        public async Task<IActionResult> AddMammalAsync([FromBody] MammalDomain record)
        {
            try { 
            await _service.AddMammalAsync(record);
            return Ok();
             }
            catch(Exception ex)
            {
                throw new Exception(" "+ex.InnerException);
             }
        }
        [HttpPost("addFish")]
        [AllowAnonymous]
        public async Task<IActionResult> AddFishAsync([FromBody] FishDomain record)
        {
            try { 
            await _service.AddFishAsync(record);
            return Ok();
            }
            catch(Exception ex)
            {
                throw new Exception(" "+ex.InnerException);
              }
            }

        [HttpPost("addReptile")]
        [AllowAnonymous]
        public async Task<IActionResult> AddReptileAsync([FromBody] ReptileDomain record)
        {
            try { 
            await _service.AddReptileAsync(record);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(" " + ex.InnerException);
            }
        }
        [HttpPost("addAmphibian")]
        [AllowAnonymous]
        public async Task<IActionResult> AddAmphibianAsync([FromBody] AmphibianDomain record)
        {
            try { 
            await _service.AddAmphibianAsync(record);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(" " + ex.InnerException);
            }
        }



        //UPDATE 

        [HttpPut("updateBird")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateBird([FromBody] BirdDomain record)
        {
            try
            {
                await _service.UpdateBird(record);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating animal record: {ex.Message}");
            }
            return Ok(new { Message = "Animal record updated successfully" });
        }

        [HttpPut("updateMammal")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateMammal([FromBody] MammalDomain record)
        {
            try
            {
                await _service.UpdateMammal(record);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating animal record: {ex.Message}");
            }
            return Ok(new { Message = "Animal record updated successfully" });
        }

        [HttpPut("updateFish")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateFish([FromBody] FishDomain record)
        {
            try
            {
                await _service.UpdateFish(record);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating animal record: {ex.Message}");
            }
            return Ok(new { Message = "Animal record updated successfully" });
        }

        [HttpPut("updateReptile")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateReptile([FromBody] ReptileDomain record)
        {
            try
            {
                await _service.UpdateReptile(record);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating animal record: {ex.Message}");
            }
            return Ok(new { Message = "Animal record updated successfully" });
        }

        [HttpPut("updateAmphibian")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateAmphibian([FromBody] AmphibianDomain record)
        {
            try
            {
                await _service.UpdateAmphibian(record);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating animal record: {ex.Message}");
            }
            return Ok(new { Message = "Animal record updated successfully" });
        }








        //NEBITNO I NEPOTREBNO :)
        //Delete
        //-----------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------------------
        // Napravi u onom record ako je životinja mrtva da umjesto ovoga joj se stavi dead u recordu 


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
        [HttpDelete("deleteNews/{idNews}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteNews(int id) {
            try
            {
                await _service.DeleteNews(id);
                return Ok("News successfully deleted.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"News with ID {id} not found.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
        [HttpDelete("{idAnimal}")]
         [AllowAnonymous]
         public async Task<IActionResult> Delete(int idAnimal)
         {
             try
             {


                 await _service.DeleteAnimal(idAnimal);


                 return Ok("Animal successfully deleted.");
             }
             catch (KeyNotFoundException)
             {
                 return NotFound($"Animal with ID {idAnimal} not found.");
             }
             catch (InvalidOperationException ex)
             {

                 return BadRequest(ex.Message);
             }
             catch (Exception ex)
             {
               

                 return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
             }
         }






        //Bilo potrebno imat, nema smisla da je tu
        /* [HttpPut("deladopted/{adopterId}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteAdoptedAsync(int adopterId)
        {
            await _service.DeleteAdoptedAsync(adopterId);

            return Ok(new { Message = "Adoption status updated successfully" });
        }*/

        //ovo sve ispod ne radi ali je prikazano bilo da izgleda da radi :)
        /*
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

         //NE RADI
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

        */


    }
}
