using AutoMapper;

namespace LibrarySystem.Web.Infrastructure.Contracts
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}