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
    public class RequisitionsController : ControllerBase
    {
        private readonly StoreContext _storeContext;
        private readonly IMapper _mapper;

        public RequisitionsController(StoreContext storeContext, IMapper mapper)
        {
            _mapper = mapper;
            _storeContext = storeContext;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequisitionDto>>> getRequisition()
        {

            var requisition = (from req in _storeContext.Requisitions
                               join reqd in _storeContext.RequisitionDetails on req.Id equals reqd.RequisitionId
                               select new RequisitionDto
                               {
                                   Id = req.Id,
                                   RequisitionDate = req.RequisitionDate,
                                   EmployeeId = req.EmployeeId,
                                   Employee = req.Employee.ToString(),
                                   StatusId = req.StatusId,
                                   Status = req.Status.ToString(),
                                   RequisitionId = reqd.RequisitionId,
                                   Requisition = reqd.Requisition.ToString(),
                                   ProductId = reqd.ProductId,
                                   Product = reqd.Product.ToString(),
                                   RequestedQuantity = reqd.RequestedQuantity,
                                   UOM = reqd.UOM
                               }).ToListAsync();
            if (requisition == null) return NotFound();
            return Ok(requisition);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getRequisition(int id)
        {
            var requisition = (from req in _storeContext.Requisitions
                               join reqd in _storeContext.RequisitionDetails on req.Id equals reqd.RequisitionId
                               where req.Id == id
                               select new RequisitionDto
                               {
                                   Id = req.Id,
                                   RequisitionDate = req.RequisitionDate,
                                   EmployeeId = req.EmployeeId,
                                   Employee = req.Employee.ToString(),
                                   StatusId = req.StatusId,
                                   Status = req.Status.ToString(),
                                   RequisitionId = reqd.RequisitionId,
                                   Requisition = reqd.Requisition.ToString(),
                                   ProductId = reqd.ProductId,
                                   Product = reqd.Product.ToString(),
                                   RequestedQuantity = reqd.RequestedQuantity,
                                   UOM = reqd.UOM
                               }).ToListAsync();
            if (requisition == null) return NotFound();
            return Ok(requisition);

        }
        [HttpPost]
        public async Task<IActionResult> postRequisition([FromBody] RequisitionDto dto)
        {
            var requisition = _mapper.Map<Requisition>(dto);
            var requisitionDetails = _mapper.Map<RequisitionDetails>(dto);

            _storeContext.Requisitions.Add(requisition);
            _storeContext.RequisitionDetails.Add(requisitionDetails);
            await _storeContext.SaveChangesAsync();
            return Ok(requisition);
        }
    }
}
