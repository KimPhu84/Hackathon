using System;
using System.Collections.Generic;

#nullable disable

namespace BodyBuilderApp.Models
{
    public partial class Target
    {
        public Target()
        {
            Customers = new HashSet<Customer>();
        }

        public string TargetId { get; set; }
        public string TargetName { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
