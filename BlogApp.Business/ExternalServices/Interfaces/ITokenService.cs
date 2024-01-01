using BlogApp.Business.DTOs;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.ExternalServices.Interfaces
{
    public interface ITokenService
    {
        TokenResponseDto CreateToken(Account user, int expireDate);
    }
}
