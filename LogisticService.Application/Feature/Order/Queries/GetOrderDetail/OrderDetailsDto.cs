using AutoMapper;
using LogisticService.Application.Common.Mappings;
using LogisticService.Core.Entities;

namespace LogisticService.Application.Feature.Order.Queries.GetOrderDetail
{
    public class OrderDetailsDto : IMapFrom<OrderStructure>
    {
        public int Id { get; set; }

        public int Count { get; set; }
        
        public string Product { get; set; }

        public int OrderId { get; set; }

        public int UnitId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderStructure, OrderDetailsDto>();
        }
    }
}