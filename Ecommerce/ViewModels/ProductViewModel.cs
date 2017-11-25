using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Ecommerce.ViewModels.Validations;

namespace Ecommerce.ViewModels
{
    public class ProductViewModel : IValidatableObject
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new ProductViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}
