using AutoMapper;
using BoligBlik.Application.Common.Mappings;
using BoligBlik.Application.DTO.Address;
using BoligBlik.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.CoreTest
{
    public class AddressTest
    {

        public class AddressMappingUnitTest
        {

            /// <summary>
            /// Test Address Mapping
            /// </summary>
            [Fact]
            public void TestAddressMapping()
            {
                var configuration = new MapperConfiguration(cfg => cfg.AddProfile<AddressMappingProfile>());
                var mapper = configuration.CreateMapper();

                var addressDto = new AddressDTO
                {
                    Street = "Findlandsvej",
                    HouseNumber = "51",
                    Floor = "1",
                    DoorNumber = "th",
                    PostalCodeNumber = "Vejle",
                    City = "7100"

                };

                var address = mapper.Map<Address>(addressDto);

                Assert.True(address.Id == addressDto.Id);
                Assert.True(address.Street == addressDto.Street);
                Assert.True(address.HouseNumber == addressDto.HouseNumber);
                Assert.True(address.Floor == addressDto.Floor);
                Assert.True(address.DoorNumber == addressDto.DoorNumber);
                Assert.True(address.PostalCode.City == addressDto.City);
                Assert.True(address.PostalCode.PostalcodeNumber == addressDto.PostalCodeNumber);
            }
        }
    }
}
