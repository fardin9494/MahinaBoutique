﻿using _0_SelfBuildFramwork.Application;
using ShopManagement.Application.Contract.Slide;
using ShopManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;

        public SlideApplication(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }

        public OperationResult Create(CreateSlide command)
        {
            var operation = new OperationResult();

            var slide = new Slide(command.Picture,command.PictureAlt,command.PictureTitle,command.Heading,command.Title,command.Text,command.ButtonText);
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
            SelSlide.Edit(command.Picture,command.PictureAlt,command.PictureTitle,command.Heading,command.Title,command.Text,command.ButtonText);
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