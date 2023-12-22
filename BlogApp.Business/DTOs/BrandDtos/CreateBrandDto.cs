using BlogApp.Business.DTOs.BrandDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.BrandDtos
{
    public record CreateBrandDto
    {
        public string? Name { get; set; }
    }

    public class BrandCreateDtoValidation : AbstractValidator<CreateBrandDto>
    {
        public BrandCreateDtoValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Bos olmaz").MaximumLength(55).WithMessage("55den cox simvol olmaz");


        }
    }
}
