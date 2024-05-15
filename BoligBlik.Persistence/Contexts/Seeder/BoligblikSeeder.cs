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
        public void Seed(ModelBuilder modelBuilder)
        {
            //SeedUser(modelBuilder);
            //SeedBoardMember(modelBuilder);

        }
        //private void SeedUser(ModelBuilder modelBuilder)
        //{
        //    var guid1 = new Guid("11111111-1111-1111-1111-111111111111");
        //    var guid2 = new Guid("22222222-2222-2222-2222-222222222222");
        //    var guid3 = new Guid("33333333-3333-3333-3333-333333333333");
        //    var guid4 = new Guid("44444444-4444-4444-4444-444444444444");

        //    var address1 = new Address(
        //            new Guid("0a3f508e-e2d8-32b8-e044-0003ba298018"),
        //            "Bomvej",
        //            "3",
        //            "",
        //            "",
        //            "Bredsten",
        //            "7182"
        //            );
        //    var address2 = new Address(
        //            new Guid("0a3f508e-e2da-32b8-e044-0003ba298018"),
        //            "Bomvej",
        //            "4",
        //            "",
        //            "",
        //            "Bredsten",
        //            "7182"
        //            );
        //    var address3 = new Address(
        //            new Guid("0a3f508e-e2d7-32b8-e044-0003ba298018"),
        //            "Bomvej",
        //            "5",
        //            "",
        //            "",
        //            "Bredsten",
        //            "7182"
        //            );
        //    var address4 = new Address(
        //            new Guid("0a3f508e-e2d9-32b8-e044-0003ba298018"),
        //            "Bomvej",
        //            "6",
        //            "",
        //            "",
        //            "Bredsten",
        //            "7182"
        //            );

        //    var user1 = new User(guid1, "email1@email.com", "firstname1", "lastname1", "11111111", address1);       
        //    var user2 = new User(guid2, "email2@email.com", "firstname2", "lastname2", "22222222", address2);
        //    var user3 = new User(guid3, "email3@email.com", "firstname3", "lastname3", "33333333", address3);
        //    var user4 = new User(guid4, "email4@email.com", "firstname4", "lastname4", "44444444", address4);
                

        //    modelBuilder.Entity<User>().HasData(
        //         user1,
        //         user2,
        //         user3,
        //         user4
        //        );
        //}

        //private void SeedBoardMember(ModelBuilder modelBuilder)
        //{
        //    var guid1 = new Guid("55555555-5555-5555-5555-555555555555");
        //    var guid2 = new Guid("66666666-6666-6666-6666-666666666666");
        //    var guid3 = new Guid("77777777-7777-7777-7777-777777777777");
        //    var guid4 = new Guid("88888888-8888-8888-8888-888888888888");

        //    var boardMember1 = new BoardMember(guid1, "Title1", "Description1");
        //    var boardMember2 = new BoardMember(guid2, "Title2", "Description2");
        //    var boardMember3 = new BoardMember(guid3, "Title3", "Description3");
        //    var boardMember4 = new BoardMember(guid4, "Title4", "Description4");

        //    modelBuilder.Entity<BoardMember>().HasData(
        //        boardMember1,
        //        boardMember2,
        //        boardMember3,
        //        boardMember4
        //       );

        //}
    }
}
