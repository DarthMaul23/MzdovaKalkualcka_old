namespace TestAPI
{
    public class IncomeItemFieldNames
    {
        public string calculationId {get; set;} = "Id kalkulace";
        public string BrutoIncome {get; set;} = "Hrubá mzda";
        public string NetoIncome {get; set;} = "Čistá mzda";
        public string Tax {get; set;} = "Záloha na dani";
        public string HealthInsurance {get; set;} = "Zdravotní pojištění";
        public string SocialInsurance {get; set;} = "Sociální pojištění";
        public string Childern {get; set;} = "Počet dětí";
        public string ChildernDiscount {get; set;} = "Sleva na děti";
        public string Student {get; set;} = "Student";
        public string StudentDiscount {get; set;} = "Studnetská sleva";
        public string Disabled {get; set;} = "Invalidita";
        public string DisabledDiscount {get; set;} = "Sleva na invaliditu";
        public string Discount {get; set;} = "Sleva na poplatníka";
        public string TaxPayerDiscount {get; set;} = "Sleva na poplatníka";
    }
}