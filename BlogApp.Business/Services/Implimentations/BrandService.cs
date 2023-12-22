using BlogApp.Business.DTOs.BrandDtos;
using BlogApp.Business.Exceptions.Brand;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Implimentations
{
    public class BrandService:IBrandService
    {
        private readonly IBrandRepository _repo;

        public BrandService(IBrandRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> CreateBrandAsync(CreateBrandDto brandDto)
        {
            if (brandDto == null) throw new BrandExceptionNull();
            Brand brand = new Brand()
            {
                Name = brandDto.Name,
                IsDeleted = false
            };
            await _repo.Create(brand);
            int result = await _repo.SaveChangesAsync();
            if(result>0) { return true; }
            return false;
        }

        public async Task<ICollection<Brand>> GetAllAsync()
        {
           var brand=await _repo.GetAllAsync();
            return await brand.ToListAsync();
        }
        
    }
}
