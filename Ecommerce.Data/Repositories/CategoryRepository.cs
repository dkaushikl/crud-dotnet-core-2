using Ecommerce.Data.Abstract;
using Ecommerce.Model.Entities;

namespace Ecommerce.Data.Repositories
{
    public class CategoryRepository : EntityBaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(EcommerceContext context)  : base(context)  { }
    }
}
