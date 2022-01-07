using MediatR;
using MrRooster.Payments.Infrastructure.Abstractions;
using MrRooster.Payments.Infrastructure.ServiceClients.PayPal;
using System.Threading;
using System.Threading.Tasks;

namespace MrRooster.Payments.Application.Commands
{
    public class PayPalCreateSubscriptionCommand : IRequest<PayPalSubscriptionCreated>
    {
        public PayPalSubscription PayPalSubscription { get; set; }
    }

    public class PayPalCreateSubscriptionCommandHandler : IRequestHandler<PayPalCreateSubscriptionCommand, PayPalSubscriptionCreated>
    {
        private readonly IPayPalServiceClient _payPalServiceClient;

        public PayPalCreateSubscriptionCommandHandler(IPayPalServiceClient payPalServiceClient)
        {
            _payPalServiceClient = payPalServiceClient;
        }

        public async Task<PayPalSubscriptionCreated> Handle(PayPalCreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            return await _payPalServiceClient.CreateSubscription(request.PayPalSubscription);
        }
    }
}
