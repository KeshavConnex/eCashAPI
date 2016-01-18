using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCashAPI.DTO.eCash
{
    public class SecurityVerificationRequest
    {
        public Credentials Credentials { get; set; }
        public Dictionary<string, string> SecurityVerificationDetails { get; set; }
    }
}
