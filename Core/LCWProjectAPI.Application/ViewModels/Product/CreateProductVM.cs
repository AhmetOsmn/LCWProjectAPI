namespace LCWProjectAPI.Application.ViewModels.Category
{
    public class CreateProductVM
    {
        public string Name { get; set; }
        public string? ImageURL{ get; set; }
        public int Status { get; set; }
        public int ColorId { get; set; }
        public int CategoryId { get; set; }
    }
}
