using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Threading.Tasks;
using BeerAPI.Services.DTO;

namespace BeerAPI.Infra
{
    public class RangeModelBinder : IModelBinderProvider, IModelBinder
    {
        private static readonly Type _Type = typeof(Range);

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var modelName = bindingContext.ModelName;
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            var range = JsonConvert.DeserializeObject<Range>(valueProviderResult.FirstValue);
            bindingContext.Result = ModelBindingResult.Success(range);
            return Task.CompletedTask;
        }

        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            var metadata = context.Metadata;
            if (!metadata.IsComplexType)
            {
                return null;
            }

            var propertyName = metadata.PropertyName;
            if (propertyName == null)
            {
                return null;
            }

            var propInfo = metadata.ContainerType.GetProperty(propertyName);
            var propertyType = propInfo?.PropertyType;
            return propertyType == _Type ? this : null;
        }
    }
}
