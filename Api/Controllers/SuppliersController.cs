using Application.Features.PurchaseOperation.Commands.AddingPurchaseCommand;
using Application.Features.PurchaseOperation.Queries.GetAllPurchases;
using Application.Features.PurchaseOperation.Queries.ViewPurchaseDetails;
using Application.Features.SupplierOperation.Commands.AddSupplier;
using Application.Features.SupplierOperation.Commands.DeleteSupplier;
using Application.Features.SupplierOperation.Commands.UpdateSupplier;
using Application.Features.SupplierOperation.Queries.GetAllSuppliers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SuppliersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult>AddSupplier(AddSupplierCommand command)
        {

            return Ok(await _mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            GetAllSuppliersQuery query = new GetAllSuppliersQuery();    
            return Ok(await _mediator.Send(query));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSupplier(UpdateSupplierCommand command)
        {
         
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSupplier(DeleteSupplierCommand command)
        {

            return Ok(await _mediator.Send(command));
        }
        [HttpPost]
        public async Task<IActionResult> AddPurchase(AddPurchaseCommand command)
        {

            return Ok(await _mediator.Send(command));
        }
        [HttpPost]
        public async Task<IActionResult> ViewPurchaseDetails(ViewPurchaseDetailsQuery query)
        {

            return Ok(await _mediator.Send(query));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPurchases()
        {
            GetAllPurchasesQuery query = new ();
            return Ok(await _mediator.Send(query));
        }
    }
}
