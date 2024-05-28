using BoligBlik.MVC.Common.Interfaces;

namespace BoligBlik.MVC.DTO.Common
{
    public class EntityDTO : IEntity
    {
        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
