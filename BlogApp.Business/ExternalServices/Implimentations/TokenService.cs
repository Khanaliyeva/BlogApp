﻿using BlogApp.Business.DTOs;
using BlogApp.Business.ExternalServices.Interfaces;
using BlogApp.Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.ExternalServices.Implimentations
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        public TokenResponseDto CreateToken(Account user, int expireDate)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.GivenName,user.Name)};


            SymmetricSecurityKey securityKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));


            SigningCredentials credential = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256
                );

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: credential
                );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string token=tokenHandler.WriteToken(jwtSecurityToken);
            return new()
            {
                Token = token,
                ExpireDate = jwtSecurityToken.ValidTo,
                UserName = user.UserName
            };
        }
    }
}
