namespace ppedv.Foodybrät.Model
{
    public class OrderItem : Entity
    {
        public int Amount { get; set; }
        public virtual Order Order { get; set; }
        public virtual Food Food { get; set; }
    }
}
