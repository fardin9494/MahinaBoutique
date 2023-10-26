using _0_Framework.Application;
using _0_SelfBuildFramwork.Application;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository, IFileUploader fileUploader)
        {
            _productCategoryRepository = productCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreatePoductCategory command)
        {
            var operation = new OperationResult();

           if(_productCategoryRepository.IsExist(x => x.Name == command.Name))
            {
               return operation.Failed(ApplicationMessages.DupplicatedMessage);
            }
            
            var Slug = command.Slug.Slugify();
            var folder = $"{command.Slug}";
            var fileName = _fileUploader.Upload(command.Image,folder,true);

            var category = new ProductCategory(command.Name,command.Description,
                fileName,command.ImageAlt,command.ImageTitle,command.Keyword
                ,command.MetaDescription,Slug);
            _productCategoryRepository.Create(category);
            _productCategoryRepository.SaveChanges();
            return operation.Succedded();
         
        }

        public OperationResult Edit(EditProductCategory command)
        {
            var product = _productCategoryRepository.GetBy(command.Id);
            var operation = new OperationResult();
            if(product == null)
            {
                operation.Failed(ApplicationMessages.NullRecordMessage);
            }

            if(_productCategoryRepository.IsExist(x => x.Name == command.Name && x.Id != command.Id))
            {
                operation.Failed(ApplicationMessages.DupplicatedMessage);
            }

            var slug = command.Slug.Slugify();
            var folder = $"{command.Slug}";
            var fileName = _fileUploader.Upload(command.Image,folder,true);

            product.Edit(command.Name,command.Description,fileName,
                command.ImageAlt,command.ImageTitle,command.Keyword,
                command.MetaDescription,slug);
            _productCategoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditProductCategory GetDetails(int id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> GetList()
        {
            return _productCategoryRepository.GetList();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel search)
        {
           return _productCategoryRepository.Search(search);
        }
    }
}
