using NUnit.Framework;
using Airports.Service;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        AirportsService service;
        [SetUp]
        public void Setup()
        {
            service = new AirportsService();
        }

        [Test]
        public void Is_Database_Populated()
        {
            var data = service.GetAirportsByIso("PL");
            Assume.That(data.Count, Is.GreaterThan(0));
        }

        public void Is_Remote_API_Providing_Data()
        {
            int data = service.RefreshData();
            if (data > 0)
            {
                Assert.Pass();
            }
        }

        [TestCase("PL")]
        [TestCase("AL")]
        public void Is_IATA_Not_Null_For_PL(string iso)
        {
            var data = service.GetAirportsByIso(iso);
            foreach (var item in data)
            {
                Assert.That(item.Iso, Is.Not.Null);
            }
        }
    }
}