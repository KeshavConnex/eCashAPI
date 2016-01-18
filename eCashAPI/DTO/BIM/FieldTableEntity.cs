namespace eCashAPI.DTO.BIM
{
    public class FieldTableEntity
    {
        public string valueIdentifier { get; set; }

        public string maxLength { get; set; }

        public string displayName { get; set; }

        public string fieldType { get; set; }

        public string[] choices { get; set; }

        public string imageTag { get; set; }
    }
}
