using System.Threading.Tasks;
using BeerAPI.Services.DTO;

namespace BeerAPI.Services
{
    public interface IBeerFinder
    {
        Task<BeerQueryResult> FindByCriteria(BeerQuery query);

        Task<BeerResult> FindById(int id);
    }
}
