#region Using Statements
    using System;
    using System.Collections.Generic;
#endregion



namespace Cake.AWS.ElasticLoadBalancing
{
    /// <summary>
    /// Used to access Amazon Elastic Load Balancers. 
    /// </summary>
    public interface ILoadBalancingManager
    {
        #region Functions (4)
            /// <summary>
            /// Adds new instances to the load balancer.
            /// Once the instance is registered, it starts receiving traffic and requests from the load balancer. 
            /// Any instance that is not in any of the Availability Zones registered for the load balancer will be moved to the OutOfService state. 
            /// It will move to the InService state when the Availability Zone is added to the load balancer.
            /// </summary>
            /// <param name="loadBalancer">The name associated with the load balancer.</param>
            /// <param name="instances">A list of instance IDs that should be registered with the load balancer.</param>
            /// <param name="settings">The <see cref="LoadBalancingSettings"/> used during the request to AWS.</param>
            bool RegisterInstances(string loadBalancer, IList<string> instances, LoadBalancingSettings settings);

            /// <summary>
            /// Removes instances from the load balancer. Once the instance is deregistered, it will stop receiving traffic from the load balancer. 
            /// </summary>
            /// <param name="loadBalancer">The name associated with the load balancer.</param>
            /// <param name="instances">A list of instance IDs that should be deregistered with the load balancer.</param>
            /// <param name="settings">The <see cref="LoadBalancingSettings"/> used during the request to AWS.</param>
            bool DeregisterInstances(string loadBalancer, IList<string> instances, LoadBalancingSettings settings);



            /// <summary>
            ///  Adds the specified Availability Zones to the set of Availability Zones for the specified load balancer.
            ///  The load balancer evenly distributes requests across all its registered Availability Zones that contain instances.
            /// </summary>
            /// <param name="loadBalancer">The name associated with the load balancer.</param>
            /// <param name="zones">The Availability Zones to add to the load balancer.</param>
            /// <param name="settings">The <see cref="LoadBalancingSettings"/> used during the request to AWS.</param>
            bool EnableAvailabilityZones(string loadBalancer, IList<string> zones, LoadBalancingSettings settings);


            /// <summary>
            /// Removes the specified Availability Zones from the set of Availability Zones for the specified load balancer.
            /// There must be at least one Availability Zone registered with a load balancer at all times. After an Availability Zone is removed, 
            /// all instances registered with the load balancer that are in the removed Availability Zone go into the OutOfService state. 
            /// Then, the load balancer attempts to equally balance the traffic among its remaining Availability Zones.
            /// </summary>
            /// <param name="loadBalancer">The name associated with the load balancer.</param>
            /// <param name="zones">The Availability Zones to remove from the load balancer.</param>
            /// <param name="settings">The <see cref="LoadBalancingSettings"/> used during the request to AWS.</param>
            bool DisableAvailabilityZones(string loadBalancer, IList<string> zones, LoadBalancingSettings settings);
        #endregion
    }
}
