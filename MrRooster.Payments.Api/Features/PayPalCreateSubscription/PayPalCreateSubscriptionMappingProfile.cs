using AutoMapper;
using MrRooster.Payments.Application.Commands;
using MrRooster.Payments.Infrastructure.ServiceClients.PayPal;

namespace MrRooster.Payments.Api.Features.PayPalCreateSubscription
{
    public class PayPalCreateSubscriptionMappingProfile : Profile
    {
        public PayPalCreateSubscriptionMappingProfile()
        {
            CreateMap<PayPalCreateSubscriptionRequest, PayPalCreateSubscriptionCommand>()
            .ForMember(dest => dest.PayPalSubscription,
                         opt => opt.MapFrom(src =>
                          new PayPalSubscription
                          {
                              PlanId = src.PlanId,
                              Context = new ApplicationContext { Locale = src.Locale, ReturnUrl = src.ReturnUrl, CancelUrl = src.CancelUrl },
                          }));
        }
    }
}
