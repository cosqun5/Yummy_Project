namespace YummyMvc.Models
{
    public class Product
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Path { get; set; }    
        public bool IsDeleted { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }  
    }
}
