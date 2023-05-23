namespace YummyMvc.Models
{
    public class ProducIngredient
    {
        public int? Id { get; set; }
        public int? IngredientId { get; set; }
        public Ingredient? Ingredient { get; set; }
        public int? ProductId { get; set; }
        public Product? Product { get; set; }

    }
}
