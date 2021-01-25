﻿using System;
using AutoMapper;
using LogisticService.Application.Common.Mappings;
using LogisticService.Core.Enums;

namespace LogisticService.Application.Feature.Order.Queries.GetOrdersForCourier
{
    public class OrderDto : IMapFrom<Core.Entities.Order>
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public float? TotalCost { get; set; }
        
        /// <summary>
        /// Адресс, откуда надо забрать
        /// </summary>
        public string StartPoint { get; set; }

        /// <summary>
        /// Адресс, куда надо доставить
        /// </summary>
        public string EndPoint { get; set; }

        /// <summary>
        /// Дата, с
        /// </summary>
        public DateTime? DateFrom { get; set; }
        
        /// <summary>
        /// Дата, по
        /// </summary>
        public DateTime? DateTo { get; set; }

        /// <summary>
        /// Фактическая дата завершения заказа
        /// </summary>
        public DateTime? DateFinish { get; set; }

        public StatusEnum Status { get; set; }

        /// <summary>
        /// Заказчик (клиент)
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Тип услуги
        /// </summary>
        /// <example>Курьерская доставка</example>
        public int ServiceTypeId { get; set; }
        
        public int? CourierId { get; set; }

        public string Reason { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Core.Entities.Order,OrderDto>();
        }
    }
}