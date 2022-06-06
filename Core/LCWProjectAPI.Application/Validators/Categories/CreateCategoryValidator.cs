using FluentValidation;
using LCWProjectAPI.Application.ViewModels.Category;

namespace LCWProjectAPI.Application.Validators.Categories
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryVM>
    {
        public CreateCategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("İsim kısmı boş olamaz");    
            RuleFor(c => c.Name).MinimumLength(2).WithMessage("İsim kısmı en az 2 karakter olmalı");    
            RuleFor(c => c.Name).MaximumLength(30).WithMessage("İsim kısmı en fazla 30 karakter olmalı");    
        }
    }
}
