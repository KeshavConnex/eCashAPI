﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCashAPI.DTO.eCash
{
    public class OfflineBarcodeRequest
    {
        public Credentials Credentials { get; set; }
        public string DeviceId { get; set; }
        public int BarcodesRequested { get; set; }
    }
}
