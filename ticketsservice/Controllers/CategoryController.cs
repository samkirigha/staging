

using Microsoft.AspNetCore.Mvc;
using ticketsservice.Services;

namespace ticketsservice.Controllers;

[ApiController]
[Route("/categories")]
public class CategoryController : Controller
{
    private ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {

        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var result  = await _categoryService.GetAllCategories();
        return Ok(result);
    }


}