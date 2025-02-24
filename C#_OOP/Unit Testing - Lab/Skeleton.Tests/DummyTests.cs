using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;

        [SetUp]
        public void CreateDummy()
        {
            dummy = new Dummy(10, 10);
        }

        [Test]
        public void DummyLosesHealthWhenAttacked()
        {
            dummy.TakeAttack(5);
            Assert.That(dummy.Health, Is.EqualTo(5));
        }

        [Test]
        public void ThrowExWhenDeadDummyIsAttacked()
        {
            dummy.TakeAttack(10);
            

            Assert.That(() => dummy.TakeAttack(5),
                Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyCanGiveXp()
        {
            dummy.TakeAttack(10);
            int experience = dummy.GiveExperience();
            Assert.AreEqual(10,experience);
        }

        [Test]
        public void AliveDummyCANTGiveXp()
        {

            Assert.That(() => dummy.GiveExperience(),
                Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }
    }
}