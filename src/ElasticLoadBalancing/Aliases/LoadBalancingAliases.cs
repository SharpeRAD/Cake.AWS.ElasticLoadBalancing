#region Using Statements
    using System.Net;
    using System.Collections.Generic;

    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Core.Annotations;

    using Amazon.EC2.Util;
#endregion



namespace Cake.AWS.ElasticLoadBalancing
{
    [CakeAliasCategory("AWS")]
    [CakeNamespaceImport("Amazon")]
    [CakeNamespaceImport("Amazon.ElasticLoadBalancing")]
    public static class LoadBalancingAliases
    {
        private static ILoadBalancingManager CreateManager(this ICakeContext context)
        {
            return new LoadBalancingManager(context.Environment, context.Log);
        }



        /// <summary>
        /// Adds the current instances to the load balancer.
        /// Once the instance is registered, it starts receiving traffic and requests from the load balancer. 
        /// Any instance that is not in any of the Availability Zones registered for the load balancer will be moved to the OutOfService state. 
        /// It will move to the InService state when the Availability Zone is added to the load balancer.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="loadBalancer">The name associated with the load balancer.</param>
        /// <param name="settings">The <see cref="LoadBalancingSettings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("ElasticLoadBalancing")]
        public static bool RegisterLoadBalancerInstance(this ICakeContext context, string loadBalancer, LoadBalancingSettings settings)
        {
            return context.CreateManager().RegisterInstances(loadBalancer, EC2Metadata.InstanceId.Split(','), settings);
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
        [CakeAliasCategory("ElasticLoadBalancing")]
        public static bool RegisterLoadBalancerInstances(this ICakeContext context, string loadBalancer, string instances, LoadBalancingSettings settings)
        {
            return context.CreateManager().RegisterInstances(loadBalancer, instances.Split(','), settings);
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
        [CakeAliasCategory("ElasticLoadBalancing")]
        public static bool RegisterLoadBalancerInstances(this ICakeContext context, string loadBalancer, IList<string> instances, LoadBalancingSettings settings)
        {
            return context.CreateManager().RegisterInstances(loadBalancer, instances, settings);
        }



        /// <summary>
        /// Removes instances from the load balancer. Once the instance is deregistered, it will stop receiving traffic from the load balancer. 
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="loadBalancer">The name associated with the load balancer.</param>
        /// <param name="settings">The <see cref="LoadBalancingSettings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        public static bool DeregisterLoadBalancerInstance(this ICakeContext context, string loadBalancer, LoadBalancingSettings settings)
        {
            return context.CreateManager().DeregisterInstances(loadBalancer, EC2Metadata.InstanceId.Split(','), settings);
        }

        /// <summary>
        /// Removes instances from the load balancer. Once the instance is deregistered, it will stop receiving traffic from the load balancer. 
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="loadBalancer">The name associated with the load balancer.</param>
        /// <param name="instances">A list of instance IDs that should be deregistered with the load balancer.</param>
        /// <param name="settings">The <see cref="LoadBalancingSettings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("ElasticLoadBalancing")]
        public static bool DeregisterLoadBalancerInstances(this ICakeContext context, string loadBalancer, string instances, LoadBalancingSettings settings)
        {
            return context.CreateManager().DeregisterInstances(loadBalancer, instances.Split(','), settings);
        }

        /// <summary>
        /// Removes instances from the load balancer. Once the instance is deregistered, it will stop receiving traffic from the load balancer. 
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="loadBalancer">The name associated with the load balancer.</param>
        /// <param name="instances">A list of instance IDs that should be deregistered with the load balancer.</param>
        /// <param name="settings">The <see cref="LoadBalancingSettings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("ElasticLoadBalancing")]
        public static bool DeregisterLoadBalancerInstances(this ICakeContext context, string loadBalancer, IList<string> instances, LoadBalancingSettings settings)
        {
            return context.CreateManager().DeregisterInstances(loadBalancer, instances, settings);
        }



        /// <summary>
        ///  Adds the current Availability Zones to the set of Availability Zones for the specified load balancer.
        ///  The load balancer evenly distributes requests across all its registered Availability Zones that contain instances.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="loadBalancer">The name associated with the load balancer.</param>
        /// <param name="settings">The <see cref="LoadBalancingSettings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("ElasticLoadBalancing")]
        public static bool EnableAvailabilityZones(this ICakeContext context, string loadBalancer, LoadBalancingSettings settings)
        {
            return context.CreateManager().EnableAvailabilityZones(loadBalancer, EC2Metadata.AvailabilityZone.Split(','), settings);
        }

        /// <summary>
        ///  Adds the specified Availability Zones to the set of Availability Zones for the specified load balancer.
        ///  The load balancer evenly distributes requests across all its registered Availability Zones that contain instances.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="loadBalancer">The name associated with the load balancer.</param>
        /// <param name="zones">The Availability Zones to add to the load balancer.</param>
        /// <param name="settings">The <see cref="LoadBalancingSettings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("ElasticLoadBalancing")]
        public static bool EnableAvailabilityZones(this ICakeContext context, string loadBalancer, string zones, LoadBalancingSettings settings)
        {
            return context.CreateManager().EnableAvailabilityZones(loadBalancer, zones.Split(','), settings);
        }

        /// <summary>
        ///  Adds the specified Availability Zones to the set of Availability Zones for the specified load balancer.
        ///  The load balancer evenly distributes requests across all its registered Availability Zones that contain instances.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="loadBalancer">The name associated with the load balancer.</param>
        /// <param name="zones">The Availability Zones to add to the load balancer.</param>
        /// <param name="settings">The <see cref="LoadBalancingSettings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("ElasticLoadBalancing")]
        public static bool EnableAvailabilityZones(this ICakeContext context, string loadBalancer, IList<string> zones, LoadBalancingSettings settings)
        {
            return context.CreateManager().EnableAvailabilityZones(loadBalancer, zones, settings);
        }



        /// <summary>
        /// Removes the current Availability Zones from the set of Availability Zones for the specified load balancer.
        /// There must be at least one Availability Zone registered with a load balancer at all times. After an Availability Zone is removed, 
        /// all instances registered with the load balancer that are in the removed Availability Zone go into the OutOfService state. 
        /// Then, the load balancer attempts to equally balance the traffic among its remaining Availability Zones.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="loadBalancer">The name associated with the load balancer.</param>
        /// <param name="settings">The <see cref="LoadBalancingSettings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        public static bool DisableAvailabilityZones(this ICakeContext context, string loadBalancer, LoadBalancingSettings settings)
        {
            return context.CreateManager().DisableAvailabilityZones(loadBalancer, EC2Metadata.AvailabilityZone.Split(','), settings);
        }

        /// <summary>
        /// Removes the specified Availability Zones from the set of Availability Zones for the specified load balancer.
        /// There must be at least one Availability Zone registered with a load balancer at all times. After an Availability Zone is removed, 
        /// all instances registered with the load balancer that are in the removed Availability Zone go into the OutOfService state. 
        /// Then, the load balancer attempts to equally balance the traffic among its remaining Availability Zones.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="loadBalancer">The name associated with the load balancer.</param>
        /// <param name="zones">The Availability Zones to remove from the load balancer.</param>
        /// <param name="settings">The <see cref="LoadBalancingSettings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("ElasticLoadBalancing")]
        public static bool DisableAvailabilityZones(this ICakeContext context, string loadBalancer, string zones, LoadBalancingSettings settings)
        {
            return context.CreateManager().DisableAvailabilityZones(loadBalancer, zones.Split(','), settings);
        }

        /// <summary>
        /// Removes the specified Availability Zones from the set of Availability Zones for the specified load balancer.
        /// There must be at least one Availability Zone registered with a load balancer at all times. After an Availability Zone is removed, 
        /// all instances registered with the load balancer that are in the removed Availability Zone go into the OutOfService state. 
        /// Then, the load balancer attempts to equally balance the traffic among its remaining Availability Zones.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="loadBalancer">The name associated with the load balancer.</param>
        /// <param name="zones">The Availability Zones to remove from the load balancer.</param>
        /// <param name="settings">The <see cref="LoadBalancingSettings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("ElasticLoadBalancing")]
        public static bool DisableAvailabilityZones(this ICakeContext context, string loadBalancer, IList<string> zones, LoadBalancingSettings settings)
        {
            return context.CreateManager().DisableAvailabilityZones(loadBalancer, zones, settings);
        }
    }
}
