using System;
using System.Linq;
using Ecommerce.Model.Entities;

namespace Ecommerce.Data
{
    public class EcommerceDbInitilizer
    {
        private static EcommerceContext _context;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            _context = (EcommerceContext) serviceProvider.GetService(typeof(EcommerceContext));

            InitializeData();
        }

        private static void InitializeData()
        {
            if (!_context.Categories.Any())
            {
                var objCategory = new Category {Name = "Testing", Sequence = 1};
                _context.Categories.Add(objCategory);
                _context.SaveChanges();
            }

            if (_context.Products.Any()) return;

            var objProduct = new Product
            {
                Name = "Testing",
                CategoryId = 1,
                Color = "Green",
                Description = "Test",
                Size = "10"
            };
            _context.Products.Add(objProduct);
            _context.SaveChanges();
        }
    }
}