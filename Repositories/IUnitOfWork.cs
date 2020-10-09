using ImageAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageAPI.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ImageGalleryContext _context;

        public UnitOfWork(ImageGalleryContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
