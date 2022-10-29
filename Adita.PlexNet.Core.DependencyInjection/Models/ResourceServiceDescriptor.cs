using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Adita.PlexNet.Core.DependencyInjection
{
    /// <summary>
    ///  Describes a resource service with its service type, implementation, and lifetime as <see cref="ServiceLifetime.Singleton"/>.
    /// </summary>
    public class ResourceServiceDescriptor : ServiceDescriptor, IResourceServiceDescriptor
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance of <see cref="ResourceServiceDescriptor"/> identified by specified <paramref name="key"/>, <paramref name="serviceType"/>
        /// and <paramref name="implementationType"/>
        /// </summary>
        /// <param name="key">The key of the resource.</param>
        /// <param name="serviceType">The <see cref="Type"/> of the service.</param>
        /// <param name="implementationType">The <see cref="Type"/> implementing the service.</param>
        /// <exception cref="ArgumentException"><paramref name="key"/> is <c>null</c>, <see cref="string.Empty"/> or only contains white spaces.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="serviceType"/> or <paramref name="implementationType"/> is <c>null</c>.</exception>
        public ResourceServiceDescriptor(string key, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) : base(serviceType, implementationType, ServiceLifetime.Singleton)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));
            }

            if (serviceType is null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (implementationType is null)
            {
                throw new ArgumentNullException(nameof(implementationType));
            }

            Key = key;
        }
        /// <summary>
        /// Initialize a new instance of <see cref="ResourceServiceDescriptor"/> identified by specified <paramref name="key"/>, <paramref name="serviceType"/>
        /// and <paramref name="instance"/>
        /// </summary>
        /// <param name="key">The key of the resource.</param>
        /// <param name="serviceType">The <see cref="Type"/> of the service.</param>
        /// <param name="instance">The instance implementing the service.</param>
        /// <exception cref="ArgumentException"><paramref name="key"/> is <c>null</c>, <see cref="string.Empty"/> or only contains white spaces.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="serviceType"/> or <paramref name="instance"/> is <c>null</c>.</exception>
        public ResourceServiceDescriptor(string key, Type serviceType, object instance) : base(serviceType, instance)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));
            }

            if (serviceType is null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (instance is null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            Key = key;
        }
        /// <summary>
        /// Initialize a new instance of <see cref="ResourceServiceDescriptor"/> identified by specified <paramref name="key"/>, <paramref name="serviceType"/>
        /// and <paramref name="factory"/>
        /// </summary>
        /// <param name="key">The key of the resource.</param>
        /// <param name="serviceType">The <see cref="Type"/> of the service.</param>
        /// <param name="factory">A factory used for creating service instances.</param>
        /// <exception cref="ArgumentException"><paramref name="key"/> is <c>null</c>, <see cref="string.Empty"/> or only contains white spaces.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="serviceType"/> or <paramref name="factory"/> is <c>null</c>.</exception>
        public ResourceServiceDescriptor(string key, Type serviceType, Func<IServiceProvider, object> factory) : base(serviceType, factory, ServiceLifetime.Singleton)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));
            }

            if (serviceType is null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            Key = key;
        }
        #endregion Constructors

        #region Public properties
        /// <summary>
        /// Gets the key of the resource.
        /// </summary>
        public string Key { get; }
        #endregion Public properties
    }
}
