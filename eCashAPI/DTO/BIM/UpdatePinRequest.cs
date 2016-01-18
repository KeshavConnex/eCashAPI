namespace eCashAPI.DTO.BIM
{
    internal class UpdatePinRequest
    {
        public int consumer_id { get; set; }

        public string hashed_pin { get; set; }

    }
}
