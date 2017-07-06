using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Configuration;

namespace Solution
{
    /// <summary>
    /// Class to bootstrap Unity for specific interface being passed
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Bootstrapper<T>
    {
        public static IUnityContainer Initialize()
        {
            return BuildUnityContainer();
        }

        private static IUnityContainer BuildUnityContainer()
        {
            IUnityContainer container = new UnityContainer();
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");//get the relevent section from XML
            string containerName = string.Format("{0}Container", typeof(T).Name.Substring(1));
            section.Configure(container, containerName);
            container.RegisterType(typeof(IEnumerable<>), new InjectionFactory((unityContainer, type, name) => unityContainer.ResolveAll(type.GetGenericArguments().Single())));
            return container;
        }

    }


}
