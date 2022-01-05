using MediatR;
using MrRooster.Payments.Infrastructure.Abstractions;
using MrRooster.Payments.Infrastructure.ServiceClients.PayPal;
using System.Threading;
using System.Threading.Tasks;

namespace MrRooster.Payments.Application.Commands
{
    public class PayPalCreatePlanCommand : IRequest<PayPalPlan>
    {
        public PayPalPlan PayPalPlan { get; set; }
    }

    public class PayPalCreatePlanCommandHandler : IRequestHandler<PayPalCreatePlanCommand, PayPalPlan>
    {
        private readonly IPayPalServiceClient _payPalServiceClient;

        public PayPalCreatePlanCommandHandler(IPayPalServiceClient payPalServiceClient)
        {
            _payPalServiceClient = payPalServiceClient;
        }

        public async Task<PayPalPlan> Handle(PayPalCreatePlanCommand request, CancellationToken cancellationToken)
        {
            return await _payPalServiceClient.CreatePlan(request.PayPalPlan);
        }
    }
}
