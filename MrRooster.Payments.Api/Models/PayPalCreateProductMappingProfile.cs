﻿using AutoMapper;
using MrRooster.Payments.Infrastructure.ServiceClients.PayPal;

namespace MrRooster.Payments.Api.Models
{
    public class PayPalCreateProductMappingProfile : Profile
    {
        public PayPalCreateProductMappingProfile()
        {
            CreateMap<PayPalCreateProductRequest, PayPalProduct>();

        }
    }
}
