using System;
using MzdovaKalkulackaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Guid;
using System.Linq;
using MzdovaKalkulackaAPI.Calculators;

namespace MzdovaKalkulackaAPI.Services{

    public class IncomeService{

        IncomeCalculator calculator = new IncomeCalculator();

        public IncomeItem getCalculation(IncomeItem incomeItem){
            
            return calculator.GetIncomeCalculation(incomeItem);
        }

    }
}