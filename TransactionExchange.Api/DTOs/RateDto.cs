using System;
using System.Collections.Generic;

namespace TransactionExchange.Api.DTOs
{
    public class RateDto
    {
        public string Base { get; set; }
        public Dictionary<string, double> Rates { get; set; }
    }
}