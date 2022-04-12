using System.Collections.Generic;

namespace ppedv.Foodybrät.Model
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
