using System.Collections.Generic;

namespace eCashAPI
{
    public class Bank
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
