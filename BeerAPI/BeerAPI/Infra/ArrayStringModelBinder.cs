using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace BeerAPI.Infra
{
    public class ArrayStringModelBinder: IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var modelName = bindingContext.ModelName;
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            var range = JsonConvert.DeserializeObject<string[]>(valueProviderResult.FirstValue);
            bindingContext.Result = ModelBindingResult.Success(range);
            return Task.CompletedTask;
        }
    }
}
