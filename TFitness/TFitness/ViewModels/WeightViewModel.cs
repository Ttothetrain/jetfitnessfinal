using System;
using System.Collections.Generic;
using System.Text;
using TFitness.Models;

namespace TFitness.ViewModels
{
    public class WeightViewModel
    {
        public List<WeightInfo> WeightData
        {
            get; set;
        }

        public WeightViewModel()
        {
            WeightData = new List<WeightInfo>();

            WeightData.Add(new WeightInfo { month = "January", weight = 191.62 });
            WeightData.Add(new WeightInfo { month = "February", weight = 187.30 });
            WeightData.Add(new WeightInfo { month = "March", weight = 190.20 });
            WeightData.Add(new WeightInfo { month = "April", weight = 185.34 });
            WeightData.Add(new WeightInfo { month = "May", weight = 180.45 });
        }

    }
}
