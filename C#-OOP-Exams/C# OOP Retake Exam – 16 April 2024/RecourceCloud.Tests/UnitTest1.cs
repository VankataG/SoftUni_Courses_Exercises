using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Threading.Tasks;

namespace RecourceCloud.Tests
{
    public class Tests
    {
        private DepartmentCloud _departmentCloud;

        [SetUp]
        public void Setup()
        {
            _departmentCloud = new DepartmentCloud();
        }

        [Test]
        public void Constructor_CreateInstance()
        {
            DepartmentCloud intance = new DepartmentCloud();
            Assert.IsNotNull(_departmentCloud);
            Assert.AreEqual(0, _departmentCloud.Resources.Count);
            Assert.AreEqual(0, _departmentCloud.Tasks.Count);
        }
            
        
        [Test]
        public void LogTask_ThrowsWithout3args()
        { 
            string[] arrStrings = new string[] { "one", "two" };

            Assert.Throws<ArgumentException>(
                () => _departmentCloud.LogTask(arrStrings));

            arrStrings = new string[] { "one", "two", "three", "four" };

            Assert.Throws<ArgumentException>(
                () => _departmentCloud.LogTask(arrStrings));

        }

        [Test]
        public void LogTaskThrowsWithNullArg()
        {
            string[] args = { "one", "two", null };
            Assert.Throws<ArgumentException>(
                () => _departmentCloud.LogTask(args));
        }

        [Test]
        public void LogTask_CreateTask_ReturnsAppropriateMessage()
        {
            string[] args = new string[] { "1", "task", "do it" };

            string ouput1 = _departmentCloud.LogTask(args);
            Assert.AreEqual(1,_departmentCloud.Tasks.Count);
            Assert.AreEqual("Task logged successfully.", ouput1);
            
            string output2 = _departmentCloud.LogTask(args);
            Assert.AreEqual($"{args[2]} is already logged.", output2);
        }

        [Test]
        public void CreateResource_ReturnFalse()
        {
            Assert.IsFalse(_departmentCloud.CreateResource());
        }

        [Test]
        public void CreateResource_ReturnTrue()
        {
            string[] args = new string[] { "1", "task", "do it" };

            _departmentCloud.LogTask(args);

            bool actual = _departmentCloud.CreateResource();
            Assert.IsTrue(actual);
            Assert.AreEqual(0, _departmentCloud.Tasks.Count);
            Assert.AreEqual(1, _departmentCloud.Resources.Count);
        }

        [Test]
        public void TestResource_ReturnsNull()
        {
            Assert.IsNull(_departmentCloud.TestResource("this is a test"));
        }

        [Test]
        public void TestResource_ReturnsResourceAndChangeProp()
        {

            string[] args = new string[] { "1", "task", "do it" };

            _departmentCloud.LogTask(args);
            _departmentCloud.CreateResource();

            Resource expectedResource = new Resource(args[2], args[1]);
            expectedResource.IsTested = true;

            Resource actualResource = _departmentCloud.TestResource(args[2]);
            Assert.IsTrue(actualResource.IsTested);
            //Assert.AreEqual(expectedResource, actualResource);
        }
    }
}