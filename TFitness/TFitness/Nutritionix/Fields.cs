using System;
using System.Collections.Generic;
using System.Text;

namespace TFitness.Nutritionix
{
    public class Fields
    {
        public string item_id { get; set; }
        public string item_name { get; set; }
        public string brand_name { get; set; }
        public double nf_calories { get; set; }
        public double nf_serving_size_qty { get; set; }
        public string nf_serving_size_unit { get; set; }
    }
}
