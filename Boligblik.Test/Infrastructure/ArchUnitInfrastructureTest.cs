using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;
using Boligblik.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boligblik.ArchitectureTest.Infrastructure
{
    public class ArchUnitInfrastructureTest : ArchUnitBaseTest
    {
        [Fact]
        public void InfrastructureLayerShouldNotHaveDependancyOnPresentation()
        {
            //Arrange
            ArchRuleDefinition
                .Types()
                .That().
                Are(InfrastructureLayer)
                //Act
                .Should()
                .NotDependOnAny(PresentationLayer)
                //Assert
                .Check(Architecture);
        }


    }
}
