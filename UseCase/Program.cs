using System;
using System.Collections.Generic;

namespace UseCase
{
    // User Validation Component
    public class UserValidationComponent
    {
        public bool Validate(string userInput)
        {
            // Perform validation logic
            return userInput.Contains("@");
        }
    }

    // Dependency Injection Service
    public class DependencyInjectionService
    {
        private readonly Dictionary<Type, Type> _dependencyMap = new Dictionary<Type, Type>();

        public void Register<TFrom, TTo>()
        {
            _dependencyMap[typeof(TFrom)] = typeof(TTo);
        }

        public T Resolve<T>()
        {
            return (T)Activator.CreateInstance(_dependencyMap[typeof(T)]);
        }
    }

    // Factory Method
    public enum ProductType
    {
        Type1,
        Type2
    }

    public abstract class Product { }

    public class ProductType1 : Product { }

    public class ProductType2 : Product { }

    public class FactoryMethod
    {
        public Product CreateProduct(ProductType type)
        {
            switch (type)
            {
                case ProductType.Type1:
                    return new ProductType1();
                case ProductType.Type2:
                    return new ProductType2();
                default:
                    throw new ArgumentException("Invalid product type");
            }
        }
    }

    // Observation Mechanism
    public interface IObserver
    {
        string Update();
    }

    public class ConcreteObserver : IObserver
    {
        public string Update()
        {
            return ("Observer notified of change");
        }
    }

    public class ObservationSubject
    {
        private List<IObserver> _observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }

    // Singleton Manager
    public class SingletonManager
    {
        private static SingletonManager _instance;
        private SingletonManager() { }

        public static SingletonManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SingletonManager();
                }
                return _instance;
            }
        }

        public string DoSomething()
        {
            return ("SingletonManager is doing something");
        }
    }
}
