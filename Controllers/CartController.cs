using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class CartController : Controller
{
    private readonly CartService _cartService;
    public CartController(CartService cartService)
    {   
        _cartService = cartService;
    }   

    public async Task<IActionResult> AddItemsToOrder(int id, int productId)
    {
    await _cartService.AddItemToCart(id, productId);
    return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> RemoveItem(int orderLineItem)
    {


        await _cartService.RemoveCartItem(orderLineItem);

        return RedirectToAction("Cart", "Home");
    }
}