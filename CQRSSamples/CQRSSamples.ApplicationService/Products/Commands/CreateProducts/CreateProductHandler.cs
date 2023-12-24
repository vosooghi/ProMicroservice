using CQRSSamples.ApplicationService.Products.Commands.AddDiscounts;
using CQRSSamples.Domain.Products;
using CQRSSamples.Domain.Products.Entities;
using CQRSSamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSSamples.ApplicationService.Products.Commands.CreateProducts
{
    public class CreateProductHandler : ICommandHandler<CreateProdcut>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task Handle(CreateProdcut command)
        {
            var product = new Product(command.Title
               , command.Description, command.Price, command.CategoryId);
            _productRepository.Add(product);
            await _productRepository.SaveChangesAsync();
        }
    }
}
