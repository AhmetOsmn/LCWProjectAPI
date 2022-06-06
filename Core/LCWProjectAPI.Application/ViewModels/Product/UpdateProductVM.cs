namespace LCWProjectAPI.Application.ViewModels.Category
{
    public class UpdateProductVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? ImageURL { get; set; }
        public int Status { get; set; }
        public int ColorId { get; set; }
        public int CategoryId { get; set; }
    }
}
