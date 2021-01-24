﻿using System;
using System.Collections.Generic;
using LogisticService.Core.Entities.Identity;
using LogisticService.Core.Enums;

namespace LogisticService.Core.Entities
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order
    {
        public int Id { get; set; }

        public int Number { get; set; }

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
        public ApplicationUser User { get; set; }

        /// <summary>
        /// Тип услуги
        /// </summary>
        /// <example>Курьерская доставка</example>
        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }
        
        /// <summary>
        /// Состав заказа
        /// </summary>
        public ICollection<OrderStructure> OrderStructures { get; set; }
    }
}