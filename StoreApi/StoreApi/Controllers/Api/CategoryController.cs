using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApi.Data;
using StoreApi.DTOs;
using StoreApi.Models;

namespace StoreApi.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly StoreContext _storeContext;
        private readonly IMapper _mapper;

        public CategoryController(StoreContext storeContext, IMapper mapper)
        {
            _mapper = mapper;
            _storeContext = storeContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await _storeContext.Categories.ToListAsync();
            var dto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return Ok(dto);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {

            var category = await _storeContext.Categories.Where(x => x.Id == id).SingleOrDefaultAsync();
            var dto = _mapper.Map<CategoryDto>(category);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory([FromBody] CategoryDto dto)
        {

            var caregory = _mapper.Map<Category>(dto);

            _storeContext.Categories.Add(caregory);
            await _storeContext.SaveChangesAsync();
            return Ok(caregory);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(CategoryDto dto, int id)
        {

            var categoryInDb = await _storeContext.Categories.Where(x => x.Id == id).FirstAsync();
            if (categoryInDb == null) return NotFound("Category not found");

            categoryInDb.CategoryName = dto.CategoryName;
            categoryInDb.CategoryCode = dto.CategoryCode;


            await _storeContext.SaveChangesAsync();

            return Ok(dto);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {

            var caregoryInDb = await _storeContext.Categories.Where(x => x.Id == id).FirstAsync();
            if (caregoryInDb == null) return NotFound(caregoryInDb);

            _storeContext.Categories.Remove(caregoryInDb);
            await _storeContext.SaveChangesAsync();
            var dto = _mapper.Map<CategoryDto>(caregoryInDb);
            return Ok(dto);

        }



    }
}
