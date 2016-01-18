namespace eCashAPI.DTO.BIM
{
    internal class StartEnrollmentRequest
    {
        public string id_type { get; set; }
        public string id_state { get; set; }
        public string id_number { get; set; }
        public string fname { get; set; }
        public string mname { get; set; }
        public string lname { get; set; }
        public string dob { get; set; }
        public string mailing_address { get; set; }
        public string apartment_number { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string home_phone_number { get; set; }
        public string mobile_phone_number { get; set; }
    }
}
