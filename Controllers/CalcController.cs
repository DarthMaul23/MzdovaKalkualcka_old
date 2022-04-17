using System.Xml;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Services;
using TestAPI.Models;

namespace TestAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalcController : Controller
{
    
    IncomeService _CalcService;

    public CalcController(IncomeService calcService){
        _CalcService = calcService;
    }

    [HttpPost]
    [Route("/MzdovaKalkulacka/kalkulace")]
    public IActionResult GetCalculation(IncomeItemRequest incomeRequest)
    {
        return Ok(_CalcService.GetCalculation(incomeRequest));
    }

    [HttpGet]
    [Route("/MzdovaKalkulacka/kalkulaceFields")]
    public IActionResult GetFieldNames(){
        return Ok(_CalcService.GetCalculationFields());
    }

}
