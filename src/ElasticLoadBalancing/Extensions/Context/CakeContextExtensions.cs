#region Using Statements
    using System;
    using System.Collections.Generic;

    using Cake.Core;

    using Amazon;
#endregion



namespace Cake.AWS.ElasticLoadBalancing
{
    /// <summary>
    /// Contains extension methods for <see cref="ICakeContext" />.
    /// </summary>
    public static class CakeContextExtensions
    {
        /// <summary>
        /// Helper method to get the AWS Credentials from environment variables
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <returns>A new <see cref="LoadBalancingSettings"/> instance to be used in calls to the <see cref="ILoadBalancingManager"/>.</returns>
        public static LoadBalancingSettings CreateLoadBalancingSettings(this ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            return context.Environment.CreateLoadBalancingSettings();
        }
    }
}
