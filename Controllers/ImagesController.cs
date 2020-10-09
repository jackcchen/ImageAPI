using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageAPI.Extension;
using ImageAPI.Model;
using ImageAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _ImageSvc;

        public ImagesController(IImageService ImageSvc)
        {
            _ImageSvc = ImageSvc;
        }

        // GET: api/Images
        [HttpGet]
        public async Task<IEnumerable<ImageDetail>> Get()
        {
            var images = await _ImageSvc.ListAsync();
            return images;
        }

        // GET: api/Image/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST: api/Image
        [HttpPost]
        public void Post([FromBody] SavedImageDetail _ImageDetail)
        {
            ImageDetail objImage = new ImageDetail();
            objImage.Title = _ImageDetail.Title;
            objImage.Description = _ImageDetail.Description;
            objImage.ImagePath = _ImageDetail.ImagePath;

            _ImageSvc.SaveAsync(objImage);

    }

    // PUT: api/Image/5
    [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
