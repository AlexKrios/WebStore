﻿using System;
using System.Linq.Expressions;
using LinqSpecs;

namespace WebStoreAPI.Specifications.OrderItems
{
    public class OrderItemsMinPriceSpecification : Specification<DataLibrary.Entities.OrderItem>
    {
        private readonly decimal? _price;

        public OrderItemsMinPriceSpecification(decimal? price)
        {
            _price = price;
        }

        public override Expression<Func<DataLibrary.Entities.OrderItem, bool>> ToExpression()
        {
            return _price.HasValue 
                ? x => x.Price >= _price
                : (Expression<Func<DataLibrary.Entities.OrderItem, bool>>)(x => true);
        }
    }
}