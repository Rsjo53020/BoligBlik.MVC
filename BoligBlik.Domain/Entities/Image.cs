using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Domain.Common.Shared;

namespace BoligBlik.Domain.Entities
{
    public class Image : Entity
    {
        public byte[] ImageFile { get; set; }
        public User User { get; set; }

#pragma warning disable CS8618
        internal Image() : base(Guid.NewGuid()) { }
#pragma warning restore CS8618

        public Image(Guid id, byte[] imageFile, User user) : base(id)
        {
            this.User = user;
            this.ImageFile = imageFile;
        }
    }
}
