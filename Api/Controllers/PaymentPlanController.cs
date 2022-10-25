namespace Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/paymentplan")]
[ApiVersion("1.0")]
public class PaymentPlanController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<PaymentPlanController> _logger;

    public PaymentPlanController(ILogger<PaymentPlanController> logger, IMediator mediator)
    {
        _mediator = mediator;
        _logger = logger;
    }

    /// <summary>
    /// Creates Payment Plan for a given payment amount, installment count and Purchase Date
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST api/v1/paymentplan
    ///     {
    ///         "purhcaseDate": "2022-10-25T10:39:12.892Z",
    ///         "purchaseAmount": 1000,
    ///         "installments": 4
    ///     }
    /// </remarks>
    /// <param name="request"></param>
    /// <returns>PaymentPlanResponse</returns>
    [HttpPost()]
    [ProducesResponseType(typeof(PaymentPlanResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreatePaymentPlan([FromBody] CreatePaymentPlanRequest request)
    {
        CreatePaymentPlanCommand command = new(request);
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(CreatePaymentPlan), result);
    }



    /// <summary>
    /// Returns Payment Plan for a given Payment Plan Id
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///     GET api/v1/paymentplan/id/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///     
    /// </remarks>
    /// <param name="id">Payment Plan Id</param>
    /// <returns>PaymentPlanResponse</returns>
    [HttpGet("id/{id}")]
    [ProducesResponseType(typeof(PaymentPlanResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreatePaymentPlan([FromRoute] Guid id)
    {
        GetPaymentPlanQuery query = new(id);
        var result = await _mediator.Send(query);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}