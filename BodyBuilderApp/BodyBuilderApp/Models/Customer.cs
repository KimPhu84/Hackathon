using System;
using System.Collections.Generic;

#nullable disable

namespace BodyBuilderApp.Models
{
    public partial class Customer
    {
        public Customer()
        {
            BodyStatuses = new HashSet<BodyStatus>();
        }

        public string UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string TargetId { get; set; }
        public string BodyStatusId { get; set; }
        public virtual Target Target { get; set; }
        public virtual ICollection<BodyStatus> BodyStatuses { get; set; }
    }
}
