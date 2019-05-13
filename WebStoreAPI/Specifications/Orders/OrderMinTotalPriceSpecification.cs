﻿using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Orders
{
    public class OrderMinTotalPriceSpecification : Specification<Order>
    {
        private readonly decimal? _totalPrice;

        public OrderMinTotalPriceSpecification(decimal? totalPrice)
        {
            _totalPrice = totalPrice;
        }

        public override Expression<Func<Order, bool>> ToExpression()
        {
            return !_totalPrice.HasValue
                ? (Expression<Func<Order, bool>>) (x => true)
                : x => x.TotalPrice <= _totalPrice;
        }
    }
}
