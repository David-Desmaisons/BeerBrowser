using System.Threading.Tasks;
using BeerAPI.Services.DTO;

namespace BeerAPI.Services
{
    public interface IBeerUpdater
    {
        Task Delete(int beerId);

        Task Update(UpdateBeerCommand command);

        Task Create(CreateBeerCommand command);
    }
}
