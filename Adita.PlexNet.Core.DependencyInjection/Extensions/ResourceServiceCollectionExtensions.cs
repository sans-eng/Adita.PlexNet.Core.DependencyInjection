using Adita.PlexNet.Core.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Adita.PlexNet.Core.Extensions.DependencyInjection
{
    /// <summary>
    /// Provides <see cref="IServiceCollection"/> extensions for <see cref="ResourceServiceDescriptor"/>.
    /// </summary>
    public static class ResourceServiceCollectionExtensions
    {
        #region Public methods
        /// <summary>
        /// Adds a singleton service of the <see cref="Type"/> specified in <paramref name="serviceType"/> with an
        /// implementation of the <see cref="Type"/> specified in <paramref name="implementationType"/> and specified <paramref name="key"/>
        /// as the resource key to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="key">The key of the resource.</param>
        /// <param name="serviceType">The type of the service to register.</param>
        /// <param name="implementationType">The implementation type of the service.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <exception cref="ArgumentException"><paramref name="key"/> is <c>null</c>, <see cref="string.Empty"/> or only contains white spaces.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="services"/>, <paramref name="serviceType"/> or <paramref name="implementationType"/>
        /// is <c>null</c>.</exception>
        public static IServiceCollection AddSingletonWithResource(
            this IServiceCollection services,
            string key,
            Type serviceType,
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

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

            return Add(services, key, serviceType, implementationType);
        }

        /// <summary>
        /// Adds a singleton service of the <see cref="Type"/> specified in <paramref name="serviceType"/> with a
        /// factory specified in <paramref name="implementationFactory"/> and specified <paramref name="key"/>
        /// as the resource key to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="key">The key of the resource.</param>
        /// <param name="serviceType">The type of the service to register.</param>
        /// <param name="implementationFactory">The factory that creates the service.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="services"/>, <paramref name="serviceType"/> or <paramref name="implementationFactory"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="key"/> is <c>null</c>, <see cref="string.Empty"/> or only contains white spaces.</exception>
        public static IServiceCollection AddSingletonWithResource(
            this IServiceCollection services,
            string key,
            Type serviceType,
            Func<IServiceProvider, object> implementationFactory)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            return Add(services, key, serviceType, implementationFactory);
        }

        /// <summary>
        /// Adds a singleton service of the type specified in <typeparamref name="TService"/> with an
        /// implementation type specified in <typeparamref name="TImplementation"/> and specified <paramref name="key"/>
        /// as the resource key to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="key">The key of the resource.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="services"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="key"/> is <c>null</c>, <see cref="string.Empty"/> or only contains white spaces.</exception>
        public static IServiceCollection AddSingletonWithResource<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(
            this IServiceCollection services,
            string key)
            where TService : class
            where TImplementation : class, TService
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));
            }

            return services.AddSingletonWithResource(key, typeof(TService), typeof(TImplementation));
        }

        /// <summary>
        /// Adds a singleton service of the type specified in <paramref name="serviceType"/> and specified <paramref name="key"/>
        /// as the resource key to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="key">The key of the resource.</param>
        /// <param name="serviceType">The type of the service to register and the implementation to use.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="services"/> or <paramref name="serviceType"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="key"/> is <c>null</c>, <see cref="string.Empty"/> or only contains white spaces.</exception>
        public static IServiceCollection AddSingletonWithResource(
           this IServiceCollection services,
           string key,
           [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            return services.AddSingletonWithResource(key, serviceType, serviceType);
        }

        /// <summary>
        /// Adds a singleton service of the type specified in <typeparamref name="TService"/> and specified <paramref name="key"/>
        /// as the resource key to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="key">The key of the resource.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="services"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="key"/> is <c>null</c>, <see cref="string.Empty"/> or only contains white spaces.</exception>
        public static IServiceCollection AddSingletonWithResource<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(
            this IServiceCollection services,
            string key)
            where TService : class
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));
            }

            return services.AddSingletonWithResource(key, typeof(TService));
        }

        /// <summary>
        /// Adds a singleton service of the type specified in <typeparamref name="TService"/> with a
        /// factory specified in <paramref name="implementationFactory"/> and specified <paramref name="key"/>
        /// as the resource key to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="key">The key of the resource.</param>
        /// <param name="implementationFactory">The factory that creates the service.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="services"/> or <paramref name="implementationFactory"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="key"/> is <c>null</c>, <see cref="string.Empty"/> or only contains white spaces.</exception>
        public static IServiceCollection AddSingletonWithResource<TService>(
            this IServiceCollection services,
            string key,
            Func<IServiceProvider, TService> implementationFactory)
            where TService : class
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));
            }

            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            return services.AddSingletonWithResource(key, typeof(TService), implementationFactory);
        }

        /// <summary>
        /// Adds a singleton service of the type specified in <typeparamref name="TService"/> with an
        /// implementation type specified in <typeparamref name="TImplementation" /> using the
        /// factory specified in <paramref name="implementationFactory"/> and specified <paramref name="key"/>
        /// as the resource key to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="key">The key of the resource.</param>
        /// <param name="implementationFactory">The factory that creates the service.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="services"/> or <paramref name="implementationFactory"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="key"/> is <c>null</c>, <see cref="string.Empty"/> or only contains white spaces.</exception>
        public static IServiceCollection AddSingletonWithResource<TService, TImplementation>(
            this IServiceCollection services,
            string key,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService : class
            where TImplementation : class, TService
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));
            }

            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            return services.AddSingletonWithResource(key, typeof(TService), implementationFactory);
        }

        /// <summary>
        /// Adds a singleton service of the type specified in <paramref name="serviceType"/> with an
        /// instance specified in <paramref name="implementationInstance"/> and specified <paramref name="key"/>
        /// as the resource key to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="key">The key of the resource.</param>
        /// <param name="serviceType">The type of the service to register.</param>
        /// <param name="implementationInstance">The instance of the service.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="services"/>, <paramref name="serviceType"/> or <paramref name="implementationInstance"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="key"/> is <c>null</c>, <see cref="string.Empty"/> or only contains white spaces.</exception>
        public static IServiceCollection AddSingletonWithResource(
            this IServiceCollection services,
            string key,
            Type serviceType,
            object implementationInstance)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (implementationInstance == null)
            {
                throw new ArgumentNullException(nameof(implementationInstance));
            }

            var serviceDescriptor = new ResourceServiceDescriptor(key, serviceType, implementationInstance);
            services.Add(serviceDescriptor);
            return services;
        }

        /// <summary>
        /// Adds a singleton service of the type specified in <typeparamref name="TService" /> with an
        /// instance specified in <paramref name="implementationInstance"/> and specified <paramref name="key"/>
        /// as the resource key to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="key">The key of the resource.</param>
        /// <param name="implementationInstance">The instance of the service.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="services"/> or <paramref name="implementationInstance"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="key"/> is <c>null</c>, <see cref="string.Empty"/> or only contains white spaces.</exception>
        public static IServiceCollection AddSingletonWithResource<TService>(
            this IServiceCollection services,
            string key,
            TService implementationInstance)
            where TService : class
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));
            }

            if (implementationInstance == null)
            {
                throw new ArgumentNullException(nameof(implementationInstance));
            }

            return services.AddSingletonWithResource(key, typeof(TService), implementationInstance);
        }

        /// <summary>
        /// Adds the specified <paramref name="service"/> as a <see cref="ServiceLifetime.Singleton"/> service
        /// and as resource using specified <paramref name="key"/> to the <paramref name="services"/> if the service type hasn't already been registered.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <param name="key">The key of the resource.</param>
        /// <param name="service">The type of the service to register.</param>
        /// <exception cref="ArgumentNullException"><paramref name="services"/> or <paramref name="service"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="key"/> is <c>null</c>, <see cref="string.Empty"/> or only contains white spaces.</exception>
        public static IServiceCollection TryAddSingletonWithResource(
            this IServiceCollection services,
            string key,
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));
            }

            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            ResourceServiceDescriptor descriptor = new(key, service, service);
            TryAdd(services, descriptor);
            return services;
        }

        /// <summary>
        /// Adds the specified <paramref name="service"/> as a <see cref="ServiceLifetime.Singleton"/> service
        /// with the <paramref name="implementationType"/> implementation and as resource using specified <paramref name="key"/>
        /// to the <paramref name="services"/> if the service type hasn't already been registered.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <param name="key">The key of the resource.</param>
        /// <param name="service">The type of the service to register.</param>
        /// <param name="implementationType">The implementation type of the service.</param>
        /// <exception cref="ArgumentNullException"><paramref name="services"/>, <paramref name="service"/> or <paramref name="implementationType"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="key"/> is <c>null</c>, <see cref="string.Empty"/> or only contains white spaces.</exception>
        public static IServiceCollection TryAddSingletonWithResource(
            this IServiceCollection services,
            string key,
            Type service,
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));
            }

            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            if (implementationType == null)
            {
                throw new ArgumentNullException(nameof(implementationType));
            }

            ResourceServiceDescriptor descriptor = new(key, service, implementationType);
            TryAdd(services, descriptor);
            return services;
        }

        /// <summary>
        /// Adds the specified <paramref name="service"/> as a <see cref="ServiceLifetime.Singleton"/> service
        /// using the factory specified in <paramref name="implementationFactory"/> and as resource using specified <paramref name="key"/>
        /// to the <paramref name="services"/> if the service type hasn't already been registered.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <param name="key">The key of the resource.</param>
        /// <param name="service">The type of the service to register.</param>
        /// <param name="implementationFactory">The factory that creates the service.</param>
        /// <exception cref="ArgumentNullException"><paramref name="services"/>, <paramref name="service"/> or <paramref name="implementationFactory"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="key"/> is <c>null</c>, <see cref="string.Empty"/> or only contains white spaces.</exception>
        public static IServiceCollection TryAddSingletonWithResource(
            this IServiceCollection services,
            string key,
            Type service,
            Func<IServiceProvider, object> implementationFactory)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));
            }

            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            ResourceServiceDescriptor descriptor = new(key, service, implementationFactory);
            TryAdd(services, descriptor);
            return services;
        }

        /// <summary>
        /// Adds the specified <typeparamref name="TService"/> as a <see cref="ServiceLifetime.Singleton"/> service
        /// and as resource using specified <paramref name="key"/>
        /// to the <paramref name="services"/> if the service type hasn't already been registered.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <param name="key">The key of the resource.</param>
        /// <exception cref="ArgumentNullException"><paramref name="services"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="key"/> is <c>null</c>, <see cref="string.Empty"/> or only contains white spaces.</exception>
        public static IServiceCollection TryAddSingletonWithResource<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(
            this IServiceCollection services,
            string key)
            where TService : class
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));
            }

            return TryAddSingletonWithResource(services, key, typeof(TService), typeof(TService));
        }

        /// <summary>
        /// Adds the specified <typeparamref name="TService"/> as a <see cref="ServiceLifetime.Singleton"/> service
        /// implementation type specified in <typeparamref name="TImplementation"/> and as resource using specified <paramref name="key"/>
        /// to the <paramref name="services"/> if the service type hasn't already been registered.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <param name="key">The key of the resource.</param>
        /// <exception cref="ArgumentNullException"><paramref name="services"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="key"/> is <c>null</c>, <see cref="string.Empty"/> or only contains white spaces.</exception>
        public static IServiceCollection TryAddSingletonWithResource<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(
            this IServiceCollection services,
            string key)
            where TService : class
            where TImplementation : class, TService
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));
            }

            return TryAddSingletonWithResource(services, key, typeof(TService), typeof(TImplementation));
        }

        /// <summary>
        /// Adds the specified <typeparamref name="TService"/> as a <see cref="ServiceLifetime.Singleton"/> service
        /// with an instance specified in <paramref name="instance"/> and as resource using specified <paramref name="key"/>
        /// to the <paramref name="services"/> if the service type hasn't already been registered.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <param name="key">The key of the resource.</param>
        /// <param name="instance">The instance of the service to add.</param>
        /// <exception cref="ArgumentNullException"><paramref name="services"/> or <paramref name="instance"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="key"/> is <c>null</c>, <see cref="string.Empty"/> or only contains white spaces.</exception>
        public static IServiceCollection TryAddSingletonWithResource<TService>(
            this IServiceCollection services, string key, TService instance)
            where TService : class
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));
            }

            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            ResourceServiceDescriptor descriptor = new(key, typeof(TService), instance);
            TryAdd(services, descriptor);
            return services;
        }

        /// <summary>
        /// Adds the specified <typeparamref name="TService"/> as a <see cref="ServiceLifetime.Singleton"/> service
        /// using the factory specified in <paramref name="implementationFactory"/> and as resource using specified <paramref name="key"/>
        /// to the <paramref name="services"/> if the service type hasn't already been registered.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <param name="key">The key of the resource.</param>
        /// <param name="implementationFactory">The factory that creates the service.</param>
        /// <exception cref="ArgumentNullException"><paramref name="services"/> or <paramref name="implementationFactory"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="key"/> is <c>null</c>, <see cref="string.Empty"/> or only contains white spaces.</exception>
        public static IServiceCollection TryAddSingletonWithResource<TService>(
            this IServiceCollection services,
            string key,
            Func<IServiceProvider, TService> implementationFactory)
            where TService : class
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));
            }

            if (implementationFactory is null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            ResourceServiceDescriptor descriptor = new(key, typeof(TService), implementationFactory);
            TryAdd(services, descriptor);
            return services;
        }
        #endregion Public methods

        #region Private methods
        private static IServiceCollection Add(
            IServiceCollection services,
            string key,
            Type serviceType,
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        {
            var descriptor = new ResourceServiceDescriptor(key, serviceType, implementationType);
            services.Add(descriptor);
            return services;
        }
        private static IServiceCollection Add(
            IServiceCollection services,
            string key,
            Type serviceType,
            Func<IServiceProvider, object> implementationFactory)
        {
            var descriptor = new ResourceServiceDescriptor(key, serviceType, implementationFactory);
            services.Add(descriptor);
            return services;
        }
        private static void TryAdd(
            this IServiceCollection services,
            ResourceServiceDescriptor descriptor)
        {
            if (services.Any(o => o is ResourceServiceDescriptor serviceDescriptor && serviceDescriptor.Key == descriptor.Key &&
            serviceDescriptor.ServiceType == descriptor.ServiceType))
            {
                return;
            }

            services.Add(descriptor);
        }
        #endregion Private methods
    }
}
