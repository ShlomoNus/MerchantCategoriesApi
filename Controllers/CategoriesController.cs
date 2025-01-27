using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MerchantCategoriesApi.Data; 

namespace MerchantCategoriesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CategoriesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _context.Categories.Include(c => c.Products).ToListAsync();
        return Ok(categories);
    }
}
