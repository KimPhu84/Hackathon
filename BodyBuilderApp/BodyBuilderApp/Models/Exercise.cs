using System;
using System.Collections.Generic;

#nullable disable

namespace BodyBuilderApp.Models
{
    public partial class Exercise
    {
        public string ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public int Set { get; set; }
        public string BodyPart { get; set; }
        public string Step { get; set; }
        public int Rep { get; set; }
        public float CaloBurn { get; set; }
    }
}
