using Restaurant.Integration.Domain.Entities;
using System.Reflection;

namespace Restaurant.Services.ProductAPI.Mapper
{
    public static class MapFunc
    {
        public static IHttpContextAccessor _accessor { get; private set; }
        public static void InitializeHttpContextAccessor(IServiceProvider serviceProvider)
        {
            _accessor = serviceProvider.GetService<IHttpContextAccessor>();
        }

        public static Func<object, object, MemberInfo, string> ReturnPropertyLanguageDynamic = ReturnPropertyDynamic;
        private static string ReturnPropertyDynamic(object entity, object vm, MemberInfo destinationProperty)
        {
            if ((Integration.Domain.Enums.SystemLanguage)_accessor.HttpContext.Items["language"] == Integration.Domain.Enums.SystemLanguage.en_EN)
                return entity.GetType().GetProperty(destinationProperty.Name + "_EN")?.GetValue(entity)?.ToString() ?? ""; // return default

            string destionationPropertyName = destinationProperty.Name.ToUpper();

            PropertyInfo[] properties = entity.GetType().GetProperties();

            var propertyNames = properties.Select(x => x.Name).ToArray();

            if (!propertyNames.Any())
                return "";

            var sourcePropertyName = propertyNames.FirstOrDefault(x => x.ToUpper() == $"{destionationPropertyName}_TR" || x.ToUpper() == $"{destionationPropertyName}TR");

            if (sourcePropertyName is null)
                return entity.GetType().GetProperty(destinationProperty.Name + "_EN")?.GetValue(entity)?.ToString() ?? ""; // return default

            PropertyInfo? sourceProperty = entity.GetType().GetProperty(sourcePropertyName);

            if (sourceProperty is null)
                return entity.GetType().GetProperty(destinationProperty.Name + "_EN")?.GetValue(entity)?.ToString() ?? ""; // return default

            return sourceProperty.GetValue(entity)?.ToString() ?? "";

        }
       


    }

}
