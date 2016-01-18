using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCashAPI.DTO.eCash
{
    public class BarcodeRequest
    {
        public Credentials Credentials { get; set; }
        public string DeviceId { get; set; }
        public string HashedPin { get; set; }
    }
}
