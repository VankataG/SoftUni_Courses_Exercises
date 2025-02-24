using Microsoft.VisualBasic;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;
        [SetUp]
        public void CreateAxeAndDummy()
        {
            axe = new Axe(10, 1);
            dummy = new Dummy(10, 10);
        }
        
        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            axe.Attack(dummy);
            Assert.AreEqual(0, axe.DurabilityPoints);
        }

        [Test]
        public void NotAbleToAttackWithBrokenWeapon()   
        {
            axe.Attack(dummy);
            Assert.That(() => axe.Attack(dummy), 
                Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }
    }
}