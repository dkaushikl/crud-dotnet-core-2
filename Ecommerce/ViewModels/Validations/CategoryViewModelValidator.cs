using FluentValidation;

namespace Ecommerce.Api.ViewModels.Validations
{
    public class CategoryViewModelValidator : AbstractValidator<CategoryViewModel>
    {
        public CategoryViewModelValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(user => user.Sequence).NotEmpty().WithMessage("Sequence cannot be empty");
        }
    }
}
