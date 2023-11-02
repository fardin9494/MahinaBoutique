using _0_SelfBuildFramwork.Application;
using ShopManagement.Application.Contract.Slide;
using ShopManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;
        private readonly IFileUploader _fileUploader;

        public SlideApplication(ISlideRepository slideRepository, IFileUploader fileUploader)
        {
            _slideRepository = slideRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateSlide command)
        {
            var operation = new OperationResult();

            var folder = $"Slides/{command.Title}";
            var Picture = _fileUploader.Upload(command.Picture,folder,BaseFolderForUpload.Product);

            var slide = new Slide(Picture,command.PictureAlt,command.PictureTitle,command.Heading,command.Title,command.Text,command.ButtonText,command.Link);
            _slideRepository.Create(slide);
            _slideRepository.SaveChanges();
            return operation.Succedded();

        }

        public OperationResult Edit(EditSlide command)
        {
            var operation = new OperationResult();
            var SelSlide = _slideRepository.GetBy(command.Id);
            if(SelSlide == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            }

            var folder = $"Slides/{command.Title}";
            var Picture = _fileUploader.Upload(command.Picture,folder,BaseFolderForUpload.Product);
            SelSlide.Edit(Picture,command.PictureAlt,command.PictureTitle,command.Heading,command.Title,command.Text,command.ButtonText,command.Link);
            _slideRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditSlide GetDetails(long id)
        {
            return _slideRepository.GetDetails(id);
        }

        public List<SlideViewModel> GetList()
        {
            return _slideRepository.GetList();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var SelSlide = _slideRepository.GetBy(id);
            if(SelSlide == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            }

            SelSlide.Remove();
            _slideRepository.SaveChanges();
            return operation.Succedded();

        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var SelSlide = _slideRepository.GetBy(id);
            if(SelSlide == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            }

            SelSlide.Restore();
            _slideRepository.SaveChanges();
            return operation.Succedded();
           
        }
    }
}
