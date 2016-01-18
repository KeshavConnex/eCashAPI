namespace eCashAPI.DTO.BIM
{
    internal class ServiceResponse
    {
        public string reference_number { get; set; }

        public string status { get; set; }

        public string[] messages { get; set; }

        public string notification { get; set; }

        public Error error { get; set; }

        public Payload payload { get; set; }
    }
}
