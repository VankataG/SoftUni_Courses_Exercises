using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace SocialMediaManager.Tests
{
    public class Tests
    {
        private InfluencerRepository influencerRepo;
        private Influencer influencer;
        private Influencer nullInfluencer;

        [SetUp]
        public void Setup()
        {
            influencerRepo = new InfluencerRepository();
             influencer = new Influencer("Ivan", 666);
             nullInfluencer = null;
        }

        [Test]
        public void Constructor_CreateInstance()
        {
            Assert.IsNotNull(influencerRepo);
            Assert.AreEqual(0, influencerRepo.Influencers.Count);
        }

        [Test]
        public void RegisterInfluencer_Throws_AddingNullValue()
        {

            Assert.Throws<ArgumentNullException>(
                () => influencerRepo.RegisterInfluencer(nullInfluencer));
        }

        [Test]
        public void RegisterInfluencer_Throws_AddingExistingInfluencer()
        {
            
            influencerRepo.RegisterInfluencer(influencer);
            Assert.Throws<InvalidOperationException>(
                () => influencerRepo.RegisterInfluencer(influencer));
        }

        [Test]
        public void RegisterInfluencer_SuccesfullyAddsInfluencer()
        {
            string expected = $"Successfully added influencer {influencer.Username} with {influencer.Followers}";

            string actual = influencerRepo.RegisterInfluencer(influencer);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(1, influencerRepo.Influencers.Count);
        }

        [Test]
        public void RemoveInfluencer_Throws_RemovingNullInfluencer()
        {
            Assert.Throws<ArgumentNullException>(
                () => influencerRepo.RemoveInfluencer(null));
            Assert.Throws<ArgumentNullException>(
                () => influencerRepo.RemoveInfluencer(" "));
        }

        [Test]
        public void RemoveInfluencer_ReturnFalse()
        {
            Assert.IsFalse(influencerRepo.RemoveInfluencer("Gosho"));
        }

        [Test]
        public void RemoveInfluencer_ReturnTrue()
        {
            influencerRepo.RegisterInfluencer(influencer);
            Assert.IsTrue(influencerRepo.RemoveInfluencer("Ivan"));
        }


        [TestCase (667)]
        [TestCase (1000)]
        public void GetInfluencerWithMostFollowers_ReturnRightInfluencer(int followers)
        {
            Influencer topInfluencer = new Influencer("Genata", followers);
            influencerRepo.RegisterInfluencer(influencer);
            influencerRepo.RegisterInfluencer(topInfluencer);
            Influencer influencerWithMostFollowers = influencerRepo.GetInfluencerWithMostFollowers();
            Assert.AreEqual(influencerWithMostFollowers.Followers, topInfluencer.Followers);
            Assert.AreEqual(influencerWithMostFollowers.Username, topInfluencer.Username);
        }

        [Test]
        public void GetInfluencer_ReturnRightInfluencer()
        {
            influencerRepo.RegisterInfluencer(influencer);
            influencerRepo.RegisterInfluencer(new Influencer("Petko", 2342));

            Influencer getInfluencer = influencerRepo.GetInfluencer("Ivan");

            Assert.AreEqual(influencer.Username, getInfluencer.Username);
            Assert.AreEqual(influencer.Followers, getInfluencer.Followers);

            getInfluencer = influencerRepo.GetInfluencer("Petko");

            Assert.AreEqual("Petko", getInfluencer.Username);
            Assert.AreEqual(2342, getInfluencer.Followers);
        }

        [Test]
        public void GetInfluencer_ReturnNull()
        {
            Influencer getInfluencer = influencerRepo.GetInfluencer("Mitko");

            Assert.AreEqual(null, getInfluencer);
        }
    }
}