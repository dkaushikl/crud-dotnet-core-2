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
    [Route("api/Category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        private int _page = 1;
        private int _pageSize = 10;
        public CategoryController(ICategoryRepository categoryRepository, IProductRepository productRepository)
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

            var categories = _categoryRepository
                .AllIncluding()
                .OrderBy(u => u.Id)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();

            var categoriesVm = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);

            Response.AddPagination(_page, _pageSize, totalUsers, totalPages);

            return new OkObjectResult(categoriesVm);
        }


        [HttpGet("{id}", Name = "GetCategory")]
        public IActionResult Get(int id)
        {
            var objCategory = _categoryRepository.GetSingle(u => u.Id == id);

            if (objCategory == null) return NotFound();

            var objCategoryViewModel = Mapper.Map<Category, CategoryViewModel>(objCategory);
            return new OkObjectResult(objCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Create([FromBody]CategoryViewModel category)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newCategory = new Category { Name = category.Name, Sequence = category.Sequence };
            _categoryRepository.Add(newCategory);
            _categoryRepository.Commit();

            category = Mapper.Map<Category, CategoryViewModel>(newCategory);
            return new OkObjectResult(category);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CategoryViewModel category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oldCategory = _categoryRepository.GetSingle(id);

            if (oldCategory == null)
                return NotFound();

            oldCategory.Name = category.Name;
            oldCategory.Sequence = category.Sequence;
            _categoryRepository.Commit();

            Mapper.Map<Category, CategoryViewModel>(oldCategory);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objCategory = _categoryRepository.GetSingle(id);

            if (objCategory == null)
                return new NotFoundResult();

            var products = _productRepository.FindBy(a => a.CategoryId == id);

            foreach (var objProduct in products)
            {
                _productRepository.Delete(objProduct);
            }

            _categoryRepository.Delete(objCategory);

            _categoryRepository.Commit();

            return new NoContentResult();
        }
    }
}