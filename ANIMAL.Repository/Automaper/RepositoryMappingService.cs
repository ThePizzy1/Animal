using System;
using System.Collections.Generic;
using System.Text;
using ANIMAL.DAL.DataModel;
using ANIMAL.Repository.Common;
using ANIMAL.MODEL;
using AutoMapper;
using System.Linq;

namespace ANIMAL.Repository.Automaper
{

    public class RepositoryMappingService : IRepositoryMappingService
    {
        public Mapper mapper;

        public RepositoryMappingService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AnimalDomain, Animals>()
                    .ForMember(dest => dest.Birds, opt => opt.Ignore())
                    .ForMember(dest => dest.Reptiles, opt => opt.Ignore())
                    .ForMember(dest => dest.AdoptedNavigation, opt => opt.Ignore())
                    .ForMember(dest => dest.ReturnedAnimal, opt => opt.Ignore());

                cfg.CreateMap<Animals, AnimalDomain>();

                cfg.CreateMap<Adopted, AdoptedDomain>()
                  .ForMember(dest => dest.Adopter, opt => opt.MapFrom(src => src.Adopter))
                  .ForMember(dest => dest.Animal, opt => opt.MapFrom(src => src.Animal));

                cfg.CreateMap<AdoptedDomain, Adopted>()
                    .ForMember(dest => dest.Adopter, opt => opt.Ignore())
                    .ForMember(dest => dest.Animal, opt => opt.Ignore());

                cfg.CreateMap<Adopter, AdopterDomain>()
                    .ForMember(dest => dest.Adopted, opt => opt.Ignore())
                    .ForMember(dest => dest.ReturnedAnimal, opt => opt.Ignore());

                cfg.CreateMap<AdopterDomain, Adopter>()
                    .ForMember(dest => dest.Adopted, opt => opt.Ignore())
                    .ForMember(dest => dest.ReturnedAnimal, opt => opt.Ignore());

