using System.Collections.Generic;

namespace eCashAPI
{
    public class PersonalDetailsResponse
    {
        public Result Result { get; set; }
        public List<Bank> BankList { get; set; }
    }
}
