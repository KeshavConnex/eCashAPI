namespace eCashAPI.DTO.BIM
{
    public class TransactionDetail
    {
        public string stamp { get; set; }
        public string transaction_id { get; set; }
        public string trans_type { get; set; }
        public string trans_type_desc { get; set; }
        public string total_amount { get; set; }
        public string auth_code { get; set; }
        public string barcode { get; set; }
    }
}
