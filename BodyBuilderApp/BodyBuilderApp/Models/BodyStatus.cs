using System;
using System.Collections.Generic;

#nullable disable

namespace BodyBuilderApp.Models
{
    public partial class BodyStatus
    {
        public string BodyStatusId { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public string Date { get; set; }
        public string UserId { get; set; }

        public virtual Customer User { get; set; }
    }
}
