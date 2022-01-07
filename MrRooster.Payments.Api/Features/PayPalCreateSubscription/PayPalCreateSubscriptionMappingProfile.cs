using AutoMapper;
using MrRooster.Payments.Application.Commands;
using MrRooster.Payments.Infrastructure.ServiceClients.PayPal;
using System.Linq;

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
                              Context = new ApplicationContext 
                              { 
                                  Locale = src.Locale, 
                                  ReturnUrl = src.ReturnUrl, 
                                  CancelUrl = src.CancelUrl, 
                                  UserAction = "SUBSCRIBE_NOW",
                                  PaymentMethod = new PaymentMethod { PayerSelected = "PAYPAL", PayeePreferred = "IMMEDIATE_PAYMENT_REQUIRED" }
                              },
                          }));


            CreateMap<PayPalSubscriptionCreated, PayPalCreateSubscriptionResponse>()
               .ForMember(dest => dest.SubscriptionId, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.ApproveLink, opt => opt.MapFrom(src => src.Links.Single(x => x.Rel.ToUpper() == "APPROVE").Href));

        }
    }
}
