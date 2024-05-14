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
        public Byte[] Image { get; set; }
        internal BoardMember() : base()
        {
        }
        public BoardMember(string title, string description, User user)
        {
            Title = title;
            Description = description;
            User = user;
        }
    }
}
