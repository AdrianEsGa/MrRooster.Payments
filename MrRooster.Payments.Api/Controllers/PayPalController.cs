using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MrRooster.Payments.Api.Features.PayPalCreateProduct;
using MrRooster.Payments.Application.Commands.PayPal;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace MrRooster.Payments.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [SwaggerResponse(400, "One ore more properties of the request are no valid", type: typeof(ProblemDetails))]
    [SwaggerResponse(404, "No items found for the request", type: typeof(void))]
    [SwaggerTag("This API provides functionality related payments with PayPal")]
    public class PayPalController : Controller
    {
        private IMediator Mediator { get; set; }
        private IMapper Mapper { get; set; }

        public PayPalController(IMediator mediator, IMapper mapper)
        {
            Mediator = mediator;
            Mapper = mapper;
        }

        /// <summary>
        /// Create a PayPal product
        /// </summary>
        /// <remarks>
        /// Create a PayPal product
        /// </remarks>
        /// <param name="product">ID of the example</param>
        [HttpPost("/products")]
        public async Task<ActionResult> CreateProduct([FromBody] PayPalCreateProductRequest request)
        {
            var command = Mapper.Map<PayPalCreateProductCommand>(request);
            var response = await Mediator.Send(command);
            return Ok();
        }

    }

}



