#region Using Statements
using System;

using Amazon;
#endregion



namespace Cake.AWS.ElasticLoadBalancing
{
    /// <summary>
    /// Contains extension methods for <see cref="LoadBalancingSettings" />.
    /// </summary>
    public static class LoadBalancingSettingsExtensions
    {
        /// <summary>
        /// Specifies the AWS Access Key to use as credentials.
        /// </summary>
        /// <param name="settings">The LoadBalancing settings.</param>
        /// <param name="key">The AWS Access Key</param>
        /// <returns>The same <see cref="LoadBalancingSettings"/> instance so that multiple calls can be chained.</returns>
        public static LoadBalancingSettings SetAccessKey(this LoadBalancingSettings settings, string key)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.AccessKey = key;
            return settings;
        }

        /// <summary>
        /// Specifies the AWS Secret Key to use as credentials.
        /// </summary>
        /// <param name="settings">The LoadBalancing settings.</param>
        /// <param name="key">The AWS Secret Key</param>
        /// <returns>The same <see cref="LoadBalancingSettings"/> instance so that multiple calls can be chained.</returns>
        public static LoadBalancingSettings SetSecretKey(this LoadBalancingSettings settings, string key)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.SecretKey = key;
            return settings;
        }

        /// <summary>
        /// Specifies the AWS Session Token to use as credentials.
        /// </summary>
        /// <param name="settings">The LoadBalancing settings.</param>
        /// <param name="token">The AWS Session Token.</param>
        /// <returns>The same <see cref="LoadBalancingSettings"/> instance so that multiple calls can be chained.</returns>
        public static LoadBalancingSettings SetSessionToken(this LoadBalancingSettings settings, string token)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException("token");
            }

            settings.SessionToken = token;
            return settings;
        }



        /// <summary>
        /// Specifies the endpoints available to AWS clients.
        /// </summary>
        /// <param name="settings">The LoadBalancing settings.</param>
        /// <param name="region">The endpoints available to AWS clients.</param>
        /// <returns>The same <see cref="LoadBalancingSettings"/> instance so that multiple calls can be chained.</returns>
        public static LoadBalancingSettings SetRegion(this LoadBalancingSettings settings, string region)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.Region = RegionEndpoint.GetBySystemName(region);
            return settings;
        }

        /// <summary>
        /// Specifies the endpoints available to AWS clients.
        /// </summary>
        /// <param name="settings">The LoadBalancing settings.</param>
        /// <param name="region">The endpoints available to AWS clients.</param>
        /// <returns>The same <see cref="LoadBalancingSettings"/> instance so that multiple calls can be chained.</returns>
        public static LoadBalancingSettings SetRegion(this LoadBalancingSettings settings, RegionEndpoint region)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.Region = region;
            return settings;
        }
    }
}
