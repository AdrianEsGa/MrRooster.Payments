using AutoMapper;
using MrRooster.Payments.Application.Commands;
using MrRooster.Payments.Infrastructure.ServiceClients.PayPal;
using System.Collections.Generic;

namespace MrRooster.Payments.Api.Features.PayPalCreatePlan
{
    public class PayPalCreatePlanMappingProfile : Profile
    {
        public PayPalCreatePlanMappingProfile()
        {
            CreateMap<PayPalCreatePlanRequest, PayPalCreatePlanCommand>()
               .ForMember(dest => dest.PayPalPlan,
                          opt => opt.MapFrom(src =>
                          new PayPalPlan
                          {
                              ProductId = src.ProductId,
                              Name = src.Name,
                              Description = src.Description,
                              BillingCycles = new List<PayPalBillingCycle> { new PayPalBillingCycle
                              {
                                  Frequency = new PayPalFrequency { IntervalCount = src.BillingCycle.Frequency.IntervalCount,
                                                                    IntervalUnit = src.BillingCycle.Frequency.IntervalUnit },
                                  TenureType = "REGULAR",
                                  Sequence = 1,
                                  TotalCycles = src.BillingCycle.TotalCycles,
                                  PricingScheme = new PayPalPricingScheme { FixedPrice = new PayPalFixedPrice {
                                                                                                                CurrencyCode = src.BillingCycle.FixedPrice.CurrencyCode,
                                                                                                                Value = src.BillingCycle.FixedPrice.Value }}
                              }                         
                              },
                              PaymentPreferences = new PayPalPaymentPreferences { 
                                                     AutoBillOutstanding = true, 
                                                     PaymentFailureThreshold = 3, 
                                                     SetupFee = new PayPalSetupFee { CurrencyCode = "EUR", Value = "21" },
                                                     SetupFeeFailureAction = "CONTINUE"
                              }
                          }));

            CreateMap<PayPalPlan, PayPalCreatePlanResponse>().ForMember(dest => dest.PlanId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
