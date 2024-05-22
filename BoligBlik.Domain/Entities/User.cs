using BoligBlik.Domain.Value;
using System.ComponentModel.DataAnnotations;
using BoligBlik.Domain.Common.Shared;
using BoligBlik.Entities;

namespace BoligBlik.Domain.Entities
{
    public class User : Entity
    {

        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        
        [MaxLength(200)]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }


        // constructor for creating a new user
        public User() : base()
        {
            
        }

    }
}