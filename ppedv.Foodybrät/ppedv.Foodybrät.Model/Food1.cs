using System.Collections.Generic;

namespace ppedv.Foodybrät.Model
{
    public class Food : Entity
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Kcal { get; set; }
        public bool Vegetarian { get; set; }
        public bool Vegan { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();
    }
}
