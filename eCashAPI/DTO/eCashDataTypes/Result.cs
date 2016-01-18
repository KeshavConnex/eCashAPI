namespace eCashAPI
{
    public class Result
    {
        public bool Status { get; set; }
        public string[] Message { get; set; }
        public string Redirect { get; set; }
        public string Fallback { get; set; }
    }
}
