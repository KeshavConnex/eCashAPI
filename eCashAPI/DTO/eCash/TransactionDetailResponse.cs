using System.Collections.Generic;

namespace eCashAPI
{
    public class TransactionDetailResponse
    {
        public Result Result { get; set; }
        public List<DTO.eCash.TransactionDetail> Details { get; set; }

    }
}
