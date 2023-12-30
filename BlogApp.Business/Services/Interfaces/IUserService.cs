using BlogApp.Business.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task Register(AppUserDto userDto);
        //Task<string> LoginAsync(LoginDto loginDto);

    }
}
