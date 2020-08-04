using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerAPI.Services.DTO;

namespace BeerAPI.Services
{
    public class BeerFinder : IBeerFinder
    {
        public Task<IList<BeerDescriptionResult>> FindByCriteria(BeerQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<BeerResult> FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
