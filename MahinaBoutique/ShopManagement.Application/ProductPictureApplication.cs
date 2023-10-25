using _0_SelfBuildFramwork.Application;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IProductPictureRepository _pictureRepository;
        private readonly IProductRepository _productRepository;

        public ProductPictureApplication(IProductPictureRepository pictureRepository, IFileUploader fileUploader, IProductRepository productRepository)
        {
            _pictureRepository = pictureRepository;
            _fileUploader = fileUploader;
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var operation = new OperationResult();
            
            var product = _productRepository.GetWithCategory(command.ProductId);
            var folder = $"{product.Category.Slug}/{product.Slug}";
            var Image = _fileUploader.Upload(command.Picture,folder);

            var productPicture = new ProductPicture(Image,command.PictureAlt,command.PictureTitle,command.ProductId);
            _pictureRepository.Create(productPicture);
            _pictureRepository.SaveChanges();
            return operation.Succedded();


        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operation = new OperationResult();
            var selectedProductPic = _pictureRepository.GetWithCategory(command.Id);
            if(selectedProductPic == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            }
            
            var ImageFolder = $"{selectedProductPic.Product.Category.Slug}/{selectedProductPic.Product.Slug}";
            var Image = _fileUploader.Upload(command.Picture,ImageFolder);

            selectedProductPic.Edit(Image,command.PictureAlt,command.PictureTitle,command.ProductId);
            _pictureRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditProductPicture GetDetails(long id)
        {
            return _pictureRepository.GetDetails(id);
        }


        public OperationResult Remove(long id)
        {
          var operation = new OperationResult();
            var selectedProductPic = _pictureRepository.GetBy(id);
            if(selectedProductPic == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            } 
            selectedProductPic.Remove();
            _pictureRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Restore(long id)
        {
             var operation = new OperationResult();
            var selectedProductPic = _pictureRepository.GetBy(id);
            if(selectedProductPic == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            } 
            selectedProductPic.Restore();
            _pictureRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchmodel)
        {
            return _pictureRepository.Search(searchmodel);
        }
    }
}
