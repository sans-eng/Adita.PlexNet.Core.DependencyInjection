namespace Adita.PlexNet.Core.DependencyInjection
{
    /// <summary>
    /// Provide an abstraction for resource service descriptor.
    /// </summary>
    public interface IResourceServiceDescriptor
    {
        #region Properties
        /// <summary>
        /// Gets the key of the resource.
        /// </summary>
        string Key { get; }
        #endregion Properties
    }
}
