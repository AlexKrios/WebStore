using System;
using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Products
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
        private readonly Product _product;

        public readonly Func<Product, bool> HasName = x => x.Name != null;
        //public readonly Func<Product, bool> HasName = x => x.Name.Equals(_product.Name);

        public readonly Func<Product, bool> MinAvailability = x => x.Availability > 5;
        public readonly Func<Product, bool> MaxAvailability = x => x.Availability < 5;
        public readonly Func<Product, bool> EqualAvailability = x => x.Availability == 5;

        public readonly Func<Product, bool> MinPrice = x => x.Price > 1000;
        public readonly Func<Product, bool> MaxPrice = x => x.Price < 1000;
        public readonly Func<Product, bool> EqualPrice = x => x.Price == 1000;

        public GetProductsQuery(Product product)
        {
            _product = product;
        }
    }
}