using BlogApp.Business.DTOs;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BlogApp.Business.Services.Implimentations
{
    public class AccountService : IdentityUser
    {
        private readonly UserManager<Account> _userManager;

        public AccountService(UserManager<Account> userManager)
        {
            _userManager = userManager;
        }
        public async Task Register(AppUserDto registerDto)
        {
            Account user = new Account()
            {
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                Email = registerDto.Email,
                UserName = registerDto.Username
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                throw new ArgumentException($"Unable to register user {registerDto.Username}");
            }
        }


    }
}
