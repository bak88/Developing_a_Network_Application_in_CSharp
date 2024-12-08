using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture6_xUnitMSTest
{
    record class SomeRecordClass
    {
        public int Field;
    }

    [TestClass]
    public class AsserTests
    {
        [TestMethod]
        public void Test()
        {
            double actual = 1.0000001;
            double expected = 1.0000002;

            double tolerance = 1.0000001;
            
            Assert.AreEqual(expected, actual, tolerance);
            
        }

        [TestMethod]
        [Ignore]
        public void TestObj()
        {
            object actual = new object();
            object expected = new object();            

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestStr()
        {
            string actual = "JIM";
            string expected = "jim";

            Assert.AreEqual(expected, actual, true);

        }

        [TestMethod]
        public void AssertAreEqualRecordClass()
        {
            var actual = new SomeRecordClass() { Field = 45};
            var expected = new SomeRecordClass() { Field = 45 };

            Assert.AreEqual(expected, actual );
        }

        [TestMethod]
        [Ignore]
        public void AssertAreSameRecordClass()
        {
            var actual = new SomeRecordClass() { Field = 45 };
            var expected = new SomeRecordClass() { Field = 45 };

            Assert.AreSame(expected, actual);
        }

        [TestMethod]
        [Ignore]
        public void FailTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TypeClassTest()
        {
            var name = new SomeRecordClass();

            Assert.IsInstanceOfType(name, typeof(SomeRecordClass));
        }









    }
}
