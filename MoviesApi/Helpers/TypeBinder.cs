using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MoviesApi.Helpers
{
    public class TypeBinder<T> : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var propertyName = bindingContext.ModelName;
            var values = bindingContext.ValueProvider.GetValue(propertyName);

            if (values == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            try
            {
                var deserializedValue = JsonConvert.DeserializeObject<T>(values.FirstValue);
                bindingContext.Result = ModelBindingResult.Success(deserializedValue);
            }
            catch
            {
                bindingContext.ModelState.TryAddModelError(propertyName, "Valor inválido para tipo List<int>");
            }

            return Task.CompletedTask;
        }
    }
}