                cfg.CreateMap<Amphibians, AmphibianDomain>()
                    .ForMember(dest => dest.IdAnimal, opt => opt.MapFrom(src => src.Animal.IdAnimal))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Animal.Name))
                    .ForMember(dest => dest.Family, opt => opt.MapFrom(src => src.Animal.Family))
                    .ForMember(dest => dest.Species, opt => opt.MapFrom(src => src.Animal.Species))
                    .ForMember(dest => dest.Subspecies, opt => opt.MapFrom(src => src.Animal.Subspecies))
                    .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Animal.Age))
                    .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Animal.Gender))
                    .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Animal.Weight))
                    .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Animal.Height))
                    .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.Animal.Length))
                    .ForMember(dest => dest.Neutered, opt => opt.MapFrom(src => src.Animal.Neutered))
                    .ForMember(dest => dest.Vaccinated, opt => opt.MapFrom(src => src.Animal.Vaccinated))
                    .ForMember(dest => dest.Microchipped, opt => opt.MapFrom(src => src.Animal.Microchipped))
                    .ForMember(dest => dest.Trained, opt => opt.MapFrom(src => src.Animal.Trained))
                    .ForMember(dest => dest.Socialized, opt => opt.MapFrom(src => src.Animal.Socialized))
                    .ForMember(dest => dest.HealthIssues, opt => opt.MapFrom(src => src.Animal.HealthIssues))
                    .ForMember(dest => dest.PersonalityDescription, opt => opt.MapFrom(src => src.Animal.PersonalityDescription))
                    .ForMember(dest => dest.Adopted, opt => opt.MapFrom(src => src.Animal.Adopted));

                cfg.CreateMap<AmphibianDomain, Amphibians>()
                    .ForMember(dest => dest.Animal, opt => opt.Ignore());



                // Mapiranja za BirdDomain i Birds
                cfg.CreateMap<Birds, BirdDomain>()
                    .ForMember(dest => dest.IdAnimal, opt => opt.MapFrom(src => src.Animal.IdAnimal))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Animal.Name))
                    .ForMember(dest => dest.Family, opt => opt.MapFrom(src => src.Animal.Family))
                    .ForMember(dest => dest.Species, opt => opt.MapFrom(src => src.Animal.Species))
                    .ForMember(dest => dest.Subspecies, opt => opt.MapFrom(src => src.Animal.Subspecies))
                    .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Animal.Age))
                    .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Animal.Gender))
                    .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Animal.Weight))
                    .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Animal.Height))
                    .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.Animal.Length))
                    .ForMember(dest => dest.Neutered, opt => opt.MapFrom(src => src.Animal.Neutered))
                    .ForMember(dest => dest.Vaccinated, opt => opt.MapFrom(src => src.Animal.Vaccinated))
                    .ForMember(dest => dest.Microchipped, opt => opt.MapFrom(src => src.Animal.Microchipped))
                    .ForMember(dest => dest.Trained, opt => opt.MapFrom(src => src.Animal.Trained))
                    .ForMember(dest => dest.Socialized, opt => opt.MapFrom(src => src.Animal.Socialized))
                    .ForMember(dest => dest.HealthIssues, opt => opt.MapFrom(src => src.Animal.HealthIssues))
                    .ForMember(dest => dest.PersonalityDescription, opt => opt.MapFrom(src => src.Animal.PersonalityDescription))
                    .ForMember(dest => dest.Adopted, opt => opt.MapFrom(src => src.Animal.Adopted));

                cfg.CreateMap<BirdDomain, Birds>()
                    .ForMember(dest => dest.Animal, opt => opt.Ignore());

                // Mapiranja za FishDomain i Fish
                cfg.CreateMap<Fish, FishDomain>()
                    .ForMember(dest => dest.IdAnimal, opt => opt.MapFrom(src => src.Animal.IdAnimal))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Animal.Name))
                    .ForMember(dest => dest.Family, opt => opt.MapFrom(src => src.Animal.Family))
                    .ForMember(dest => dest.Species, opt => opt.MapFrom(src => src.Animal.Species))
                    .ForMember(dest => dest.Subspecies, opt => opt.MapFrom(src => src.Animal.Subspecies))
                    .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Animal.Age))
                    .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Animal.Gender))
                    .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Animal.Weight))
                    .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Animal.Height))
                    .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.Animal.Length))
                    .ForMember(dest => dest.Neutered, opt => opt.MapFrom(src => src.Animal.Neutered))
                    .ForMember(dest => dest.Vaccinated, opt => opt.MapFrom(src => src.Animal.Vaccinated))
                    .ForMember(dest => dest.Microchipped, opt => opt.MapFrom(src => src.Animal.Microchipped))
                    .ForMember(dest => dest.Trained, opt => opt.MapFrom(src => src.Animal.Trained))
                    .ForMember(dest => dest.Socialized, opt => opt.MapFrom(src => src.Animal.Socialized))
                    .ForMember(dest => dest.HealthIssues, opt => opt.MapFrom(src => src.Animal.HealthIssues))
                    .ForMember(dest => dest.PersonalityDescription, opt => opt.MapFrom(src => src.Animal.PersonalityDescription))
                    .ForMember(dest => dest.Adopted, opt => opt.MapFrom(src => src.Animal.Adopted));

                cfg.CreateMap<FishDomain, Fish>()
                    .ForMember(dest => dest.Animal, opt => opt.Ignore());
                cfg.CreateMap<Mammals, MammalDomain>()
    .ForMember(dest => dest.AnimalId, opt => opt.MapFrom(src => src.Animal.IdAnimal))
    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Animal.Name))
    .ForMember(dest => dest.Family, opt => opt.MapFrom(src => src.Animal.Family))
    .ForMember(dest => dest.Species, opt => opt.MapFrom(src => src.Animal.Species))
    .ForMember(dest => dest.Subspecies, opt => opt.MapFrom(src => src.Animal.Subspecies))
    .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Animal.Age))
    .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Animal.Gender))
    .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Animal.Weight))
    .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Animal.Height))
    .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.Animal.Length))
    .ForMember(dest => dest.Neutered, opt => opt.MapFrom(src => src.Animal.Neutered))
    .ForMember(dest => dest.Vaccinated, opt => opt.MapFrom(src => src.Animal.Vaccinated))
    .ForMember(dest => dest.Microchipped, opt => opt.MapFrom(src => src.Animal.Microchipped))
    .ForMember(dest => dest.Trained, opt => opt.MapFrom(src => src.Animal.Trained))
    .ForMember(dest => dest.Socialized, opt => opt.MapFrom(src => src.Animal.Socialized))
    .ForMember(dest => dest.HealthIssues, opt => opt.MapFrom(src => src.Animal.HealthIssues))
    .ForMember(dest => dest.PersonalityDescription, opt => opt.MapFrom(src => src.Animal.PersonalityDescription))
    .ForMember(dest => dest.Adopted, opt => opt.MapFrom(src => src.Animal.Adopted));

                cfg.CreateMap<MammalDomain, Mammals>()
                    .ForMember(dest => dest.Animal, opt => opt.Ignore());



                cfg.CreateMap<Reptiles, ReptileDomain>()
    .ForMember(dest => dest.AnimalId, opt => opt.MapFrom(src => src.Animal.IdAnimal))
    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Animal.Name))
    .ForMember(dest => dest.Family, opt => opt.MapFrom(src => src.Animal.Family))
    .ForMember(dest => dest.Species, opt => opt.MapFrom(src => src.Animal.Species))
    .ForMember(dest => dest.Subspecies, opt => opt.MapFrom(src => src.Animal.Subspecies))
    .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Animal.Age))
    .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Animal.Gender))
    .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Animal.Weight))
    .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Animal.Height))
    .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.Animal.Length))
    .ForMember(dest => dest.Neutered, opt => opt.MapFrom(src => src.Animal.Neutered))
    .ForMember(dest => dest.Vaccinated, opt => opt.MapFrom(src => src.Animal.Vaccinated))
    .ForMember(dest => dest.Microchipped, opt => opt.MapFrom(src => src.Animal.Microchipped))
    .ForMember(dest => dest.Trained, opt => opt.MapFrom(src => src.Animal.Trained))
    .ForMember(dest => dest.Socialized, opt => opt.MapFrom(src => src.Animal.Socialized))
    .ForMember(dest => dest.HealthIssues, opt => opt.MapFrom(src => src.Animal.HealthIssues))
    .ForMember(dest => dest.PersonalityDescription, opt => opt.MapFrom(src => src.Animal.PersonalityDescription))
    .ForMember(dest => dest.Adopted, opt => opt.MapFrom(src => src.Animal.Adopted))
    .ForMember(dest => dest.TankSize, opt => opt.MapFrom(src => src.TankSize))
    .ForMember(dest => dest.Sociability, opt => opt.MapFrom(src => src.Sociability))
    .ForMember(dest => dest.CompatibleSpecies, opt => opt.MapFrom(src => src.CompatibleSpecies))
    .ForMember(dest => dest.RecommendedItems, opt => opt.MapFrom(src => src.RecommendedItems));

                cfg.CreateMap<ReptileDomain, Reptiles>()
                    .ForMember(dest => dest.Animal, opt => opt.Ignore());


                                // Mapiranja za ReturnedAnimalDomain i ReturnedAnimal
                cfg.CreateMap<ReturnedAnimal, ReturnedAnimalDomain>()
                     .ForMember(dest => dest.Animal, opt => opt.MapFrom(src => src.Animal))
                    .ForMember(dest => dest.AdoptionCodeNavigation, opt => opt.MapFrom(src => new AdoptedDomain(src.AdoptionCodeNavigation)))
                    .ForMember(dest => dest.Adopter, opt => opt.MapFrom(src => src.Adopter));

                cfg.CreateMap<ReturnedAnimalDomain, ReturnedAnimal>()
                    .ForMember(dest => dest.Animal, opt => opt.Ignore())
                    .ForMember(dest => dest.AdoptionCodeNavigation, opt => opt.Ignore())
                    .ForMember(dest => dest.Adopter, opt => opt.Ignore());


               
                //animal record
                cfg.CreateMap<AnimalRecordDomain, AnimalRecord>()
                  .ForMember(dest => dest.Animal, opt => opt.Ignore())
                   .ForMember(dest => dest.Record, opt => opt.Ignore());
                cfg.CreateMap<AnimalRecord, AnimalRecordDomain>()
                     .ForMember(dest => dest.Animal, opt => opt.Ignore())
                      .ForMember(dest => dest.Record, opt => opt.Ignore());


            });


            mapper = new Mapper(config);





                        }

     
        public TDestination Map<TDestination>(object source)
        {
            return mapper.Map<TDestination>(source);
        }
    }
}
