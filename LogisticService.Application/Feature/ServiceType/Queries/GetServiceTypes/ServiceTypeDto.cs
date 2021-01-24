using AutoMapper;
using LogisticService.Application.Common.Mappings;

namespace LogisticService.Application.Feature.ServiceType.Queries.GetServiceTypes
{
    public class ServiceTypeDto : IMapFrom<Core.Entities.ServiceType>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Core.Entities.ServiceType, ServiceTypeDto>();
        }
    }
}