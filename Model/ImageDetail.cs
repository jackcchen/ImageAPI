using System;
using System.Collections.Generic;

namespace ImageAPI.Model
{
    public partial class ImageDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
