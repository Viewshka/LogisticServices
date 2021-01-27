﻿using System;
using LogisticService.Core.Enums;

namespace LogisticService.Application.Feature.Order.Queries.TrackOrder
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public float? TotalCost { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public StatusEnum Status { get; set; }
        
        public int UserId { get; set; }
        public string Username { get; set; }
        
        public int ServiceTypeId { get; set; }
        public string NameServiceType { get; set; }
        
        public int? CourierId { get; set; }
        public string CourierName { get; set; }

        public int Progress { get; set; }
    }
}