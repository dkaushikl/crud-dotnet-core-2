using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Ecommerce.ViewModels.Validations;

namespace Ecommerce.ViewModels
{
    public class CategoryViewModel : IValidatableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sequence { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new CategoryViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}
