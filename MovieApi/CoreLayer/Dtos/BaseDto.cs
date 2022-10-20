using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dtos
{
    public class BaseDto<TKey>
    {
        public TKey Id { get; set; }
    }
}
