using System.Collections.Generic;
using System.Threading.Tasks;
using BeerAPI.Services.DTO;

namespace BeerAPI.Services
{
    public interface IBeerFinder
    {
        Task<IList<BeerDescriptionResult>> FindByCriteria(BeerQuery query);

        Task<BeerResult> FindById(int id);
    }
}
