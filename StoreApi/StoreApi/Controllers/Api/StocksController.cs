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
    public class StocksController : ControllerBase
    {
        private readonly StoreContext _storeContext;
        private readonly IMapper _mapper;
        public StocksController(StoreContext storeContext, IMapper mapper)
        {
            _mapper = mapper;
            _storeContext = storeContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockDto>>> getStock()
        {
            var stockdata = await _storeContext.Stocks.ToArrayAsync();
            if (stockdata == null) return BadRequest();
            var stock = await (from stk in _storeContext.Stocks
                               join pd in _storeContext.Products on stk.ProductId equals pd.Id
                               select new StockDto { Id = stk.Id, Product = pd.ProductName, StockQuantity = stk.StockQuantity, ReorderLevel = stk.ReorderLevel, BlockedQuantity = stk.BlockedQuantity, UOM = pd.UOM }).ToListAsync();

            return Ok(stock);


        }
        [HttpGet("{id}")]
        public async Task<ActionResult> getStock(int id)
        {

            var stock = await _storeContext.Stocks.Where(x => x.Id == id).ToListAsync();
            if (stock == null) return BadRequest();
            return Ok(stock);
        }
        [HttpPost]
        public async Task<ActionResult> postStock([FromBody] StockDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var existingStock = await _storeContext.Stocks.Where(s => s.ProductId == dto.ProductId).FirstOrDefaultAsync();

            if (existingStock != null)
            {
                existingStock.StockQuantity = existingStock.StockQuantity + dto.StockQuantity;
            }
            else
            {
                var stock = _mapper.Map<Stock>(dto);
                _storeContext.Stocks.Add(stock);
            }
            await _storeContext.SaveChangesAsync();
            return Ok();
        }
    }
}
