using ImageAPI.Model;
using ImageAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageAPI.Services
{
    public interface IImageService
    {
        Task<IEnumerable<ImageDetail>> ListAsync();
        Task SaveAsync(ImageDetail imageDetail);
    }

    public class ImageService : IImageService
    {
        private readonly IImageRepository _ImageReposotory;
        private readonly IUnitOfWork _unitOfWork;

        public ImageService(IImageRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this._ImageReposotory = categoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ImageDetail>> ListAsync()
        {
            return await _ImageReposotory.ListAsync();
        }

        public async Task SaveAsync(ImageDetail imageDetail)
        {
            try
            {
                await _ImageReposotory.AddAsync(imageDetail);
                await _unitOfWork.CompleteAsync();

            }
            catch (Exception ex)
            {
                // Do some logging stuff
                throw new Exception("An error occurred while saeving");
            }
        }
    }
}
