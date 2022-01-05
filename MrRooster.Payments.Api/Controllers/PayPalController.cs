using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MrRooster.Payments.Api.Features.PayPalCreatePlan;
using MrRooster.Payments.Api.Features.PayPalCreateProduct;
using MrRooster.Payments.Api.Features.PayPalCreateSubscription;
using MrRooster.Payments.Api.Features.PayPalGetProduct;
using MrRooster.Payments.Application.Commands;
using MrRooster.Payments.Application.Queries;
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
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/paypal/products")]
        public async Task<ActionResult<PayPalCreateProductResponse>> CreateProduct([FromBody] PayPalCreateProductRequest request)
        {
            var command = Mapper.Map<PayPalCreateProductCommand>(request);
            var result = await Mediator.Send(command);
            var response = Mapper.Map<PayPalCreateProductResponse>(result);
            return Ok(response);
        }

        /// <summary>
        /// Get a PayPal product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("/paypal/products/{ProductId}")]
        public async Task<ActionResult<PayPalGetProductResponse>> GetProduct([FromRoute] PayPalGetProductRequest request)
        {
            var command = Mapper.Map<PayPalGetProductQuery>(request);
            var result = await Mediator.Send(command);
            var response = Mapper.Map<PayPalGetProductResponse>(result);
            return Ok(response);
        }

        /// <summary>
        /// Create a PayPal plan
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/paypal/billing/plans")]
        public async Task<ActionResult<PayPalCreatePlanResponse>> CreatePlan([FromBody] PayPalCreatePlanRequest request)
        {
            var command = Mapper.Map<PayPalCreatePlanCommand>(request);
            var result = await Mediator.Send(command);
            var response = Mapper.Map<PayPalCreatePlanResponse>(result);
            return Ok(response);
        }

        /// <summary>
        /// Create a PayPal subscription
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/paypal/billing/subscriptions")]
        public async Task<ActionResult<PayPalCreateSubscriptionResponse>> CreateSubscription([FromBody] PayPalCreateSubscriptionRequest request)
        {
            var command = Mapper.Map<PayPalCreateSubscriptionCommand>(request);
            var result = await Mediator.Send(command);
            var response = Mapper.Map<PayPalCreateSubscriptionResponse>(result);
            return Ok(response);
        }
    }

}



