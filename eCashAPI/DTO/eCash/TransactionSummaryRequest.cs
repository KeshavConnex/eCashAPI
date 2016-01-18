using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCashAPI.DTO.eCash
{
    public class TransactionSummaryRequest
    {
        public Credentials Credentials { get; set; }

        public TransactionReport TransactionReport { get; set; }
    }
}
