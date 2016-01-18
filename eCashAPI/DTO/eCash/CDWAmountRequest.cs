using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCashAPI.DTO.eCash
{
    public class CDWAmountRequest
    {
        public Credentials Credentials { get; set; }

        public decimal DepositAmount { get; set; }

        public decimal WithdrawalAmount { get; set; }
    }
}
