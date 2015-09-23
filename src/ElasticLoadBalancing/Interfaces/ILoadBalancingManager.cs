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
        #region Functions (2)
            /// <summary>
            /// Adds new instances to the load balancer.
            /// Once the instance is registered, it starts receiving traffic and requests from the load balancer. 
            /// Any instance that is not in any of the Availability Zones registered for the load balancer will be moved to the OutOfService state. 
            /// It will move to the InService state when the Availability Zone is added to the load balancer.
            /// </summary>
            /// <param name="loadBalancer">The name associated with the load balancer.</param>
            /// <param name="instances">A list of instance IDs that should be registered with the load balancer.</param>
            /// <param name="settings">The <see cref="LoadBalancingSettings"/> used during the request to AWS.</param>
            void RegisterInstances(string loadBalancer, IList<string> instances, LoadBalancingSettings settings);

            /// <summary>
            /// Removes instances from the load balancer. Once the instance is deregistered, it will stop receiving traffic from the load balancer. 
            /// </summary>
            /// <param name="loadBalancer">The name associated with the load balancer.</param>
            /// <param name="instances">A list of instance IDs that should be deregistered with the load balancer.</param>
            /// <param name="settings">The <see cref="LoadBalancingSettings"/> used during the request to AWS.</param>
            void DeregisterInstances(string loadBalancer, IList<string> instances, LoadBalancingSettings settings);
        #endregion
    }
}
