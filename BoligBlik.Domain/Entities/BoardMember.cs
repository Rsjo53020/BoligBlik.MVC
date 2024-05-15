using BoligBlik.Domain.Common.Shared;
using System.ComponentModel.DataAnnotations;

namespace BoligBlik.Domain.Entities
{
    public class BoardMember : Entity
    {
        [Required]
        public string Title { get; set; }
        public User User { get; set; }
        [Required]
        public string Description { get; set; }
        public DateOnly StartDate { get; set; }
       internal BoardMember() : base()
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
