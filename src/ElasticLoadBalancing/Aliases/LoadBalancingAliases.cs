﻿#region Using Statements
    using System;
    using System.Collections.Generic;

    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Core.Annotations;
#endregion



namespace Cake.AWS.ElasticLoadBalancing
{
    [CakeAliasCategory("AWS.ElasticLoadBalancing")]
    [CakeNamespaceImport("Amazon")]
    [CakeNamespaceImport("AWSSDK.ElasticLoadBalancing")]
    public static class LoadBalancingAliases
    {
        private static ILoadBalancingManager CreateManager(this ICakeContext context)
        {
            return new LoadBalancingManager(context.Environment, context.Log);
        }



        /// <summary>
        /// Adds new instances to the load balancer.
        /// Once the instance is registered, it starts receiving traffic and requests from the load balancer. 
        /// Any instance that is not in any of the Availability Zones registered for the load balancer will be moved to the OutOfService state. 
        /// It will move to the InService state when the Availability Zone is added to the load balancer.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="loadBalancer">The name associated with the load balancer.</param>
        /// <param name="instances">A list of instance IDs that should be registered with the load balancer.</param>
        /// <param name="settings">The <see cref="LoadBalancingSettings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        public static void RegisterLoadBalancerInstances(this ICakeContext context, string loadBalancer, string instances, LoadBalancingSettings settings)
        {
            context.CreateManager().RegisterInstances(loadBalancer, instances.Split(','), settings);
        }

        /// <summary>
        /// Adds new instances to the load balancer.
        /// Once the instance is registered, it starts receiving traffic and requests from the load balancer. 
        /// Any instance that is not in any of the Availability Zones registered for the load balancer will be moved to the OutOfService state. 
        /// It will move to the InService state when the Availability Zone is added to the load balancer.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="loadBalancer">The name associated with the load balancer.</param>
        /// <param name="instances">A list of instance IDs that should be registered with the load balancer.</param>
        /// <param name="settings">The <see cref="LoadBalancingSettings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        public static void RegisterLoadBalancerInstances(this ICakeContext context, string loadBalancer, IList<string> instances, LoadBalancingSettings settings)
        {
            context.CreateManager().RegisterInstances(loadBalancer, instances, settings);
        }



        /// <summary>
        /// Removes instances from the load balancer. Once the instance is deregistered, it will stop receiving traffic from the load balancer. 
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="loadBalancer">The name associated with the load balancer.</param>
        /// <param name="instances">A list of instance IDs that should be deregistered with the load balancer.</param>
        /// <param name="settings">The <see cref="LoadBalancingSettings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        public static void DeregisterLoadBalancerInstances(this ICakeContext context, string loadBalancer, string instances, LoadBalancingSettings settings)
        {
            context.CreateManager().DeregisterInstances(loadBalancer, instances.Split(','), settings);
        }

        /// <summary>
        /// Removes instances from the load balancer. Once the instance is deregistered, it will stop receiving traffic from the load balancer. 
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="loadBalancer">The name associated with the load balancer.</param>
        /// <param name="instances">A list of instance IDs that should be deregistered with the load balancer.</param>
        /// <param name="settings">The <see cref="LoadBalancingSettings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        public static void DeregisterLoadBalancerInstances(this ICakeContext context, string loadBalancer, IList<string> instances, LoadBalancingSettings settings)
        {
            context.CreateManager().DeregisterInstances(loadBalancer, instances, settings);
        }
    }
}
