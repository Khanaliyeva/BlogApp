using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs
{
    public class AppUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
    public class AccountRegisterDtoValidator : AbstractValidator<AppUserDto>
    {
        public AccountRegisterDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(25)
                .WithMessage("Name cannot be longer than 25 characters");
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname is required")
                .MaximumLength(45)
                .WithMessage("Surname cannot be longer than 45 characters");
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required")
                .MaximumLength(60)
                .WithMessage("Username cannot be longer than 60 characters");
            RuleFor(x => x.Email)
                .EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password Bos olmaz")
                .Must(p =>
                {
                    Regex regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
                    Match match = regex.Match(p);
                    return match.Success;
                });
            RuleFor(x => x)
                .Must(c => c.Password == c.ConfirmPassword);
        }
    }
}
