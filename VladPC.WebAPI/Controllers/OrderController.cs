using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VladPC.BLL.DTO;
using VladPC.BLL.Interfaces;
using VladPC.DAL.Models;

namespace VladPC.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        public OrderController(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }

        [Authorize]
        [HttpPost("AddToCart/{idProduct}")]
        public async Task<IActionResult> AddProductInCart(int idProduct)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity?.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            var idUser = int.Parse(userIdClaim.Value);
            var result = await Task.Run(() => _orderService.AddProductToCart(idUser, idProduct));
            return Ok(result);
        }

        [Authorize]
        [HttpGet("Cart")]
        public async Task<IActionResult> GetCart()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity?.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            var idUser = int.Parse(userIdClaim.Value);
            var result = await Task.Run(() => _orderService.GetCart(idUser));
            return Ok(result);
        }

        [Authorize]
        [HttpDelete("Row/{id}")]
        public async Task<IActionResult> DeleteOrderRow(int id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity?.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            var idUser = int.Parse(userIdClaim.Value);
            await Task.Run(() => _orderService.DeleteOrderRow(id));
            return Ok();
        }

        [Authorize]
        [HttpPut("Row")]
        public async Task<IActionResult> ChangeOrderRow([FromBody] ChangeCountOrderRowResponse response)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity?.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            var idUser = int.Parse(userIdClaim.Value);
            bool result = false;
            await Task.Run(() => result = _orderService.UpdateOrderRow(response));
            return Ok(result);
        }

        [Authorize]
        [HttpGet("SetOrder")]
        public async Task<IActionResult> SetOrder()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity?.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            var idUser = int.Parse(userIdClaim.Value);
            await Task.Run(() => _orderService.SetOrder(idUser));
            return Ok();
        }

        [Authorize]
        [HttpGet("History")]
        public async Task<IActionResult> GetOrderHistory()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity?.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            var idUser = int.Parse(userIdClaim.Value);
            var result = await Task.Run(() => _orderService.GetOrderHistory(idUser));
            return Ok(result);
        }

        [Authorize]
        [HttpPost("ApplyPromocode")]
        public async Task<IActionResult> ApplyPromocode([FromBody] string promocode)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity?.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            var idUser = int.Parse(userIdClaim.Value);
            var result = await Task.Run(() => _orderService.ApplyPromocode(idUser, promocode));
            return Ok(result);
        }
    }
}
