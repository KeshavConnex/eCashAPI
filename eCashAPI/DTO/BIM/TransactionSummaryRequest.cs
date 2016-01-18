namespace eCashAPI.DTO.BIM
{
    internal class TransactionSummaryRequest
    {
        public string terminal_id { get; set; }
        public string clerk_id { get; set; }
        public string shift_id { get; set; }
        public string batch_id { get; set; }
        public string current_page { get; set; }
        public string row_count { get; set; }
    }
}

