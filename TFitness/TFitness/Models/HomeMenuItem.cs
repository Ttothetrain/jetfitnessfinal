using System;
using System.Collections.Generic;
using System.Text;

namespace TFitness.Models
{
    public enum MenuItemType
    {
        Home,
        Profile,
        Meal_Plan
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
