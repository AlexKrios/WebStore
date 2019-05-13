﻿using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Products
{
    public class ProductMaxAvailabilitySpecification : Specification<Product>
    {
        private readonly int? _availability;

        public ProductMaxAvailabilitySpecification(int? availability)
        {
            _availability = availability;
        }

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return !_availability.HasValue
                ? (Expression<Func<Product, bool>>) (x => true)
                : x => x.Availability <= _availability;
        }
    }
}
