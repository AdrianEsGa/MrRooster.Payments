using MrRooster.Payments.Infrastructure.ServiceClients.PayPal;
using System.Threading.Tasks;

namespace MrRooster.Payments.Infrastructure.Abstractions
{
    public interface IPayPalServiceClient
    {
        Task<PayPalProduct> CreateProduct(PayPalProduct product);
    }
}
