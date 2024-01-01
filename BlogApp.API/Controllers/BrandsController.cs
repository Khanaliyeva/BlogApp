using BlogApp.Business.DTOs.BrandDtos;
using BlogApp.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _service;

        public BrandsController(IBrandService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _service.GetAllAsync();
            return StatusCode(StatusCodes.Status200OK,brands);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateBrandDto brandDto)
        {
            bool result=await _service.CreateBrandAsync(brandDto);
            if (result) { return StatusCode(StatusCodes.Status200OK); }
            return StatusCode(StatusCodes.Status409Conflict);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if(id<=0)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            return StatusCode(StatusCodes.Status200OK);

        }

        //[HttpPut]
        //public async Task<IActionResult> UpdateAsync(int id, string name)
        //{
        //    var brand=await _re
        //}
    }
}
