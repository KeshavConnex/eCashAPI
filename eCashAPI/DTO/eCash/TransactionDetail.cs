namespace eCashAPI.DTO.eCash
{
    public class TransactionDetail
    {
        public string TransactionID { get; set; }
        public string TransactionType { get; set; }
        public string TransactionTypeDesc { get; set; }
        public string Stamp { get; set; }
        public string TotalAmount { get; set; }
        public string AuthCode { get; set; }
        public string Barcode { get; set; }
    }
}
