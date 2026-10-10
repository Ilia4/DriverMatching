namespace DriverMatching.Tests
{
    public class Tests
    {

        public DriverMap CreateMap()
        {
            DriverMap map = new DriverMap(10, 10);

            map.AddOrUpdateDriver(1, 1, 1);
            map.AddOrUpdateDriver(2, 4, 4);
            map.AddOrUpdateDriver(3, 8, 8);
            map.AddOrUpdateDriver(4, 4, 6);
            map.AddOrUpdateDriver(5, 3, 5);
            map.AddOrUpdateDriver(6, 7, 5);
            map.AddOrUpdateDriver(7, 9, 0);

            return map;
        }

        [Test]
        public void TestSorting()
        {
            DriverMap map = CreateMap();

            List<Driver> result = DriverSearch.FindNearestBySorting(map, 4, 5);

            Assert.That(result.Count, Is.EqualTo(5));
            Assert.That(result[0].Id, Is.EqualTo(2));
            Assert.That(result[1].Id, Is.EqualTo(4));
            Assert.That(result[2].Id, Is.EqualTo(5));
            Assert.That(result[3].Id, Is.EqualTo(6));
            Assert.That(result[4].Id, Is.EqualTo(1));
        }

        [Test]
        public void TestSearch()
        {
            DriverMap map = CreateMap();

            List<Driver> result = DriverSearch.FindNearestBySearch(map, 4, 5);

            Assert.That(result.Count, Is.EqualTo(5));
            Assert.That(result[0].Id, Is.EqualTo(2));
            Assert.That(result[1].Id, Is.EqualTo(4));
            Assert.That(result[2].Id, Is.EqualTo(5));
            Assert.That(result[3].Id, Is.EqualTo(6));
            Assert.That(result[4].Id, Is.EqualTo(1));
        }

        [Test]
        public void TestQueue()
        {
            DriverMap map = CreateMap();

            List<Driver> result = DriverSearch.FindNearestByQueue(map, 4, 5);

            Assert.That(result.Count, Is.EqualTo(5));
            Assert.That(result[0].Id, Is.EqualTo(2));
            Assert.That(result[1].Id, Is.EqualTo(4));
            Assert.That(result[2].Id, Is.EqualTo(5));
            Assert.That(result[3].Id, Is.EqualTo(6));
            Assert.That(result[4].Id, Is.EqualTo(1));
        }


        [Test]
        public void TestEmptyMap()
        {
            DriverMap map = new DriverMap(10, 10);

            var result1 = DriverSearch.FindNearestBySorting(map, 4, 5);
            var result2 = DriverSearch.FindNearestBySearch(map, 4, 5);
            var result3 = DriverSearch.FindNearestByQueue(map, 4, 5);

            Assert.That(result1.Count, Is.EqualTo(0));
            Assert.That(result2.Count, Is.EqualTo(0));
            Assert.That(result3.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestTwoDrivers()
        {
            DriverMap map = new DriverMap(10, 10);

            map.AddOrUpdateDriver(1, 1, 1);
            map.AddOrUpdateDriver(2, 2, 2);

            var result1 = DriverSearch.FindNearestBySorting(map, 0, 0);
            var result2 = DriverSearch.FindNearestBySearch(map, 0, 0);
            var result3 = DriverSearch.FindNearestByQueue(map, 0, 0);

            Assert.That(result1.Count, Is.EqualTo(2));
            Assert.That(result2.Count, Is.EqualTo(2));
            Assert.That(result3.Count, Is.EqualTo(2));

            Assert.That(result1[0].Id, Is.EqualTo(1));
            Assert.That(result2[0].Id, Is.EqualTo(1));
            Assert.That(result3[0].Id, Is.EqualTo(1));
        }

    }
}