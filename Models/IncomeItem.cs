using System;
using static System.Guid;

namespace MzdovaKalkulackaAPI
{
    public class IncomeItem
    {

        public Guid CalculationId { get; set; } = Guid.NewGuid();
        public double BrutoIncome { get; set; } = 0;
        public double NetoIncome { get; set; } = 0;
        public double Tax { get; set; } = 0;
        public double HealthInsurance { get; set; } = 0;
        public double SocialInsurance { get; set; } = 0;
        public int Childern { get; set; } = 0;
        public double ChildernDiscount { get; set; } = 0;
        public bool Student { get; set; } = false;
        public double StudentDiscount { get; set; } = 0;
        public int Disabled { get; set; } = 0;
        public double DisabledDiscount { get; set; } = 0;
        public bool Discount { get; set; } = false;
        public double TaxPayerDiscount { get; set; } = 2570;

    }
}