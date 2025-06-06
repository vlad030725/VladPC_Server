using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VladPC.BLL.DTO;
using VladPC.BLL.Interfaces;
using VladPC.DAL.Models;
using VladPC.Common;

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
            var result = await Task.Run(() => _orderService.AddProductToOrder(GetAuthorizeUserId(), idProduct, Status.InCart));
            return Ok(result);
        }

        [Authorize]
        [HttpPost("AddToConfigurator/{idProduct}")]
        public async Task<IActionResult> AddProductInConfigurator(int idProduct)
        {
            var result = await Task.Run(() => _orderService.AddProductToOrder(GetAuthorizeUserId(), idProduct, Status.InConfigurator));
            return Ok(result);
        }

        [Authorize]
        [HttpGet("AddConfigurationToCart")]
        public async Task<IActionResult> AddConfigurationToCart()
        {
            var result = await Task.Run(() => _orderService.AddConfigurationToCart(GetAuthorizeUserId()));
            return Ok(result);
        }

        [Authorize]
        [HttpGet("Cart")]
        public async Task<IActionResult> GetCart()
        {
            var result = await Task.Run(() => _orderService.GetCart(GetAuthorizeUserId(), Status.InCart));
            return Ok(result);
        }

        [Authorize]
        [HttpGet("Configurator")]
        public async Task<IActionResult> GetConfigurator()
        {
            var result = await Task.Run(() => _orderService.GetCart(GetAuthorizeUserId(), Status.InConfigurator));
            return Ok(result);
        }

        [Authorize]
        [HttpDelete("Row/{id}")]
        public async Task<IActionResult> DeleteOrderRow(int id)
        {
            await Task.Run(() => _orderService.DeleteOrderRow(id));
            return Ok();
        }

        [Authorize]
        [HttpPut("Row")]
        public async Task<IActionResult> ChangeOrderRow([FromBody] ChangeCountOrderRowResponse response)
        {
            bool result = await Task.Run(() => _orderService.UpdateCountOrderRow(response));
            return Ok(result);
        }

        [Authorize]
        [HttpGet("SetOrder")]
        public async Task<IActionResult> SetOrder()
        {
            var result = await Task.Run(() => _orderService.SetOrder(GetAuthorizeUserId()));
            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("CompliteOrder/{id}")]
        public async Task<IActionResult> CompliteOrder(int id)
        {
            var result = await Task.Run(() => _orderService.CompliteOrder(id));
            return Ok(result);
        }

        [Authorize]
        [HttpGet("CleanCart")]
        public async Task<IActionResult> CleanCart()
        {
            await Task.Run(() => _orderService.CleanOrder(GetAuthorizeUserId(), Status.InCart));
            return Ok();
        }

        [Authorize]
        [HttpGet("History")]
        public async Task<IActionResult> GetOrderHistory()
        {
            var result = await Task.Run(() => _orderService.GetOrderHistory(GetAuthorizeUserId()));
            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetUserOrders()
        {
            var result = await Task.Run(() => _orderService.GetUserOrders());
            return Ok(result);
        }

        [Authorize]
        [HttpPost("ApplyPromocode")]
        public async Task<IActionResult> ApplyPromocode([FromBody] string promocode)
        {
            var result = await Task.Run(() => _orderService.ApplyPromocode(GetAuthorizeUserId(), promocode));
            return Ok(result);
        }

        private int GetAuthorizeUserId()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity?.FindFirst(ClaimTypes.NameIdentifier);
            var idUser = int.Parse(userIdClaim.Value);
            return idUser;
        }
    }
}
