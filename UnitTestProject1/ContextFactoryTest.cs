using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewPostgresApp;
using Ninject;

namespace UnitTestProject1
{

    [TestClass]
    public class ContextFactoryTest
    {

        private static StandardKernel _kernel = new StandardKernel();

        private static void Register()
        {
            _kernel.Bind<IContextFactory>().To<ContextFactory>();
        }

        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            var factory = _kernel.Get<IContextFactory>();
            var y = new ApplicationContext();
            //Act
            var context = factory.GetContext();

            //Assert
            Assert.IsInstanceOfType(context);
        }
    }
}
