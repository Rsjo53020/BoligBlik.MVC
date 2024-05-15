using BoligBlik.Domain.Entities;
using BoligBlik.Domain.Value;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Persistence.Contexts.Seeder
{
    public class BoligblikSeeder
    {
    //    private readonly ModelBuilder _modelBuilder;

    //    public BoligblikSeeder(ModelBuilder modelBuilder)
    //    {
    //        _modelBuilder = modelBuilder;
    //    }

    //    public void Seed()
    //    {
    //        SeedUserAndBoardMember();

    //    }



    //    private void SeedUserAndBoardMember()
    //    {
    //        var user1 = new User(Guid.NewGuid(), "email1@email.com", "firstname1", "lastname1", "11111111",
    //            new Address(
    //                new Guid("0a3f508e - e2d8 - 32b8 - e044 - 0003ba298018"),
    //                "Bomvej",
    //                "3",
    //                "Bredsten",
    //                "7182"
    //                ));
    //        var user2 = new User(Guid.NewGuid(), "email2@email.com", "firstname2", "lastname2", "22222222",
    //            new Address(
    //                new Guid("0a3f508e-e2da-32b8-e044-0003ba298018"),
    //                "Bomvej",
    //                "4",
    //                "Bredsten",
    //                "7182"
    //                ));
    //        var user3 = new User(Guid.NewGuid(), "email3@email.com", "firstname3", "lastname3", "33333333",
    //            new Address(
    //                new Guid("0a3f508e-e2d7-32b8-e044-0003ba298018"),
    //                "Bomvej",
    //                "5",
    //                "Bredsten",
    //                "7182"
    //                ));
    //        var user4 = new User(Guid.NewGuid(), "email4@email.com", "firstname4", "lastname4", "44444444",
    //            new Address(
    //                new Guid("0a3f508e-e2d9-32b8-e044-0003ba298018"),
    //                "Bomvej",
    //                "6",
    //                "Bredsten",
    //                "7182"
    //                ));

            
    //        _modelBuilder.Entity<User>().HasData(
    //            user1,
    //            user2,
    //            user3,
    //            user4
    //           );

    //        _modelBuilder.Entity<BoardMember>().HasData(
    //            new BoardMember("Title1", "Description1", user1),
    //            new BoardMember("Title2", "Description2", user2),
    //            new BoardMember("Title3", "Description3", user3),
    //            new BoardMember("Title4", "Description4", user4)
    //           );

    //    }
    }
}
