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
        public string created { get; set; }

        [Name("service")]
        public string service { get; set; }

        [Name("payment_id")]
        public string payment_id { get; set; }

        [Name("descripton")]
        public string description { get; set; }

        [Name("amount")]
        public string amount { get; set; }

        [Name("currency")]
        public string currency { get; set; }

        [Name("state")]
        public string state { get; set; }

        [Name("issuer_response_code")]
        public string issuer_response_code { get; set; }

        [Name("transaction_id")]
        public string transaction_id { get; set; }

        [Name("client_id")]
        public string client_id { get; set; }

        [Name("subscription_id")]
        public string subscription_id { get; set; }

    }

    public class ModelMap : ClassMap<Payments>
    {
        public ModelMap()
        {
            Map(m => m.created).Name("created_at");
            Map(m => m.service).Name("service");
            Map(m => m.payment_id).Name("payment_id");
            Map(m => m.description).Name("description");
            Map(m => m.amount).Name("amount");
            Map(m => m.currency).Name("currency");
            Map(m => m.state).Name("state");
            Map(m => m.issuer_response_code).Name("issuer_response_code");
            Map(m => m.transaction_id).Name("transaction_id");
            Map(m => m.client_id).Name("client_id");
            Map(m => m.subscription_id).Name("subscription_id");
        }
    }
}
