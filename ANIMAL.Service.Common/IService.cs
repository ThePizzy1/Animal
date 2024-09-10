﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ANIMAL.DAL.DataModel;
using ANIMAL.MODEL;
namespace ANIMAL.Service.Common
{
    public  interface IService
    {
    
        IEnumerable<AnimalDomain> GetAllAnimalDomain();
        IEnumerable<AnimalDomain> GetAllAnimalDomainAdopt();
        IEnumerable<AdopterDomain> GetAllAdopterDomain();
        public MammalDomain GetAllMammalDomain(int id);
        public BirdDomain GetAllBirdDomain(int id);
        public AmphibianDomain GetAllAmphibianDomain(int id);
        public ReptileDomain GetAllReptileDomain(int id);
        public FishDomain GetAllFishDomain(int id);
        IEnumerable<AdoptedDomain> GetAllAdoptedDomain();
        IEnumerable<ReturnedAnimalDomain> GetAllReturnedAnimalDomain();
        public IEnumerable<AnimalDomain> GetAllAnimalDomainNoPicture();
        public AnimalDomain GetAnimalById(int animalId);
        public AnimalDomain GetAllAnimalById(int animalId);
        public AdopterDomain GetAdopterByUsername(string username);
        public AdopterDomain GetAdopterById(string id);
        public IEnumerable<AdoptedDomain> GetAllAdoptedDomainForAdopter(int adopterId);
        public Task<AdopterDomain> CreateAdopterAsync(string firstName, string lastName, DateTime dateOfBirth, string residence, string username, string password, string registerId);
                public void DeleteAnimal(int idAnimal);
        Task<bool> AddAnimalAsync(string name,
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
        bool adopted);

        public Task IncrementNumberOfAdoptedAnimalsAsync(string registerId);
        public Task IncrementNumberOfReturnedAnimalsAsync(string registerId);
        public Task<AdopterDomain> UpdateAdopterAsync(string registerId, string firstName, string lastName, DateTime dateOfBirth, string residence, string username, string password);
        public Task<AnimalDomain> UpdateAnimalAsync(int idAnimal, int age, decimal weight, decimal height, decimal length, bool neutered, bool vaccinated, bool microchipped, bool trained, bool socialized, string healthIssues, string personalityDescription);
        public Task UpdateBird(int id, string cageSize, string recommendedToys, string sociability);
        public  Task<bool> AdoptionStatus(int animalId);
        public Task<bool> UpdateAdopterFlag(int adopterId);
        public  Task<bool> AdoptionStatusFalse(int animalId);



        public Task<bool> CreateReturnedAnimalAsync( int adoptionCode, int animalId, int adopterId, DateTime returnDate, string returnReason);
        public  Task<bool> CreateAdoptedAsync(int animalId, int adopterId, DateTime adoptionDate);
        public Task<bool> AddBirdAsync(BirdDomain birdDomain);
        public Task<bool> AddMammalAsync(MammalDomain mammalDomain);
        public Task<bool> AddFishAsync(FishDomain fishDomain);
        public Task<bool> AddReptileAsync(ReptileDomain reptileDomain);
        public Task<bool> AddAmphibianAsync(AmphibianDomain amphibianDomain);
        public IEnumerable<ReturnedAnimalDomain> GetAllReturnedAnimalsForAdopter(int adopterId);  

        public  Task<bool> DeleteAdoptedAsync(int adoptedId);
        public  void DeleteAdoptedReturn(int adoptedId);
    }
}
