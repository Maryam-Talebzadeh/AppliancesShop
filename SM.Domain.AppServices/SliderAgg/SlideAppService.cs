using Base_Framework.Domain.Services;
using SM.Domain.Core.SliderAgg.AppServices;
using SM.Domain.Core.SliderAgg.DTOs;
using SM.Domain.Core.SliderAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.AppServices.SliderAgg
{
    public class SlideAppService : ISlideAppService
    {
        private readonly ISlideService _slideService;
        private readonly ISlidePictureService _slidePictureService;

        public SlideAppService(ISlideService slideService, ISlidePictureService slidePictureService)
        {
            _slideService = slideService;
            _slidePictureService = slidePictureService;
        }

        public OperationResult Create(CreateSlideViewModel command)
        {
            var slidePicture = new CreateSlidePictureDTO()
            {
                Alt= command.PictureAlt,
                Picture = command.Picture,
                Title = command.Title
            };

           var picId = _slidePictureService.Create(slidePicture);

            var slide = new CreateSlideDTO()
            {
                Heading= command.Heading,
                BtnText = command.BtnText,
                Link = command.Link,
                Text = command.Text,
                Title = command.Title,
                PictureId = picId
            };

            return _slideService.Create(slide);

        }

        public OperationResult Edit(EditSlideViewModel command)
        {
            var slidePicture = new EditSlidePictureDTO()
            {
                Id = command.PictureId,
                Alt = command.PictureAlt,
                Picture = command.Picture,
                Title = command.Title
            };

             _slidePictureService.Edit(slidePicture);

            var slide = new EditSlideDTO()
            {
                Id = command.Id,
                Heading = command.Heading,
                BtnText = command.BtnText,
                Link = command.Link,
                Text = command.Text,
                Title = command.Title,
                PictureId = command.PictureId               
            };

            return _slideService.Edit(slide);

        }

        public EditSlideViewModel GetDetails(long id)
        {
            return _slideService.GetDetails(id);
        }

        public List<SlideViewModel> GetList()
        {
            return _slideService.GetList();
        }

        public OperationResult Remove(long id)
        {
            return _slideService.Remove(id);
        }

        public OperationResult Restore(long id)
        {
            return _slideService.Restore(id);
        }
    }
}
