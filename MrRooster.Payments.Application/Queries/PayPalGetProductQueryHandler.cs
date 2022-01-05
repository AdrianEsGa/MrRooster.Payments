using MediatR;
using MrRooster.Payments.Infrastructure.Abstractions;
using MrRooster.Payments.Infrastructure.ServiceClients.PayPal;
using System.Threading;
using System.Threading.Tasks;

namespace MrRooster.Payments.Application.Queries
{

    public class PayPalGetProductQuery : IRequest<PayPalProduct>
    {
        public string ProductId { get; set; }
    }

    public class PayPalGetProductQueryHandler : IRequestHandler<PayPalGetProductQuery, PayPalProduct>
    {
        private readonly IPayPalServiceClient _payPalServiceClient;

        public PayPalGetProductQueryHandler(IPayPalServiceClient payPalServiceClient)
        {
            _payPalServiceClient = payPalServiceClient;
        }

        public async Task<PayPalProduct> Handle(PayPalGetProductQuery request, CancellationToken cancellationToken)
        {
            return await _payPalServiceClient.GetProduct(request.ProductId);
        }
    }
}
