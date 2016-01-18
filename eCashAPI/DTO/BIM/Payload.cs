using System.Collections.Generic;

namespace eCashAPI.DTO.BIM
{
    public class Payload
    {
        public string redirect { get; set; }
        public string fallback { get; set; }
        public string consumer_id { get; set; }
        public string[] field_index { get; set; }
        public object field_table { get; set; }
        public string barcode { get; set; }
        public string expr_date { get; set; }
        public string[] barcodes { get; set; }
        public string[] expr_dates { get; set; }
        public string action_code { get; set; }
        public string auth_code { get; set; }
        public string auth_operation { get; set; }
        public string auth_response_code { get; set; }
        public string auth_response_verbiage { get; set; }
        public string total_rows { get; set; }
        public string email_address { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string bank_id { get; set; }
        public string bank_display_name { get; set; }
        public string last_redirect { get; set; }
        public string last_fallback { get; set; }
        public string[] cdw_messages { get; set; }
        public FieldTableEntity[] field_table_coll { get; set; }
        public BankAccount[] bank_accounts { get; set; }
        public List<TransactionDetail> transactionDetail { get; set; }
        public List<TransactionSummary> transactionSummary { get; set; }
        public Reward[] rewards { get; set; }
    }

}
