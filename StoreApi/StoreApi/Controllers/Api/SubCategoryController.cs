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
    public class SubCategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly StoreContext _storeContext;

        public SubCategoryController(IMapper mapper, StoreContext storeContext)
        {
            _mapper = mapper;
            _storeContext = storeContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategoryDto>>> GetSubCategories()
        {

            var subCategories = await _storeContext.SubCategories.ToListAsync();
            if (subCategories == null) return BadRequest();
            //var dto = _mapper.Map<IEnumerable<SubCategoryDto>>(subCategories);
            var dto = await (from sub in _storeContext.SubCategories
                             join cat in _storeContext.Categories on sub.CategoryId equals cat.Id
                             select new SubCategoryDto { Id = sub.Id, SubCategoryName = sub.SubCategoryName, CategoryName = cat.CategoryName }).ToListAsync();
            return Ok(dto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubCategory(int id)
        {

            var subCategory = await _storeContext.SubCategories.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (subCategory == null) return NotFound();
            var dto = _mapper.Map<SubCategoryDto>(subCategory);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> PostSubCategory([FromBody] SubCategoryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var entity = _mapper.Map<SubCategory>(dto);

                _storeContext.SubCategories.Add(entity);
                await _storeContext.SaveChangesAsync();

                return Ok("SubCategory created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        //--
    }
}
