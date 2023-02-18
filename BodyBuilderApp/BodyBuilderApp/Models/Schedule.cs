using System;
using System.Collections.Generic;

#nullable disable

namespace BodyBuilderApp.Models
{
    public partial class Schedule
    {
        public string ScheduleId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Status { get; set; }
        public string TrainerId { get; set; }

        public virtual Trainer Trainer { get; set; }
    }
}
