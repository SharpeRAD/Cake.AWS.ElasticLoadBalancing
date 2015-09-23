#region Using Statements
    using System;
    using System.Collections.Generic;

    using Cake.Core;

    using Amazon;
#endregion



namespace Cake.AWS.ElasticLoadBalancing
{
    /// <summary>
    /// Contains extension methods for <see cref="ICakeEnvironment" />.
    /// </summary>
    public static class CakeEnvironmentExtensions
    {
        /// <summary>
        /// Helper method to get the AWS Credentials from environment variables
        /// </summary>
        /// <param name="environment">The cake environment.</param>
        /// <returns>A new <see cref="LoadBalancingSettings"/> instance to be used in calls to the <see cref="ILoadBalancingManager"/>.</returns>
        public static LoadBalancingSettings CreateLoadBalancingSettings(this ICakeEnvironment environment)
        {
            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }

            LoadBalancingSettings settings = new LoadBalancingSettings()
            {
                AccessKey = environment.GetEnvironmentVariable("AWS_ACCESSKEY"),
                SecretKey = environment.GetEnvironmentVariable("AWS_SECRETKEY")
            };



            string region = environment.GetEnvironmentVariable("AWS_REGION");

            if (!String.IsNullOrEmpty(region))
            {
                settings.Region = RegionEndpoint.GetBySystemName(region);
            }

            return settings;
        }
    }
}
