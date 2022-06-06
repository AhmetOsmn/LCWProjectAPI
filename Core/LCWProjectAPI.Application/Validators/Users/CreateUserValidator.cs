using FluentValidation;
using LCWProjectAPI.Application.ViewModels.Category;

namespace LCWProjectAPI.Application.Validators.Categories
{
    public class CreateUserValidator : AbstractValidator<CreateUserVM>
    {
        public CreateUserValidator()
        {
            RuleFor(c => c.Email).NotEmpty().WithMessage("Email kısmı boş olamaz");    
            RuleFor(c => c.Email).EmailAddress().WithMessage("Geçerli bir email giriniz");    
       

            RuleFor(c => c.Password).NotEmpty().WithMessage("Şifre kısmı boş olamaz");
            RuleFor(c => c.Password).MinimumLength(8).WithMessage("Şifre kısmı en az 8 karakter olmalı");
            RuleFor(c => c.Password).MaximumLength(20).WithMessage("Şifre kısmı en fazla 20 karakter olmalı");
        }
    }
}
