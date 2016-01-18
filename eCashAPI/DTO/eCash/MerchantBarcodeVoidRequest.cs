using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCashAPI.DTO.eCash
{
    public class MerchantBarcodeVoidRequest
    {
        public Credentials Credentials { get; set; }
        public Transaction Transaction { get; set; }
    }
}
