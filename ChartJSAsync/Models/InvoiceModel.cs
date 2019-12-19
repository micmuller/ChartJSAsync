using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChartJSAsync.Models
{
    public class InvoiceModel
    {
        public int ID { get; set; }
        public int InvoiceNumber { get; set; }
        public double Amount { get; set; }
        public string CostCategory { get; set; }
    }

    public class CategoryChartModel
    {
        [JsonProperty(PropertyName = "CategoryList")]
        public List<string> CategoryList { get; set; }

        [JsonProperty(PropertyName = "AmountList")]
        public List<double> AmountList { get; set; }
    }
}
