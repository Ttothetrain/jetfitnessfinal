using System;
using System.Collections.Generic;
using System.Text;

namespace TFitness.Nutritionix
{
    public class Hit
    {
        public string _index { get; set; }
        public string _type { get; set; }
        public string _id { get; set; }
        public double _score { get; set; }
        public Fields fields { get; set; }
    }
}
