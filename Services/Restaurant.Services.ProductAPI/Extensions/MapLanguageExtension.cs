using AutoMapper;
using Restaurant.Services.ProductAPI.Mapper;
using System.Reflection;

namespace Restaurant.Services.ProductAPI.Extensions
{
    public static class MapLanguageExtension
    {
        public static void MapFromLanguage<TSource, TDestination, TMember>(this IMemberConfigurationExpression<TSource, TDestination, TMember> opt, MemberInfo memberInfo)
        {
            opt.MapFrom((s, d) =>
            {
                return MapFunc.ReturnPropertyLanguageDynamic(s, d, memberInfo);
            });
        }
    }
}
