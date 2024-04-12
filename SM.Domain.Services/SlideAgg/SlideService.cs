using Base_Framework.Domain.Services;
using SM.Domain.Core.SliderAgg.Data;
using SM.Domain.Core.SliderAgg.DTOs;
using SM.Domain.Core.SliderAgg.Entities;
using SM.Domain.Core.SliderAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SM.Domain.Services.SlideAgg
{
    public class SlideService : ISlideService
    {
        private readonly ISlideRepository _slideRepository;
        private readonly ISlidePictureRepository _slidePictureRepository;

        public SlideService(ISlideRepository slideRepository, ISlidePictureRepository slidePictureRepository)
        {

            this._slideRepository = slideRepository;
            _slidePictureRepository = slidePictureRepository;
        }

        public OperationResult Create(CreateSlideDTO command)
        {

            var operation = new OperationResult();

            if (_slideRepository.IsExist(pc => pc.Heading == command.Heading))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            _slideRepository.Create(command);
            _slideRepository.Save();

            return operation.Succedded();
        }

        public OperationResult Edit(EditSlideDTO command)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.GetBy(command.Id);

            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_slideRepository.IsExist(pc => pc.Heading== command.Heading && pc.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            _slideRepository.Edit(command);
            _slideRepository.Save();

            return operation.Succedded();
        }

        public SlideDetailViewModel GetDetails(long id)
        {
            var slide = _slideRepository.GetDetail(id);

            return new SlideDetailViewModel()
            {
                Id = slide.Id,
                Heading = slide.Heading,
                Picture =_slidePictureRepository.GetBy(slide.PictureId).Name,
                Title = slide.Title,
                BtnText = slide.BtnText,
                Link = slide.Link,
                Text = slide.Text,
                PictureId = slide.PictureId
            };
        }

        public List<SlideViewModel> GetList()
        {
            return _slideRepository.GetAll().Select(s =>
            new SlideViewModel()
            {
                Id = s.Id,
                Heading = s.Heading,
                Picture = _slidePictureRepository.GetBy(s.PictureId).Name,
                Title = s.Title,
                IsRemoved = s.IsRemoved
            }).ToList();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.GetBy(id);

            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            _slideRepository.Remove(slide.Id);
            _slideRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.GetBy(id);

            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            _slideRepository.Restore(slide.Id);
            _slideRepository.Save();
            return operation.Succedded();
        }
    }
}
