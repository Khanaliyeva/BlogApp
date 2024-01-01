using AutoMapper;
using BlogApp.Business.DTOs;
using BlogApp.Business.Exceptions.User;
using BlogApp.Business.ExternalServices.Interfaces;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace BlogApp.Business.Services.Implimentations
{
    public class UserService : IUserService
    {
        private readonly UserManager<Account> _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public UserService
            (UserManager<Account> userManager,
            IMapper mapper,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<TokenResponseDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserNameOrEmail) ?? await _userManager.FindByEmailAsync(loginDto.UserNameOrEmail);
            if (user == null) throw new UserNotFoundException();
            if(await _userManager.CheckPasswordAsync(user,loginDto.Password)) throw new UserNotFoundException();

            return _tokenService.CreateToken(user, 60);
            
        }

        public async Task Register(AppUserDto registerDto)
        {
            Account user=_mapper.Map<Account>(registerDto);
            var result=await _userManager.CreateAsync(user,registerDto.Password);
        }


    }
}
