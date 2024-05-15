using Microsoft.EntityFrameworkCore;
using BoligBlik.Domain.Entities;
using BoligBlik.Domain.Value;

namespace BoligBlik.Persistence.Contexts.Seeder
{
    public  class ModelBuilderExtensions
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoardMember>().HasData(
                new BoardMember(
                    Guid.NewGuid(),
                    "Title1",
                    "Description1",
                    new User(
                        Guid.NewGuid(),
                        "ronnisjorgensen@gmail.com",
                        "firstname1",
                        "lastname1",
                        "1234567890",
                        new Address(
                            Guid.NewGuid(),
                            "Finlandsvej",
                            "53",
                            "2",
                            "th",
                            "Vejle",
                            "7100"
                        ))));

        }
    }
}
