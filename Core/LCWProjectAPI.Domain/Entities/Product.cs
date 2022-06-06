using LCWProjectAPI.Domain.Entities.Common;

namespace EntityLayer.Concrete.Entities
{
    public class Product : BaseEntity
    {
        public int Price { get; set; }
        public string ImageURL { get; set; }
        public bool IsSold { get; set; }

        public EnumStatus Status { get; set; }

        public int ColorId { get; set; }
        public Color Color{ get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
