using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCashAPI.DTO.eCash
{
    public class CDWAllowedRequest
    {
        public Credentials Credentials { get; set; }

        public bool UpdateWorkflow { get; set; }
    }
}
