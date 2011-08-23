using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FakeItEasy;
using NUnit.Framework;

namespace NinjaBone.Services.Ninja
{
    [TestFixture]
    public class NinaServiceTest
    {
        [TestCase]
        public void Should_be_able_to_get_ninjas()
        {
            var ninjaService = A.Fake<INinjaService>();
            A.CallTo(() => ninjaService.GetAllNinjas()).Returns(new[] {
                                                                        new Models.Ninja
                                                                            {Name = "Apan Ola", Phone = "0704-224284"}
                                                                      });
            IEnumerable<Models.Ninja> ninjas = ninjaService.GetAllNinjas();

            Assert.That(ninjas.Count(), Is.EqualTo(1));
        }
    }
}