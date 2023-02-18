using System;
using System.Collections.Generic;

#nullable disable

namespace BodyBuilderApp.Models
{
    public partial class ScheduleExercise
    {
        public string UserId { get; set; }
        public string ScheduleId { get; set; }
        public string ExerciseId { get; set; }

        public virtual Exercise Exercise { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual Customer User { get; set; }
    }
}
