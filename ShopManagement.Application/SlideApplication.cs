﻿using _0_FrameWork.Application;
using ShopManagement.Application.Contract.Slide;
using ShopManagement.Domain.SlideAgg;
using System.Collections.Generic;

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
            var operation=new OperationResult();
            var fileName = _fileUploader.Upload(command.Picture, "slides");
            var slide = new Slide(fileName, command.PictureAlt, command.PictureTitle,
                command.Heading, command.Title, command.Text, command.Link, command.BtnText);
            _slideRepository.Create(slide);
            _slideRepository.SaveChanges();
            return operation.Successed();
        }

        public OperationResult Edit(EditSlide command)
        {
            var operation = new OperationResult();
            var slide=_slideRepository.Get(command.Id);

            if(slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            var fileName = _fileUploader.Upload(command.Picture, "slides");

            slide.Edit(fileName, command.PictureAlt, command.PictureTitle,
                command.Heading, command.Title, command.Text, command.Link, command.BtnText);
            _slideRepository.SaveChanges();
            return operation.Successed();
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
            var operation=new OperationResult();

            var slide=_slideRepository.Get(id);

            if( slide == null)
               return operation.Failed(ApplicationMessages.RecordNotFound);

            slide.Remove();
            _slideRepository.SaveChanges();
            return operation.Successed();

        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();

            var slide = _slideRepository.Get(id);

            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            slide.Restore();
            _slideRepository.SaveChanges();
            return operation.Successed();
        }
    }
}
