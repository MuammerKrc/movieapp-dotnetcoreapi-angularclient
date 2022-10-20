using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.IRepositories.IBaseRepository;
using CoreLayer.Models.JwtModels;

namespace CoreLayer.IRepositories
{
    public interface IJWTokenRepository : IBaseRepository<JWToken, int>
    {

    }
}
