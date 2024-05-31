using System.ComponentModel.DataAnnotations;

namespace BoligBlik.MVC.Common.Interfaces
{
    public interface IEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
