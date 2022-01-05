using MediatR;
using MrRooster.Payments.Infrastructure.Abstractions;
using MrRooster.Payments.Infrastructure.ServiceClients.PayPal;
using System.Threading;
using System.Threading.Tasks;

namespace MrRooster.Payments.Application.Commands
{
    public class PayPalCreateSubscriptionCommand : IRequest<PayPalSubscription>
    {
        public PayPalSubscription PayPalSubscription { get; set; }
    }

    public class PayPalCreateSubscriptionCommandHandler : IRequestHandler<PayPalCreateSubscriptionCommand, PayPalSubscription>
    {
        private readonly IPayPalServiceClient _payPalServiceClient;

        public PayPalCreateSubscriptionCommandHandler(IPayPalServiceClient payPalServiceClient)
        {
            _payPalServiceClient = payPalServiceClient;
        }

        public Task<PayPalSubscription> Handle(PayPalCreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
