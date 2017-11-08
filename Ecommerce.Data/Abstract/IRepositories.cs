
using Ecommerce.Model.Entities;

namespace Ecommerce.Data.Abstract
{
    public interface ICategoryRepository : IEntityBaseRepository<Category> { }

    public interface IProductRepository : IEntityBaseRepository<Product> { }
}
