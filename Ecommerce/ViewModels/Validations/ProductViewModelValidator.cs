using FluentValidation;

namespace Ecommerce.ViewModels.Validations
{
    public class ProductViewModelValidator : AbstractValidator<ProductViewModel>
    {
        public ProductViewModelValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(user => user.CategoryId).NotEmpty().WithMessage("CategoryId cannot be empty");
            RuleFor(user => user.Color).NotEmpty().WithMessage("Color cannot be empty");
            RuleFor(user => user.Description).NotEmpty().WithMessage("Description cannot be empty");
            RuleFor(user => user.Size).NotEmpty().WithMessage("Size cannot be empty");
        }
    }
}
