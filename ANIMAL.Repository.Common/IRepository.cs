
using System.Collections.Generic;

using System.Threading.Tasks;
using ANIMAL.DAL.DataModel;
using ANIMAL.MODEL;
namespace ANIMAL.Repository.Common
{
  public   interface IRepository { 
     
        IEnumerable<AnimalDomain> GetAllAnimalDomain();
        IEnumerable<AdopterDomain> GetAllAdopterDomain();
        IEnumerable<MammalDomain> GetAllMammalDomain();
        IEnumerable<BirdDomain> GetAllBirdDomain();
        IEnumerable<AmphibianDomain> GetAllAmphibianDomain();
        IEnumerable<ReptileDomain> GetAllReptileDomain();
        IEnumerable<FishDomain> GetAllFishDomain();
        IEnumerable<AdoptedDomain> GetAllAdoptedDomain();

    }
}
