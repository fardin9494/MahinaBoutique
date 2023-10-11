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
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreatePoductCategory command)
        {
            var operation = new OperationResult();

           if(_productCategoryRepository.IsExist(x => x.Name == command.Name))
            {
               return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد");
            }
            
            var Slug = command.Slug.Slugify();
            var category = new ProductCategory(command.Name,command.Description,
                command.Image,command.ImageAlt,command.ImageTitle,command.Keyword
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
                operation.Failed("رکورد انتخابی یافت نشد");
            }

            if(_productCategoryRepository.IsExist(x => x.Name == command.Name && x.Id != command.Id))
            {
                operation.Failed("امکان ثبت رکورد تکراری وجود ندارد");
            }

            var slug = command.Slug.Slugify();
            product.Edit(command.Name,command.Description,command.Image,
                command.ImageAlt,command.ImageTitle,command.Keyword,
                command.MetaDescription,slug);
            _productCategoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditProductCategory GetDetails(int id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel search)
        {
           return _productCategoryRepository.Search(search);
        }
    }
}
