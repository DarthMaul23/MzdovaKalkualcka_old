using System.Threading.Tasks;
using System;
using System.Text.Json;
using TestAPI.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace TestAPI.Calculators
{
    public class IncomeCalculator
    {
        
        IncomeItemRequest _request;
        IncomeItem _incomeItem;

        public IncomeCalculator(){
            _incomeItem = new IncomeItem();
        }

        public JObject GetIncomeCalculation(IncomeItemRequest request){
            
            _request = request;

            return GetIncome();

        }

        public JObject GetIncome(){
            
            if(Convert.ToInt32(_request.BrutoIncome)>0){

                setUp();
                calcIncome();
                return JObject.Parse(JsonConvert.SerializeObject(_incomeItem));

            }else{
                
                return JObject.Parse(JsonConvert.SerializeObject(new Error(){ ErrorCode = "ErrorX01", ErrorMessage = "Hrubá mzda musí být vyšší než 0 Kč"}));
            }
        }

        private void setUp(){

            _incomeItem.BrutoIncome = _request.BrutoIncome;
            _incomeItem.Student = _request.Student;
            _incomeItem.Discount = _request.Discount;
            _incomeItem.Childern = _request.Childern;
            _incomeItem.Disabled = _request.Disabled;

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