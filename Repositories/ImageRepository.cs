using ImageAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageAPI.Repositories
{
    public interface IImageRepository
    {
        Task<IEnumerable<ImageDetail>> ListAsync();
        Task AddAsync(ImageDetail imageDetail);
    }

    public abstract class BaseRepository
    {
        protected readonly ImageGalleryContext _context;

        public BaseRepository(ImageGalleryContext context)
        {
            _context = context;
        }
    }

    public class ImageRepository : BaseRepository, IImageRepository
    {
        public ImageRepository(ImageGalleryContext context) : base(context)
        {
        }

        public async Task AddAsync(ImageDetail imageDetail)
        {
            await _context.ImageDetail.AddAsync(imageDetail);
        }

        public async Task<IEnumerable<ImageDetail>> ListAsync()
        {
            return await _context.ImageDetail.ToListAsync();
        }
    }
}
