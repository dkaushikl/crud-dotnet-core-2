
namespace Ecommerce.Model.Entities
{
    public class Product : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }

        public int CategoryId { get; set; }
        public Category Categories { get; set; }
    }
}
