using System.Collections.Generic;

namespace eCashAPI
{
    public class OfflineBarcodeResponse
    {
        public Result Result { get; set; }
        public List<Barcode> Barcode { get; set; }
        public List<Reward> Reward { get; set; }
    }
}
