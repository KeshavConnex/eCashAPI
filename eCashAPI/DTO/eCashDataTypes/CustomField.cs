namespace eCashAPI
{
    public class CustomField
    {
        public string Identifier { get; set; }
        public string MaxLength { get; set; }
        public string DisplayName { get; set; }
        public string FieldType { get; set; }
        public int FieldOrder { get; set; }
        public string[] Choices { get; set; }
    }
}
