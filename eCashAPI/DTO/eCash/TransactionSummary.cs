namespace eCashAPI.DTO.eCash
{
    public class TransactionSummary
    {
        public string TransactionType { get; set; }
        public string TransactionTypeDesc { get; set; }
        public string ClerkID { get; set; }
        public string BatchID { get; set; }
        public string ShiftID { get; set; }
        public string TransactionCount { get; set; }
        public string TotalAmount { get; set; }
    }
}
