using System;
using System.Collections.Generic;
using System.Text;

namespace TFitness.Nutritionix
{
    public class RootObject
    {
        public int total_hits { get; set; }
        public double max_score { get; set; }
        public List<Hit> hits { get; set; }
    }
}
