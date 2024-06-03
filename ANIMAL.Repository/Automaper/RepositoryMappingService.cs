using System;
using System.Collections.Generic;
using System.Text;
using ANIMAL.DAL.DataModel;
using ANIMAL.Repository.Common;
using ANIMAL.MODEL;
using AutoMapper;

namespace ANIMAL.Repository.Automaper
{
    public class RepositoryMappingService : IRepositoryMappingService
    {
        public Mapper mapper;
        public RepositoryMappingService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Adopted, AdoptedDomain>()
                    .ForMember(dest => dest.Adopter, opt => opt.MapFrom(src => src.Adopter))
                    .ForMember(dest => dest.Animal, opt => opt.MapFrom(src => src.Animal));
                cfg.CreateMap<AdoptedDomain, Adopted>();

                cfg.CreateMap<Adopter, AdopterDomain>();
                cfg.CreateMap<AdopterDomain, Adopter>();

                cfg.CreateMap<Amphibians, AmphibianDomain>()
                    .ForMember(dest => dest.Animal, opt => opt.MapFrom(src => src.Animal));
                cfg.CreateMap<AmphibianDomain, Amphibians>();

                cfg.CreateMap<Animals, AnimalDomain>();
                cfg.CreateMap<AnimalDomain, Animals>();

                cfg.CreateMap<Birds, BirdDomain>()
                    .ForMember(dest => dest.Animal, opt => opt.MapFrom(src => src.Animal));
                cfg.CreateMap<BirdDomain, Birds>();

                cfg.CreateMap<Fish, FishDomain>()
                    .ForMember(dest => dest.Animal, opt => opt.MapFrom(src => src.Animal));
                cfg.CreateMap<FishDomain, Fish>();

                cfg.CreateMap<Mammals, MammalDomain>()
                    .ForMember(dest => dest.Animal, opt => opt.MapFrom(src => src.Animal));
                cfg.CreateMap<MammalDomain, Mammals>();

                cfg.CreateMap<Reptiles, ReptileDomain>()
                    .ForMember(dest => dest.Animal, opt => opt.MapFrom(src => src.Animal));
                cfg.CreateMap<ReptileDomain, Reptiles>();

                cfg.CreateMap<ReturnedAnimal, ReturnedAnimalDomain>()
                    .ForMember(dest => dest.Adopter, opt => opt.MapFrom(src => src.Adopter))
                    .ForMember(dest => dest.Animal, opt => opt.MapFrom(src => src.Animal))
                    .ForMember(dest => dest.AdoptionCodeNavigation, opt => opt.MapFrom(src => src.AdoptionCodeNavigation));
                cfg.CreateMap<ReturnedAnimalDomain, ReturnedAnimal>();
            });

            mapper = new Mapper(config);
        }

        
    

        public TDestination Map<TDestination>(object source)
        {
            return mapper.Map<TDestination>(source);
        }
    }
}
