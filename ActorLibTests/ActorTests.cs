using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ActorLib.Tests
{
    [TestClass()]
    public class ActorTests
    {
        private Actor actor = new Actor { Id = 1, Name = "Adnan", BirthYear = 1999};
        private Actor actorLessThan4 = new Actor { Id = 2, Name = "Tom", BirthYear = 2000 };
        private Actor actorBornBefore1820 = new Actor { Id = 3, Name = "Neymar", BirthYear = 1800 };  
        
        [TestMethod()]
        public void ValidateNameTest()
        {
            actor.Validate();
            Assert.ThrowsException<ArgumentException>(() => actorLessThan4.Validate());
        }

        [TestMethod()]
        public void ValidateBirthYearTest()
        {
            actor.Validate();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => actorBornBefore1820.Validate());
        }

        [TestMethod()]
        public void ValidateTest()
        {
            actor.Validate();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("{Id=1, Name=Adnan, BirthYear=1999}", actor.ToString());
        }
    }
}