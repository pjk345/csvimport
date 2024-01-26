using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csvimport
{
    public class Payments
    {
        [Name("created_at")]
        public string created_at { get; set; }
        public string service { get; set; }
        public string payment_id { get; set; }
        public string descripton { get; set; }
        public string amount { get; set; }
        public string currency { get; set; }
        public string state { get; set; }
        public string issuer_response_code { get; set; }
        public string transaction_id { get; set; }
        public string client_id { get; set; }
        public string subscription_id { get; set; }

    }
}
