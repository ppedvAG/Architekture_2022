namespace ppedv.Foodybrät.API.Model
{
    public class FoodApiModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Kcal { get; set; }
        public bool Vegetarian { get; set; }
        public bool Vegan { get; set; }
    }
}
