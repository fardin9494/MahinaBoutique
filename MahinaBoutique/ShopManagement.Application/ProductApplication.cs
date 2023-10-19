using _0_Framework.Application;
using _0_SelfBuildFramwork.Application;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();
            if(_productRepository.IsExist(x => x.Name == command.Name))
            {
                return operation.Failed(ApplicationMessages.DupplicatedMessage);
            }
            var slug = GenerateSlug.Slugify(command.Slug);
            var product = new Product(command.Name,command.Code,
                                        command.Picture,command.PictureTitle,
                                        command.PictureAlt,command.ShortDescription,command.Description,
                                        command.MetaDescription,command.Keywords,slug,command.CategoryId);

            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            if(_productRepository.GetBy(command.Id) == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            }
            if(_productRepository.IsExist(x => x.Name == command.Name && x.Id != command.Id))
            {
                return operation.Failed(ApplicationMessages.DupplicatedMessage);
            }
            var product = _productRepository.GetBy(command.Id);
            var slug = GenerateSlug.Slugify(command.Slug);
            product.Edit(command.Name, command.Code,
                                command.Picture,command.PictureTitle,
                                command.PictureAlt,command.ShortDescription,command.Description,
                                command.MetaDescription,command.Keywords,slug,command.CategoryId);
            _productRepository.SaveChanges();
            return operation.Succedded();
            
        }

        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetProducts();
        }


        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _productRepository.Search(searchModel);
        }
    }
}
