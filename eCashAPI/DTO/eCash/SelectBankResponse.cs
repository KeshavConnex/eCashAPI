﻿using System.Collections.Generic;

namespace eCashAPI
{
    public class SelectBankResponse
    {
        public Result Result { get; set; }
        public Bank Bank { get; set; }
        public  List<CustomField> CustomField { get; set; }
    }
}
