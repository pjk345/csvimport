using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csvimport
{
    public class Payments
    {
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
    public class PaymentsMap : ClassMap<Payments>
    {
        public PaymentsMap()
        {
            Map(m => m.created_at).Name("created_at");
            Map(m => m.service).Name("service");
            // ... map other fields
        }
    }
}
