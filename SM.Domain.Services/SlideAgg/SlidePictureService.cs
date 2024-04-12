using Base_Framework.Domain.Services;
using SM.Domain.Core.SliderAgg.Data;
using SM.Domain.Core.SliderAgg.DTOs;
using SM.Domain.Core.SliderAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Services.SlideAgg
{
    public class SlidePictureService : ISlidePictureService
    {
        private readonly ISlidePictureRepository _slidePictureRepository;

        public SlidePictureService(ISlidePictureRepository slidePictureRepository)
        {
            _slidePictureRepository = slidePictureRepository;
        }

        public long Create(CreateSlidePictureDTO command)
        {

            #region Save picture

            string picName = NameGenarator.GenerateUniqeCode() + Path.GetExtension(command.Picture.FileName);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "AdminTheme", "SlidePictures", picName);
            FileHandler.SaveImage(path, command.Picture);

            #endregion

            return _slidePictureRepository.Create(command);
        }




        public void Edit(EditSlidePictureDTO command)
        {
            if (command.Picture != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "AdminTheme", "SlidePictures");

                #region Delete Old Image

                string oldPicName = _slidePictureRepository.GetBy(command.Id).Name;

                if (command.Name != oldPicName)
                {
                    FileHandler.DeleteFile(Path.Combine(path, oldPicName));
                }

                #endregion

                #region Save picture

                command.Name = NameGenarator.GenerateUniqeCode() + Path.GetExtension(command.Picture.FileName);
                path = Path.Combine(path, command.Name);
                FileHandler.SaveImage(path, command.Picture);

                #endregion
            }

            _slidePictureRepository.Edit(command);
            _slidePictureRepository.Save();
        }
    }
}
