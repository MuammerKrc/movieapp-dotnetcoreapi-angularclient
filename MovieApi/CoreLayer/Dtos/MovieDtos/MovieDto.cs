using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Dtos.CategoryDtos;

namespace CoreLayer.Dtos.MovieDtos
{
    public class MovieDto : BaseDto<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string ImagePath { get; set; }
        public CategoryDto Category { get; set; }
    }
}
