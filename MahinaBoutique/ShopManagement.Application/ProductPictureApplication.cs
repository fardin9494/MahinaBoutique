using _0_SelfBuildFramwork.Application;
using ShopManagement.Application.Contract.ProductPicture;
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
        private readonly IProductPictureRepository _pictureRepository;

        public ProductPictureApplication(IProductPictureRepository pictureRepository)
        {
            _pictureRepository = pictureRepository;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var operation = new OperationResult();
            if(_pictureRepository.IsExist(x=> x.Picture == command.Picture && x.ProductId == command.ProductId))
            {
                return operation.Failed(ApplicationMessages.DupplicatedMessage);
            }
            var productPicture = new ProductPicture(command.Picture,command.PictureAlt,command.PictureTitle,command.ProductId);
            _pictureRepository.Create(productPicture);
            _pictureRepository.SaveChanges();
            return operation.Succedded();


        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operation = new OperationResult();
            var selectedProductPic = _pictureRepository.GetBy(command.Id);
            if(selectedProductPic == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            }
            if(_pictureRepository.IsExist(x=> x.Picture == command.Picture && x.ProductId == command.ProductId && x.Id != command.Id))
            {
                 return operation.Failed(ApplicationMessages.DupplicatedMessage);
            }

            selectedProductPic.Edit(command.Picture,command.PictureAlt,command.PictureTitle,command.ProductId);
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
