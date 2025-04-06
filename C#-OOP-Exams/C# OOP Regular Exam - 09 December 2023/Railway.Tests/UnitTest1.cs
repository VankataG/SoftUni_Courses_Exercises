namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
        private RailwayStation station;
        [SetUp]
        public void Setup()
        {
            station = new RailwayStation("test");
        }

        [Test]
        public void Constructor_Throws()
        {
            Assert.Throws<ArgumentException>(
                () => new RailwayStation(null));
            Assert.Throws<ArgumentException>(
                () => new RailwayStation(" "));
        }

        [Test]
        public void Constructor_CreateInstance()
        {
            Assert.IsNotNull(station);
            Assert.AreEqual("test", station.Name);
            Assert.AreEqual(0, station.ArrivalTrains.Count);
            Assert.AreEqual(0, station.DepartureTrains.Count);
        }

        [Test]
        public void NewArrivalOnBoard_IncreaseCount()
        {
            station.NewArrivalOnBoard("new");
            Assert.AreEqual(1, station.ArrivalTrains.Count);
            Assert.AreEqual("new", station.ArrivalTrains.Peek());
        }

        [Test]
        public void TrainHasArrived_NotArrivingNow()
        {
            string expected = $"There are other trains to arrive before train.";

            station.NewArrivalOnBoard("new");

            string output = station.TrainHasArrived("train");

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TrainHasArrived_Arriving()
        {
            string expected = "new is on the platform and will leave in 5 minutes.";

            station.NewArrivalOnBoard("new");

            string output = station.TrainHasArrived("new");

            Assert.AreEqual(0, station.ArrivalTrains.Count);
            Assert.AreEqual(1, station.DepartureTrains.Count);
            Assert.AreEqual("new", station.DepartureTrains.Peek());
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TrainHasLeft_ReturnFalse()
        {
            station.NewArrivalOnBoard("new");
            station.TrainHasArrived("new");
            Assert.IsFalse(station.TrainHasLeft("test"));
        }

        [Test]
        public void TrainHasLeft_ReturnTrue()
        {
            station.NewArrivalOnBoard("new");
            station.TrainHasArrived("new");
            bool hasLeft = station.TrainHasLeft("new");
            Assert.IsTrue(hasLeft);
            Assert.AreEqual(0, station.DepartureTrains.Count);
        }
    }
}