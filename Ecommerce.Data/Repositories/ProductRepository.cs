using Ecommerce.Data.Abstract;
using Ecommerce.Model.Entities;

namespace Ecommerce.Data.Repositories
{
    public class ProductRepository : EntityBaseRepository<Product>, IProductRepository
    {
        public ProductRepository(EcommerceContext context) : base(context)
        {
        }
    }
}