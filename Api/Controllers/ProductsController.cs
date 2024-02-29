using Application.Features.ProductOperations.Commands.AddingProductInfo;
using Application.Features.ProductOperations.Commands.DeleteProductInfo;
using Application.Features.ProductOperations.Commands.UpdateProductInfo;
using Application.Features.ProductOperations.Queries.GetAllProductInfos;
using Application.Features.ProductOperations.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult>AddProduct(AddingProductInfoCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProductinfos()
        {
            GetAllProductInfosQuery query=new GetAllProductInfosQuery();
            return Ok(await _mediator.Send(query));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            GetAllProductsQuery query = new ();
            return Ok(await _mediator.Send(query));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductInfoCommand command)
        {
           
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(DeleteProductInfoCommand command)
        {

            return Ok(await _mediator.Send(command));
        }
    }
}
