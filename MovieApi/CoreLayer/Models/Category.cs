using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Models.BaseModels;

namespace CoreLayer.Models
{
    public class Category : BaseModel<int>
    {
        public string Title { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
