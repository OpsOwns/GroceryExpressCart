namespace GroceryExpressCart.Infrastructure.DTO
{
    public class MealDTO
    {
        public string Meal { get; set; }
        public decimal Price { get; set; }
        public string Url { get; set; }
    }
    public class MealsDTO : MealDTO
    {
        public int Id { get; set; }
    }
}
