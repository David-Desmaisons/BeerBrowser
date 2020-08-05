using System;
using System.Threading.Tasks;
using BeerAPI.Data.Entity;
using BeerAPI.Services.DTO;
using NHibernate;

namespace BeerAPI.Services.Implementation
{
    public class BeerUpdater : IBeerUpdater
    {
        private readonly ISession _Session;

        public BeerUpdater(ISession session)
        {
            _Session = session;
        }

        public async Task Delete(int beerId)
        {
            var beer = new Beer() { Id = beerId };
            await _Session.DeleteAsync(beer);
        }

        public async Task Update(UpdateBeerCommand command)
        {
            var entity = await _Session.LoadAsync<Beer>(command.Id);
            if (entity == null)
            {
                throw new ArgumentOutOfRangeException(nameof(command.Id));
            }

            using (var transaction = _Session.BeginTransaction())
            {
                var information = command.Information;
                Update(entity, information);
                entity.Ingredients.Clear();
                await SetIngredients(entity, information.Ingredients);
                await _Session.UpdateAsync(entity);
                await transaction.CommitAsync();
            }
        }

        public async Task Create(CreateBeerCommand command)
        {
            using (var transaction = _Session.BeginTransaction())
            {
                var information = command.Information;
                var beer = Convert(information);
                await SetIngredients(beer, information.Ingredients);
                await _Session.SaveAsync(beer);
                await transaction.CommitAsync();
            }
        }

        private void Update(Beer entity, BeerInformation information)
        {
            entity.Name = information.Name;
            entity.AlcoholPercentage = information.AlcoholPercentage;
            entity.Color = information.Color;
            entity.Description = information.Description;
            entity.Harmonization = information.Harmonization;
            entity.MinTemperature = information.Temperature.Min;
            entity.MaxTemperature = information.Temperature.Max;
            if (information.Picture == null)
            {
                return;
            }
            entity.Image = information.Picture;
            entity.PictureContentType = information.PictureContentType;
        }

        private async Task SetIngredients(Beer beer, string[] ingredients)
        {
            foreach (var ingredientName in ingredients)
            {
                var ingredient = await FindOrCreate(ingredientName.ToLower());
                beer.Ingredients.Add(ingredient);
            }
        }

        private async Task<Ingredient> FindOrCreate(string name)
        {
            var ingredient = await _Session.QueryOver<Ingredient>().Where(ing => ing.Name == name).SingleOrDefaultAsync();
            return ingredient ?? new Ingredient() { Name = name };
        }

        private static Beer Convert(BeerInformation information)
        {
            return new Beer
            {
                Name = information.Name,
                AlcoholPercentage = information.AlcoholPercentage,
                Color = information.Color,
                Description = information.Description,
                Harmonization = information.Harmonization,
                MinTemperature = information.Temperature.Min,
                MaxTemperature = information.Temperature.Max,
                Image = information.Picture,
                PictureContentType = information.PictureContentType
            };
        }
    }
}
