using AutoMapper;
using BlogApp.Business.DTOs;
using BlogApp.Business.Exceptions.User;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BlogApp.Business.Services.Implimentations
{
    public class UserService : IUserService
    {
        private readonly UserManager<Account> _userManager;
        private readonly IMapper _mapper;


        public UserService(UserManager<Account> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        //public Task<string> LoginAsync(LoginDto loginDto)
        //{
        //    var user = _userManager.FindByNameAsync(loginDto.UserNameOrEmail);
        //    if (user == null) throw new UserNotFoundException();

        //}

        public async Task Register(AppUserDto registerDto)
        {
            Account user=_mapper.Map<Account>(registerDto);
            var result=await _userManager.CreateAsync(user,registerDto.Password);
        }


    }
}
