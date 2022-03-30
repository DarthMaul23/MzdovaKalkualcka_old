using Microsoft.AspNetCore.Mvc;
using TestAPI.Services;

namespace TestAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsController : Controller
{

    NewsService _NewsService;

    public NewsController(NewsService newsService){
        _NewsService = newsService;
    }

    [HttpGet]
    [Route("/News/GetAllItems")]
    public IActionResult GetAllItems()
    {
        return Ok(_NewsService.getAllArticles());
    }

    [HttpGet]
    [Route("/News/GetItem")]
    public IActionResult GetItemById(Guid NewsId)
    {
        return Ok(_NewsService.getArticle(NewsId));
    }

}
