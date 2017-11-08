using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Ecommerce.Api.Core;
using Ecommerce.Api.ViewModels;
using Ecommerce.Data.Abstract;
using Ecommerce.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        private int _page = 1;
        private int _pageSize = 10;
        public ProductController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public IActionResult Get()
        {
            var pagination = Request.Headers["Pagination"];

            if (!string.IsNullOrEmpty(pagination))
            {
                var vals = pagination.ToString().Split(',');
                int.TryParse(vals[0], out _page);
                int.TryParse(vals[1], out _pageSize);
            }

            var currentPage = _page;
            var currentPageSize = _pageSize;
            var totalUsers = _categoryRepository.Count();
            var totalPages = (int)Math.Ceiling((double)totalUsers / _pageSize);

            var products = _productRepository
                .AllIncluding()
                .OrderBy(u => u.Id)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();

            var productVm = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);

            Response.AddPagination(_page, _pageSize, totalUsers, totalPages);

            return new OkObjectResult(productVm);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult Get(int id)
        {
            var objProduct = _productRepository.GetSingle(u => u.Id == id);

            if (objProduct == null) return NotFound();

            var objProductViewModel = Mapper.Map<Product, ProductViewModel>(objProduct);
            return new OkObjectResult(objProductViewModel);
        }

        [HttpPost]
        public IActionResult Create([FromBody]ProductViewModel product)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newProduct = new Product
            {
                Name = product.Name,
                CategoryId = product.CategoryId,
                Color = product.Color,
                Description = product.Description,
                Size = product.Size
            };
            _productRepository.Add(newProduct);
            _productRepository.Commit();

            product = Mapper.Map<Product, ProductViewModel>(newProduct);
            return new OkObjectResult(product);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oldProduct = _productRepository.GetSingle(id);

            if (oldProduct == null)
                return NotFound();

            oldProduct.Name = product.Name;
            oldProduct.CategoryId = product.CategoryId;
            oldProduct.Color = product.Color;
            oldProduct.Description = product.Description;
            oldProduct.Size = product.Size;

            _productRepository.Commit();

            product = Mapper.Map<Product, ProductViewModel>(oldProduct);

            return new OkObjectResult(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objProduct = _productRepository.GetSingle(id);

            if (objProduct == null)
                return new NotFoundResult();

            _categoryRepository.DeleteWhere(a => a.Id == objProduct.CategoryId);

            _productRepository.Delete(objProduct);
            _productRepository.Commit();
            return new NoContentResult();
        }
    }
}