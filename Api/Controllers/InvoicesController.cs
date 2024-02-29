using Application.Features.InvoiceOperation.Commands.CreateInvoice;
using Application.Features.InvoiceOperation.Queries.GetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvoicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult>CreateInvoice(CreateInvoiceCommand command)
        {
            return Ok(await _mediator.Send(command)); 

        }
        [HttpGet]
        public async Task<IActionResult>GetAllInvoices()
        {
            GetAllCustomerQuery query = new();
            return Ok(await _mediator.Send(query));

        }
    }
}
