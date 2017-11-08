using System.Collections.Generic;

namespace Ecommerce.Model.Entities
{
    public class Category : IEntityBase
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Sequence { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
