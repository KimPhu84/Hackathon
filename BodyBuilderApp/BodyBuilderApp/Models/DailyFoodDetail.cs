using System;
using System.Collections.Generic;

#nullable disable

namespace BodyBuilderApp.Models
{
    public partial class DailyFoodDetail
    {
        public string DailyFoodDetailId { get; set; }
        public string DailyFoodId { get; set; }
        public string FoodName { get; set; }
        public string TimeToEat { get; set; }
        public string Recommend { get; set; }

        public virtual FoodDetail FoodNameNavigation { get; set; }
    }
}
