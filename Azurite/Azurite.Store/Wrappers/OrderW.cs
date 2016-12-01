﻿using AutoMapper;
using Azurite.Infrastructure.Mapping.Contracts;
using Azurite.Store.Common;
using Azurite.Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Azurite.Store.Wrappers
{
    public class OrderW : IMap, IMapFrom<Order>, IHaveCustomMappings
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public Guid CustomerId { get; set; }
        public int StatusId { get; set; }

        [LocalizedDisplayName("Total", NameResourceType = typeof(Customer))]
        public double Total { get; set; }

        [LocalizedDisplayName("Comment", NameResourceType = typeof(Customer))]
        public string Comment { get; set; }

        public DateTime Date { get; set; }

        public virtual CustomerW Customer { get; set; }
        public virtual ICollection<OrderedProductW> OrderedProducts { get; set; }

        public OrderW()
        {
            this.OrderedProducts = new HashSet<OrderedProductW>();
        }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Order, OrderW>()
                .ReverseMap()
                .ForMember(d => d.Date, conf => conf.MapFrom(s => s.Date.ToUniversalTime()));
        }
    }
}