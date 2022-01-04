using AutoMapper;
using MrRooster.Payments.Application.Queries.PayPal;
using MrRooster.Payments.Infrastructure.ServiceClients.PayPal;

namespace MrRooster.Payments.Api.Features.PayPalGetProduct
{
    public class PayPalGetProductMappingProfile : Profile
    {
        public PayPalGetProductMappingProfile()
        {
            CreateMap<PayPalGetProductRequest, PayPalGetProductQuery>();
            CreateMap<PayPalProduct, PayPalGetProductResponse>();
        }
    }
}
