using ANIMAL.DAL.DataModel;
using ANIMAL.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.Repository.Automaper
{
    public interface IRepositoryMappingService { 
         TDestination Map<TDestination>(object source);
        

    }
}
