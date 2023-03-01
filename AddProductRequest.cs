namespace Furniture_ShopAPI.Models
{
    public class AddProductRequest
    {
        public string Catogary_Id { get; set; }
        public string Product_Description { get; set; }
        public decimal Product_Name { get; set; }
        public int Product_Price { get; set; }
    }
}
