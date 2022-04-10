using System;
using MzdovaKalkulackaAPI.Models;

namespace MzdovaKalkulackaAPI.Calculators
{
    public class IncomeCalculator
    {
        
        IncomeItem _incomeItem;

        public IncomeCalculator(){

        }

        public IncomeItem GetIncomeCalculation(IncomeItem incomeItem){
            
            _incomeItem = incomeItem;

            calcIncome();

            return _incomeItem;
        }

        private void calcIncome(){

            double superhrubamzda = (((int) ((_incomeItem.BrutoIncome*1.34)/100))*100)+100;
            
            _incomeItem.Tax = Math.Round(_incomeItem.BrutoIncome*0.15,2);
            _incomeItem.SocialInsurance = Math.Round(_incomeItem.BrutoIncome*0.065);
            _incomeItem.HealthInsurance = Math.Round(_incomeItem.BrutoIncome*0.045);

            double cistaMzda = _incomeItem.BrutoIncome-(_incomeItem.Tax+_incomeItem.SocialInsurance+_incomeItem.HealthInsurance);
            cistaMzda = cistaMzda + GetChildernDiscount() + GetStudentDiscount() + GetDisabilityDIscount() + _incomeItem.TaxPayerDiscount;

            _incomeItem.NetoIncome = cistaMzda;
        }

        private double GetChildernDiscount(){

            double discount = 0;

            switch(_incomeItem.Childern){
                case 1: discount = 1267;
                break;
                case 2: discount = 1860;
                break;
                case int i when i > 2: discount = 2320;
                break;
            }

            _incomeItem.ChildernDiscount = discount;

            return discount;
        }

        private double GetStudentDiscount(){
            
            double discount = 0;

            if(_incomeItem.Student){
                discount = 335;
            }

            _incomeItem.StudentDiscount = discount;

            return discount;
        }

        private double GetDisabilityDIscount(){

            double discount = 0;

            switch(_incomeItem.Disabled){
                case int i when i > 0 && i < 3: discount = 210;
                break;
                case 3: discount = 420;
                break;
            }

            _incomeItem.DisabledDiscount = discount;

            return discount;
        }

    }
}