using MediatR;
using MrRooster.Payments.Infrastructure.Abstractions;
using MrRooster.Payments.Infrastructure.ServiceClients.PayPal;
using System.Threading;
using System.Threading.Tasks;

namespace MrRooster.Payments.Application.Commands.PayPal
{

    public class PayPalCreateProductCommand : IRequest<PayPalProductCreated>
    {
        public PayPalProduct PayPalProduct { get; set; }
    }

    public class PayPalCreateProductCommandHandler : IRequestHandler<PayPalCreateProductCommand, PayPalProductCreated>
    {
        private readonly IPayPalServiceClient _payPalServiceClient;

        public PayPalCreateProductCommandHandler(IPayPalServiceClient payPalServiceClient)
        {
            _payPalServiceClient = payPalServiceClient;
        }

        public async Task<PayPalProductCreated> Handle(PayPalCreateProductCommand request, CancellationToken cancellationToken)
        {
            var productCreated = await _payPalServiceClient.CreateProduct(request.PayPalProduct);
            return productCreated;
        }
    }
}
