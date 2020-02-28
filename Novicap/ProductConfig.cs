using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novicap
{
    public class ProductConfigModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DiscountType DiscountType { get; set; }
        public JObject DiscountObject { get; set; }
    }
}
