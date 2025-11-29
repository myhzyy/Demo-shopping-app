using Microsoft.EntityFrameworkCore;

public class AppDbContextService
{
    AppDbContext _appDbContext;

    public AppDbContextService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;    
    }

    /// Get all products
    public async Task<List<Product>> GetAllProducts ()
    {   
        return await _appDbContext.Products.ToListAsync();
    }


    public async Task<List<Customer>> GetAllOrders()
    {
        return await _appDbContext.Customers
        .Include(c => c.Orders)
        .ThenInclude(o => o.LineItems)
        .ThenInclude(li => li.Product)
        .ToListAsync();
    }

}