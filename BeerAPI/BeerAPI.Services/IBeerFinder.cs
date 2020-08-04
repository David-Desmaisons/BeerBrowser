using System.Collections.Generic;
using System.Threading.Tasks;
using BeerAPI.Services.DTO;

namespace BeerAPI.Services
{
    public interface IBeerFinder
    {
        Task<IList<BeerDescriptionResult>> FindByCriteria(BeerQuery query);

        BeerResult FindById(int id);
    }
}
