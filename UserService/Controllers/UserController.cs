using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.API.Application.Query;
using UserService.Application.Command;

namespace UserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;
        private readonly IValidator<CreateUserCommand> _validator;

        public UserController(ILogger<UserController> logger, IMediator mediator, IValidator<CreateUserCommand> validator)
        {
            _logger = logger;
            _mediator = mediator;
            _validator = validator;
        }

        [HttpPost()]
        public async Task<IActionResult> Post(CreateUserCommand command)
        {
            _logger.LogInformation($"Request {Request.Method} {Request.Path}");
            ValidationResult validationResult = await _validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("{id})")]
        public async Task<IActionResult> Get([FromQuery] GetUserQuery query)
        {
            _logger.LogInformation($"Request {Request.Method} {Request.Path}");
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}