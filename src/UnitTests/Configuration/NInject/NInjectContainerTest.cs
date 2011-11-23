using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CQRS.Configuration.NInject;
using Moq;
using Ninject;
using Ninject.Syntax;
using NUnit.Framework;


namespace UnitTests.Configuration.NInject
{

    [TestFixture]
    public class NInjectContainerTest
    {
        private IKernel kernel;
        private NInjectContainer container;
        
        [SetUp]
        public void Setup()
        {
            kernel = new StandardKernel();
            container = new NInjectContainer(kernel);
        }

        [Test]
        public void ShouldRegisterAndGetInstance()
        {
            
            container.Register<ITestInterface, TestObject>();
            var result = container.Resolve<ITestInterface>();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(TestObject), result);

        }

        [Test]
        public void ShouldRegisterAndGetMoreThenOneInstance()
        {
            container.Register<ITestInterface, TestObject>();
            container.Register<ITestInterface, TestObject2>();
            var result = container.ResolveAll<ITestInterface>();
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.IsInstanceOf(typeof(TestObject), result.ElementAt(0));
            Assert.IsInstanceOf(typeof(TestObject2), result.ElementAt(1));

        }



        private interface ITestInterface
        {
            
        }

        private class TestObject  : ITestInterface
        {
            
        }

        private class TestObject2 : ITestInterface
        {
            
            
        }


    }
}
