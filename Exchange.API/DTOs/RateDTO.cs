using Exchange.API.Data.Entities;
using System.Collections.Generic;

namespace Exchange.API.DTOs
{
    public class RateDTO
    {
        public string Base { get; set; }
        public Dictionary<string, double> Rates { get; set; }
    }
}
