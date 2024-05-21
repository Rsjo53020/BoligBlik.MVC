using BoligBlik.Domain.Common.Shared;
using System.ComponentModel.DataAnnotations;

namespace BoligBlik.Domain.Entities
{
    public class BoardMember : Entity
    {
        [Required]
        public string Title { get; set; }
        public Guid? UserID { get; set; }
        public User? User { get; set; }
        public string Description { get; set; }
       public BoardMember() : base()
        {
        }
        public BoardMember(Guid id, string title, string description, User user)
        {
            Id = id;
            Title = title;
            Description = description;
            User = user;
        }
    }
}
