﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCashAPI.DTO.eCash
{
    public class BarcodeResponse
    {
        public Result Result { get; set; }
        public Barcode Barcode { get; set; }
        public List<Reward> Reward { get; set; }
    }
}
