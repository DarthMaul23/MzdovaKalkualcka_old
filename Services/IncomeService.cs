using System;
using TestAPI.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Guid;
using TestAPI.Calculators;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace TestAPI.Services
{

    public class IncomeService
    {

        IncomeCalculator calculator = new IncomeCalculator();

        public string GetCalculation(IncomeItemRequest incomeItem)
        {

            return JsonConvert.SerializeObject(calculator.GetIncomeCalculation(incomeItem), Newtonsoft.Json.Formatting.Indented);
        }

        public IncomeItemFieldNames GetCalculationFields()
        {

            return new IncomeItemFieldNames();
        }

    }
}