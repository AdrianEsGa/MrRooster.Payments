using MrRooster.Payments.Infrastructure.Abstractions;
using System.Threading.Tasks;

namespace MrRooster.Payments.Infrastructure.ServiceClients.PayPal
{
    public class PayPalServiceClient : IPayPalServiceClient
    {
        public Task<PayPalProductCreated> CreateProduct(PayPalProduct product)
        {
            throw new System.NotImplementedException();
        }
    }
}
