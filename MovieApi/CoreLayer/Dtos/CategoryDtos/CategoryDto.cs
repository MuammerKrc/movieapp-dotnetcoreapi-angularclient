using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Dtos.MovieDtos;

namespace CoreLayer.Dtos.CategoryDtos
{
    public class CategoryDto : BaseDto<int>
    {
        public string Title { get; set; }
        public ICollection<MovieDto> Movies { get; set; }
    }
}
