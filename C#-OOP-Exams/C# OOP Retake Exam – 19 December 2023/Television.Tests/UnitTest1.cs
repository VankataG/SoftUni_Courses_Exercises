namespace Television.Tests
{
    using System;
    using System.Diagnostics;
    using NUnit.Framework;
    public class Tests
    {
        private TelevisionDevice _device;

        [SetUp]
        public void Setup()
        {
            _device = new TelevisionDevice("test", 20.20, 20, 10);
        }

        [Test]
        public void Constructor_CreateInstance()
        {
            Assert.AreEqual("test", _device.Brand);
            Assert.AreEqual(20.20, _device.Price);
            Assert.AreEqual(20, _device.ScreenWidth);
            Assert.AreEqual(10, _device.ScreenHeigth);
            Assert.AreEqual(0, _device.CurrentChannel);
            Assert.AreEqual(13, _device.Volume);
            Assert.AreEqual(false, _device.IsMuted);
        }

        [Test]
        public void SwitchOn_IsNotMutedOuput()
        {
            string expected = $"Cahnnel {_device.CurrentChannel} - Volume {_device.Volume} - Sound On";
            string ouput = _device.SwitchOn();

            Assert.AreEqual(expected, ouput);
        }

        [Test]
        public void SwitchOne_IsMutedOutput()
        {
            string expected = $"Cahnnel {_device.CurrentChannel} - Volume {_device.Volume} - Sound Off";
            _device.MuteDevice();
            string ouput = _device.SwitchOn();

            Assert.AreEqual(expected, ouput);
        }

        [Test]
        public void ChangeChannel_Throws_WrongInput()
        {
            Assert.Throws<ArgumentException>(
                () => _device.ChangeChannel(-2));
        }

        [TestCase(0)]
        [TestCase(5)]
        [TestCase(10)]
        public void ChangeChannel_Works(int testParam)
        {
            Assert.AreEqual(testParam, _device.ChangeChannel(testParam));
        }

        [Test]
        public void VolumeChange_UP()
        {
            string expected = "Volume: 30";
            string result = _device.VolumeChange("UP", 17);
            Assert.AreEqual(30,_device.Volume);
            Assert.AreEqual(expected,result);

            expected = "Volume: 50";
            result = _device.VolumeChange("UP", -20);
            Assert.AreEqual(50, _device.Volume);
            Assert.AreEqual(expected, result);

            expected = "Volume: 100";
            result = _device.VolumeChange("UP", 100);
            Assert.AreEqual(100,_device.Volume);
            Assert.AreEqual(expected,result);
        }

        [Test]
        public void VolumeChange_DOWN()
        {
            string expected = "Volume: 10";
            string result = _device.VolumeChange("DOWN", 3);
            Assert.AreEqual(10, _device.Volume);
            Assert.AreEqual(expected, result);

            expected = "Volume: 5";
            result = _device.VolumeChange("DOWN", -5);
            Assert.AreEqual(5, _device.Volume);
            Assert.AreEqual(expected, result);

            expected = "Volume: 0";
            result = _device.VolumeChange("DOWN", 100);
            Assert.AreEqual(0, _device.Volume);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MuteDevice_Works()
        {
            Assert.IsTrue(_device.MuteDevice());
            Assert.IsFalse(_device.MuteDevice());
        }

        [Test]
        public void ToString_ReturnRightText()
        {
            string expected = $"TV Device: test, Screen Resolution: 20x10, Price 20.2$";

            string result = _device.ToString();

            Assert.AreEqual(expected, result);
        }
    }
}