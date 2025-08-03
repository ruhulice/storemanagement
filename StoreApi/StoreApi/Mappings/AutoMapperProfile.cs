using AutoMapper;
using StoreApi.DTOs;
using StoreApi.Models;

namespace StoreApi.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<SubCategoryDto, SubCategory>().ReverseMap();
            // CreateMap<SubCategory, SubCategoryDto>();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<StockDto, Stock>().ReverseMap();
            CreateMap<RequisitionDto, Requisition>().ReverseMap();  // RequisitionDto  for both model Requisition  and RequisitionDetails
            CreateMap<RequisitionDto, RequisitionDetails>().ReverseMap();
        }
    }
}
