using Domain.Common;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Desription { get; set; }
        public decimal Rate { get; set; }
    }
}
