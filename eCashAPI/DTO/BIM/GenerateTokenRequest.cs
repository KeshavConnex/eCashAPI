﻿namespace eCashAPI.DTO.BIM
{
    internal class GenerateTokenRequest
    {
        public string client_id { get; set; }

        public string client_secret { get; set; }

        public string grant_type { get; set; }

        public string code { get; set; }

        public string redirect_uri { get; set; }
    }
}
