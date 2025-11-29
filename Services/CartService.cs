using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

public class CartService
{
    private readonly AppDbContext _appDbContext;
    public CartService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;

    }


    public async Task AddItemToCart(int customerId, int productId)
    {
    var order = await _appDbContext.Orders.Include(o => o.LineItems).FirstOrDefaultAsync(o => o.CustomerId == customerId);


    if (order == null)
        {
            order = new Order
            {
                CustomerId = customerId,
                OrderDate = DateTime.UtcNow
            };
            _appDbContext.Orders.Add(order);
            await _appDbContext.SaveChangesAsync();
        };


    var existingItem = order.LineItems.FirstOrDefault(li => li.ProductId == productId);

    if(existingItem != null)
        {
        existingItem.Quantity++;
        }
        else
        {
            var newLineItem = new OrderLineItem
            {
                
                OrderId = order.Id,
                ProductId = productId,
                Quantity = 1
            };

        _appDbContext.OrderLineitems.Add(newLineItem);
            };


        await _appDbContext.SaveChangesAsync();

        }


    public async Task RemoveCartItem(int orderLineItem)
    {
        var orderLineItemSelector = await _appDbContext.OrderLineitems.FirstAsync(e => e.Id == orderLineItem);        
        _appDbContext.OrderLineitems.Remove(orderLineItemSelector);
        await _appDbContext.SaveChangesAsync();
    }
    }