using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CarParts.ModelBuilders
{
    public class ArrayModelBinder : IModelBinder
    {
        /// <summary>
        /// Attempts to bind a model.
        /// </summary>
        /// <param name="bindingContext">The <see cref="T:Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext" />.</param>
        /// <returns>
        /// <para>
        /// A <see cref="T:System.Threading.Tasks.Task" /> which will complete when the model binding process completes.
        /// </para>
        /// <para>
        /// If model binding was successful, the <see cref="P:Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.Result" /> should have
        /// <see cref="P:Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.IsModelSet" /> set to <c>true</c>.
        /// </para>
        /// <para>
        /// A model binder that completes successfully should set <see cref="P:Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.Result" /> to
        /// a value returned from <see cref="M:Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.Success(System.Object)" />.
        /// </para>
        /// </returns>
        public Task BindModelAsync(ModelBindingContext mdc)
        {
            if (!mdc.ModelMetadata.IsEnumerableType)
            {
                mdc.Result = ModelBindingResult.Failed(); 
                return Task.CompletedTask; 
            }

            var providedValue = mdc.ValueProvider
                .GetValue(mdc.ModelName)
                .ToString(); 

            if (string.IsNullOrEmpty(providedValue)) 
            {
                mdc.Result = ModelBindingResult.Success(null); 
                return Task.CompletedTask; 
            }

            var genericType = mdc.ModelType
                .GetTypeInfo()
                .GenericTypeArguments[0];

            var converter = TypeDescriptor.GetConverter(genericType);

            var objectArray = providedValue.Split(new[] { "," }, 
                StringSplitOptions.RemoveEmptyEntries)
                .Select(x => converter.ConvertFromString(x.Trim()))
                .ToArray(); 

            var guidArray = Array.CreateInstance(genericType, objectArray.Length);
            objectArray.CopyTo(guidArray, 0);

            mdc.Model = guidArray;
            mdc.Result = ModelBindingResult.Success(mdc.Model); 

            return Task.CompletedTask;
        }
    }
}
