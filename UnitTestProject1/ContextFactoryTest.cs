using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewPostgresApp;
using Ninject;
using Moq;

namespace UnitTestProject1
{

    [TestClass]
    public class ContextFactoryTest
    {
        private StandardKernel _kernel;

        [TestInitialize]
        public void SetUp()
        {
            _kernel = new StandardKernel();
            _kernel.Bind<IContextFactory>().To<ContextFactory>();
        }

        [TestCleanup]
        public void TearDown()
        {
            _kernel = null;
        }

        [TestMethod]
        public void ContextFactory_OnGetContext_ShouldReturnContext()
        {
            //Arrange
            var factory = _kernel.Get<IContextFactory>();
            
            //Act
            var context = factory.GetContext();

            //Assert
            Assert.IsNotNull(context);
        }
        [TestMethod]
        public void ContextFactoryMock_OnGetContext_ShouldReturnContext()
        {
            //Arrange
            
            //Создание Mock-объекта
            var ContextFactoryMock = new Moq.Mock<IContextFactory>();
            //Настройка
            ApplicationContext nullApContx = null;
            ContextFactoryMock.Setup(obj => obj.GetContext()).Returns(nullApContx);
            //Проверка
            IContextFactory factory = ContextFactoryMock.Object;

            //Act
            var context = factory.GetContext();

            //Assert
            Assert.IsNotNull(context);
        }
    }
}
