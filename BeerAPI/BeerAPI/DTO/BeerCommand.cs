using BeerAPI.Services.DTO;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace BeerAPI.DTO
{
    public class BeerCommand
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Harmonization { get; set; }

        [Required]
        public int Color { get; set; }

        [Required]
        public decimal AlcoholPercentage { get; set; }

        [Required]
        public Range Temperature { get; set; }

        [Required]
        public string[] Ingredients { get; set; }

        public IFormFile Picture { get; set; }

        public BeerInformation Transform()
        {
            var data = GetPictureData();
            return new BeerInformation(Name, Description, Harmonization, Color, AlcoholPercentage, Temperature, Ingredients, data, Picture?.ContentType);
        }

        private byte[] GetPictureData()
        {
            if (Picture == null)
            {
                return null;
            }

            using (var stream = Picture.OpenReadStream())
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
