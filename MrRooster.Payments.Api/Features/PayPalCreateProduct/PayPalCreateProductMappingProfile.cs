using AutoMapper;
using MrRooster.Payments.Application.Commands;
using MrRooster.Payments.Infrastructure.ServiceClients.PayPal;

namespace MrRooster.Payments.Api.Features.PayPalCreateProduct
{
    public class PayPalCreateProductMappingProfile : Profile
    {
        public PayPalCreateProductMappingProfile()
        {
            CreateMap<PayPalCreateProductRequest, PayPalCreateProductCommand>()
                .ForMember(dest => dest.PayPalProduct,
                           opt => opt.MapFrom(src => new PayPalProduct { Name = src.Name, Description = src.Description, Type = "SERVICE", Category = "SOFTWARE" }));

            CreateMap<PayPalProduct, PayPalCreateProductResponse>().ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id));

        }
    }
}
