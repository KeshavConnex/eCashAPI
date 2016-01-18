using System.Collections.Generic;

namespace eCashAPI
{
    public class BankLoginResponse
    {
        public Result Result { get; set; }
        public  List<CustomField> CustomField { get; set; }
        public Bank Bank { get; set; }
    }
}
