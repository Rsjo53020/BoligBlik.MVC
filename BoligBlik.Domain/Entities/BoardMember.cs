using BoligBlik.Domain.Common.Shared;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BoligBlik.Domain.Entities
{
    public class BoardMember : Entity
    {
        [Required]
        public string Title { get; set; }
        public User? User { get; set; }
        public string Description { get; set; }
       public BoardMember() : base()
        {
        }
    }
}
