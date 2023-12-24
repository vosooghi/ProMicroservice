using CQRSSamples.Domain.Products;
using CQRSSamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSSamples.ApplicationService.Products.Commands.AddDiscounts
{
    public class AddDiscountHandler : ICommandHandler<AddDiscount>
    {
        private readonly IProductRepository _productRepository;
        public AddDiscountHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task Handle(AddDiscount command)
        {
            var p = _productRepository.Get(command.Id);
            p.AddDiscount(command.Title, command.Value);

            await _productRepository.SaveChangesAsync();
        }
    }
}
