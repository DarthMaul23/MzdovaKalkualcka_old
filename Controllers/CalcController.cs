using Microsoft.AspNetCore.Mvc;
using MzdovaKalkulackaAPI.Services;

namespace MzdovaKalkulackaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalcController : Controller
{

    IncomeService _CalcService;

    public CalcController(IncomeService calcService){
        _CalcService = calcService;
    }

    [HttpGet]
    [Route("/MzdovaKalkulacka/kalkulace")]
    public IActionResult GetCalculation(double hrubaMzda, bool slevaNaPoplatnika, bool student, int invalidita, int deti)
    {
        return Ok(_CalcService.getCalculation(new IncomeItem(){BrutoIncome = hrubaMzda, Discount = slevaNaPoplatnika, Student = student, Disabled = invalidita, Childern = deti}));
    }

}
