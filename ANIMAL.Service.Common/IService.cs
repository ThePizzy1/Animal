using System;
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
        IEnumerable<AdopterDomain> GetAllAdopterDomain();
        IEnumerable<MammalDomain> GetAllMammalDomain();
        IEnumerable<BirdDomain> GetAllBirdDomain();
        IEnumerable<AmphibianDomain> GetAllAmphibianDomain();
        IEnumerable<ReptileDomain> GetAllReptileDomain();
        IEnumerable<FishDomain> GetAllFishDomain();
        IEnumerable<AdoptedDomain> GetAllAdoptedDomain();
        IEnumerable<ReturnedAnimalDomain> GetAllReturnedAnimalDomain();
    }
}
