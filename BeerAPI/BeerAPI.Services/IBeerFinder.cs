using System.Collections.Generic;
using System.Threading.Tasks;
using BeerAPI.Data.Entity;

namespace BeerAPI.Services
{
    public interface IBeerFinder
    {
        Task<IList<Beer>> FindByCriteria();

        Beer FindById(int id);
    }
}
