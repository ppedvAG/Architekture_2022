using System;
using System.Collections.Generic;

namespace ppedv.Foodybrät.Model
{
    public class Order : Entity
    {
        public DateTime OrderDate { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();
    }
}
