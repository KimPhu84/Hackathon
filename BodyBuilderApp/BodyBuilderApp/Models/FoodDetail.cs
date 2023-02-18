using System;
using System.Collections.Generic;

#nullable disable

namespace BodyBuilderApp.Models
{
    public partial class FoodDetail
    {
        public FoodDetail()
        {
            DailyFoodDetails = new HashSet<DailyFoodDetail>();
        }

        public string FoodName { get; set; }
        public float Calories { get; set; }
        public string Image { get; set; }

        public virtual ICollection<DailyFoodDetail> DailyFoodDetails { get; set; }
    }
}
