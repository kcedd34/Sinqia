using Moq;
using UseCase;

namespace UseCaseTest
{
    public class UserValidationComponentTests
    {
        [Test]
        public void UserValidationComponent_ValidInput_ReturnsTrue()
        {
            // Arrange
            var userValidationComponent = new UserValidationComponent();
            string userInput = "example@domain.com";

            // Act
            bool isValid = userValidationComponent.Validate(userInput);

            // Assert
            Assert.IsTrue(isValid);
        }

    

        [Test]
        public void FactoryMethod_CreateProduct_ReturnsCorrectProduct()
        {
            // Arrange
            var factoryMethod = new FactoryMethod();

            // Act
            Product product1 = factoryMethod.CreateProduct(UseCase.ProductType.Type1);
            Product product2 = factoryMethod.CreateProduct(UseCase.ProductType.Type2);

            // Assert
            Assert.IsNotNull(product1);
            Assert.IsNotNull(product2);
            Assert.IsInstanceOf(typeof(ProductType1), product1);
            Assert.IsInstanceOf(typeof(ProductType2), product2);
        }

        [Test]
        public void NotifyObservers_CallsUpdateOnAllObservers()
        {
            // Arrange
            var subject = new ObservationSubject();
            var observer1 = new Mock<IObserver>();
            var observer2 = new Mock<IObserver>();
            subject.AddObserver(observer1.Object);
            subject.AddObserver(observer2.Object);

            // Act
            subject.NotifyObservers();

            // Assert
            observer1.Verify(o => o.Update(), Times.Once);
            observer2.Verify(o => o.Update(), Times.Once);
        }

        [Test]
        public void AddObserver_AddsObserverToList()
        {
            // Arrange
            var subject = new ObservationSubject();
            var observer = new Mock<IObserver>().Object;

            // Act
            subject.AddObserver(observer);

            // Assert
            Assert.Contains(observer, ((List<IObserver>)typeof(ObservationSubject)
                .GetField("_observers", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .GetValue(subject)));
        }

        [Test]
        public void SingletonManager_Instance_ReturnsSameInstance()
        {
            // Arrange & Act
            var instance1 = SingletonManager.Instance;
            var instance2 = SingletonManager.Instance;

            // Assert
            Assert.That(instance2, Is.SameAs(instance1));
        }

        [TestFixture]
        public class IntegrationTests
        {
            [Test]
            public void ObservationSubject_NotifiesObserverOfChange()
            {
                // Arrange
                var observer = new ConcreteObserver();
                var subject = new ObservationSubject();
                subject.AddObserver(observer);

                // Act
                subject.NotifyObservers();

                // Assert
                Assert.That(observer.Update(), Is.EqualTo("Observer notified of change"));
            }
        }

    }
}