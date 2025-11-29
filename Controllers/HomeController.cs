using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MiniShoppingApp.Models;
using System.Text.Json;


namespace MiniShoppingApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    AppDbContextService _appDbContextService;

    public HomeController(ILogger<HomeController> logger, AppDbContextService appDbContext)
    {
        _logger = logger;
        _appDbContextService = appDbContext;
    }

    public async Task<IActionResult> Index()
    {
        var getAllProducts = await _appDbContextService.GetAllProducts();
        return View(getAllProducts);
    }


    public async Task<IActionResult> Cart()
    {
        var customers = await _appDbContextService.GetAllOrders();
        return View(customers);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
