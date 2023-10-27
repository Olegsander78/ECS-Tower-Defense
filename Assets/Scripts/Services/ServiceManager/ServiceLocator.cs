using System;
using System.Collections.Generic;

namespace Services.ServiceManager
{
    public class ServiceLocator : IServiceLocator
    {
        private Dictionary<Type, object> _services;

        public ServiceLocator()
        {
            _services = new();
        }

        public ServiceLocator RegisterService<T>(T service)
        {
            var type = typeof(T);
            _services.Add(type, service);

            return this;
        }

        public T GetService<T>()
        {
            if (_services.TryGetValue(typeof(T), out object service))
            {
                return (T)service;
            }
            else
            {
                throw new Exception("Service " + typeof(T) + " not founded!");
            }
        }
    }
}