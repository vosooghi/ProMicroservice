using CQRSSamples.ApplicationService.Products.Commands.AddDiscounts;
using CQRSSamples.ApplicationService.Products.Commands.CreateProducts;
using CQRSSamples.Domain.Products;
using CQRSSamples.Domain.Products.Entities;

namespace CQRSSamples.ApplicationService.Products
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(CreateProdcut createProdcut)
        {
            var product = new Product(createProdcut.Title
               , createProdcut.Description, createProdcut.Price, createProdcut.CategoryId);
            _productRepository.Add(product);
            await _productRepository.SaveChangesAsync();
        }
        public async Task Handle(AddDiscount addDiscount)
        {
            var p = _productRepository.Get(addDiscount.Id);
            p.AddDiscount(addDiscount.Title,addDiscount.Value);

            await _productRepository.SaveChangesAsync();

        }
    }
}

