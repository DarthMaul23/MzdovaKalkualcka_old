namespace TestAPI
{
    public class IncomeItemRequest
    {
        public double BrutoIncome { get; set; } = 0;
        public bool Student { get; set; } = false;
        public bool Discount { get; set; } = false;
        public int Childern { get; set; } = 0;
        public int Disabled { get; set; } = 0;
    }
}