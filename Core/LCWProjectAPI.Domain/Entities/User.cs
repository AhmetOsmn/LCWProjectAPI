using LCWProjectAPI.Domain.Entities.Common;

namespace EntityLayer.Concrete.Entities
{
    public class User : BaseEntity
    {
        public string Surname { get; set; }
        public string EMail { get; set; }
    }
}
