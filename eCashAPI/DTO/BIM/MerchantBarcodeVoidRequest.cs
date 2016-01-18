namespace eCashAPI.DTO.BIM
{
    internal class MerchantBarcodeVoidRequest
    {
        public string terminal_id { get; set; }
        public string clerk_id { get; set; }
        public string shift_id { get; set; }
        public string batch_id { get; set; }
        public string barcode { get; set; }
        public string amount { get; set; }
        public string auth_code { get; set; }
        public string reference_number { get; set; }
    }
}

