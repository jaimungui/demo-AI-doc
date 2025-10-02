using AutoMapper;
using Simulation.SimulationHub.Attribute.Dtos;

namespace Simulation.SimulationHub.Attribute;

public class AttributeMapper : Profile
{
    public AttributeMapper()
    {
        CreateMap<GetAttributeValuesRequest, GetAttributeValuesCmd>();
        CreateMap<AttributeInfoResponse, AttributeInfoDto>();
        CreateMap<CategoryResponse, AttributeMetadataDto>();
        CreateMap<ElementTypeCategoriesResponse, ElementTypeCategoriesDto>();
        CreateMap<AttributeResponse, AttributeDto>();
        CreateMap<GetAttributeDateRangeCmdResponse, DateRangeDto>();
    }
}
