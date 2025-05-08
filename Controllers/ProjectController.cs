using Construction_site.Models;
using Construction_site.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Construction_site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IRepository<Product> _productRepository;

        public ProjectController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.GetAll();
            return Ok(products);
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrjectById(int id)
        {
            var product = await _productRepository.GetById(id);
            return Ok(product);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddProject([FromBody] Product product)
        {
            await _productRepository.Add(product);
            return Ok();
            
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] Product product)
        {
            var existingProduct = await _productRepository.GetById(id);
            if (existingProduct == null) return NotFound();

            existingProduct.Title = product.Title;
            existingProduct.Description = product.Description;
            existingProduct.ImageUrl = product.ImageUrl;
            existingProduct.CreatedAt = product.CreatedAt;

            await _productRepository.Update(existingProduct);
            return Ok(existingProduct);
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await _productRepository.Delete(id);
            return Ok();
        }
    }
}
