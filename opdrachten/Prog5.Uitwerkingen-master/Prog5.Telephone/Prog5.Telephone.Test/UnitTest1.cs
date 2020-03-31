using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telefoonboek.uitwerking;
using System.Collections.Generic;

namespace Prog5.Telephone.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SortByLastName_Success()
        {
            //1. arrange
            var t = new TelephoneBook();
            t.People = new List<IPerson>()
            {
                new Person() { LastName = "BBB" },
                new Person() { LastName = "CCC" },
                new Person() { LastName = "AAA" }
            };

            //2. act
            var result = t.SortByLastName();

            //3. assert
            Assert.AreEqual("AAA", result[0].LastName);
            Assert.AreEqual("BBB", result[1].LastName);
            Assert.AreEqual("CCC", result[2].LastName);


        }
    }
}
