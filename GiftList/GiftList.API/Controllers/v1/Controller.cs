using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GiftList.API.Controllers.v1
{
    [Route("api/{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [ApiVersion("1.0")]
    public class Controller : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<Controller> _logger;

        public Controller(IMediator mediator, ILogger<Controller> logger)
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
