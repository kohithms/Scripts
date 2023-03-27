#region Sample_FirstTest
using NUnit.Framework;
using Prime.Services;

namespace Prime.UnitTests.Services
{
    [TestFixture]
    public class PrimeService_IsPrimeShould
    {
        private PrimeService _primeService;

        [SetUp]
        public void SetUp()
        {
            _primeService = new PrimeService();
        }

        [Test]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            var result = _primeService.IsPrime(1);

            Assert.IsFalse(result, "1 should not be prime");
        }
        #endregion
        #region Sample_TestCode
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
        {
            var result = _primeService.IsPrime(value);

            Assert.IsFalse(result, $"{value} should not be prime");
        }
        #endregion

        public TestContext TestContext { get; set; }
        [Test]
        public void TestSomething()
        {
            var value = TestContext.Parameters["ParameterName"];
            System.Console.WriteLine("read value from runsetting file is "+value);
            Assert.AreEqual("kohith", value);
            //Assert.AreEqual(null, value);            
        }
        [Test]
        public void TestEnvValues()
        {
            var env = TestContext.Parameters["env1-envName"];
            var factory = TestContext.Parameters["env1-factoryName"];
            var storage = TestContext.Parameters["env1-inteStorageAccountName"];
            var url = TestContext.Parameters["env1-DhmsApiUrl"];

            System.Console.WriteLine("envName value read value from runsetting file is " + env);
            System.Console.WriteLine("envFactoryName value read value from runsetting file is " + factory);
            System.Console.WriteLine("envstorage value read value from runsetting file is " + storage);
            System.Console.WriteLine("envurl value read value from runsetting file is " + url);
            //Assert.AreEqual(" ", env);
            //Assert.AreEqual(null, value);            
        }
    }
}
