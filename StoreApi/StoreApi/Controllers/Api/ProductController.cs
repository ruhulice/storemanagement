using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StoreApi.Data;
using StoreApi.DTOs;
using StoreApi.Models;

namespace StoreApi.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly StoreContext _storeContext;
        private readonly IMapper _mapper;

        public ProductController(StoreContext storeContext, IMapper mapper)
        {
            _mapper = mapper;
            _storeContext = storeContext;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {

            var products = await _storeContext.Products.ToListAsync();
            if (products == null) return NotFound(products);
            var dto = _mapper.Map<IEnumerable<ProductDto>>(products);

            return Ok(dto);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getProduct(int id)
        {

            var product = await _storeContext.Products.SingleOrDefaultAsync(x => x.Id == id);
            if (product == null) return NotFound(product);
            var dto = _mapper.Map<ProductDto>(product);
            return Ok(dto);

        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto dto)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var product = _mapper.Map<Product>(dto);

            _storeContext.Products.Add(product);
            try
            {
                await _storeContext.SaveChangesAsync();
                return Ok(product);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 2627)
                {
                    return Conflict("A product with the same name already exists.");
                }
                return StatusCode(500, "An error occurred while saving the product.");
            }


        }
        [HttpGet("getProductbyCategory")]
        public async Task<IActionResult> getProductbyCategory([FromQuery] int categoryId)
        {

            var product = await _storeContext.Products.Where(x => x.SubCategoryId == categoryId).ToListAsync();
            return Ok(product);
        }


        //--
    }
}
