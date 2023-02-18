using System;
using System.Collections.Generic;

#nullable disable

namespace BodyBuilderApp.Models
{
    public partial class Trainer
    {
        public Trainer()
        {
            Schedules = new HashSet<Schedule>();
        }

        public string TrainerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int Status { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
