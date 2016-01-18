using System.Collections.Generic;

namespace eCashAPI
{
    public class TransactionSummaryResponse
    {
        public Result Result { get; set; }
        public List<DTO.eCash.TransactionSummary> Summary { get; set; }

    }
}
