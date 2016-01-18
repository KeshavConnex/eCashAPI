namespace eCashAPI.DTO.BIM
{
    public class TransactionSummary
    {
        public string trans_type { get; set; }
        public string trans_type_desc { get; set; }
        public string clerk_id { get; set; }
        public string batch_id { get; set; }
        public string shift_id { get; set; }
        public string count { get; set; }
        public string total { get; set; }
    }
}
