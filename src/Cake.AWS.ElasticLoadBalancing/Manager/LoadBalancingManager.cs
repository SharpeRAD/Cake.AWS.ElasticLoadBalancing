#region Using Statements
using System;
using System.Collections.Generic;
using System.Net;

using Cake.Core;
using Cake.Core.Diagnostics;

using Amazon.ElasticLoadBalancing;
using Amazon.ElasticLoadBalancing.Model;
#endregion



namespace Cake.AWS.ElasticLoadBalancing
{
    /// <summary>
    /// Provides a high level utility for managing transfers to and from Amazon S3.
    /// It makes extensive use of Amazon S3 multipart uploads to achieve enhanced throughput, 
    /// performance, and reliability. When uploading large files by specifying file paths 
    /// instead of a stream, TransferUtility uses multiple threads to upload multiple parts of 
    /// a single upload at once. When dealing with large content sizes and high bandwidth, 
    /// this can increase throughput significantly.
    /// </summary>
    public class LoadBalancingManager : ILoadBalancingManager
    {
        #region Fields
        private readonly ICakeEnvironment _Environment;
        private readonly ICakeLog _Log;
        #endregion





        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="LoadBalancingManager" /> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="log">The log.</param>
        public LoadBalancingManager(ICakeEnvironment environment, ICakeLog log)
        {
            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }
            if (log == null)
            {
                throw new ArgumentNullException("log");
            }

            _Environment = environment;
            _Log = log;
        }
        #endregion





        #region Methods
        private AmazonElasticLoadBalancingClient CreateClient(LoadBalancingSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
                
            if (settings.Region == null)
            {
                throw new ArgumentNullException("settings.Region");
            }

            if (settings.Credentials == null)
            {
                if (String.IsNullOrEmpty(settings.AccessKey))
                {
                    throw new ArgumentNullException("settings.AccessKey");
                }
                if (String.IsNullOrEmpty(settings.SecretKey))
                {
                    throw new ArgumentNullException("settings.SecretKey");
                }

                return new AmazonElasticLoadBalancingClient(settings.AccessKey, settings.SecretKey, settings.Region);
            }
            else
            {
                return new AmazonElasticLoadBalancingClient(settings.Credentials, settings.Region);
            }
        }



        /// <summary>
        /// Adds new instances to the load balancer.
        /// Once the instance is registered, it starts receiving traffic and requests from the load balancer. 
        /// Any instance that is not in any of the Availability Zones registered for the load balancer will be moved to the OutOfService state. 
        /// It will move to the InService state when the Availability Zone is added to the load balancer.
        /// </summary>
        /// <param name="loadBalancer">The name associated with the load balancer.</param>
        /// <param name="instances">A list of instance IDs that should be registered with the load balancer.</param>
        /// <param name="settings">The <see cref="LoadBalancingSettings"/> used during the request to AWS.</param>
        public bool RegisterInstances(string loadBalancer, IList<string> instances, LoadBalancingSettings settings)
        {
            if (String.IsNullOrEmpty(loadBalancer))
            {
                throw new ArgumentNullException("loadBalancer");
            }
            if ((instances == null) || (instances.Count == 0))
            {
                throw new ArgumentNullException("instances");
            }



            //Create Request
            AmazonElasticLoadBalancingClient client = this.CreateClient(settings);
            RegisterInstancesWithLoadBalancerRequest request = new RegisterInstancesWithLoadBalancerRequest();

            request.LoadBalancerName = loadBalancer;

            foreach (string instance in instances)
            {
                request.Instances.Add(new Instance(instance));
            }



            //Check Response
            RegisterInstancesWithLoadBalancerResponse response = client.RegisterInstancesWithLoadBalancer(request);

            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                _Log.Verbose("Successfully registered instances '{0}'", string.Join(",", instances));
                return true;
            }
            else
            {
                _Log.Error("Failed to register instances '{0}'", string.Join(",", instances));
                return false;
            }
        }

        /// <summary>
        /// Removes instances from the load balancer. Once the instance is deregistered, it will stop receiving traffic from the load balancer. 
        /// </summary>
        /// <param name="loadBalancer">The name associated with the load balancer.</param>
        /// <param name="instances">A list of instance IDs that should be deregistered with the load balancer.</param>
        /// <param name="settings">The <see cref="LoadBalancingSettings"/> used during the request to AWS.</param>
        public bool DeregisterInstances(string loadBalancer, IList<string> instances, LoadBalancingSettings settings)
        {
            if (String.IsNullOrEmpty(loadBalancer))
            {
                throw new ArgumentNullException("loadBalancer");
            }
            if ((instances == null) || (instances.Count == 0))
            {
                throw new ArgumentNullException("instances");
            }



            //Create Request
            AmazonElasticLoadBalancingClient client = this.CreateClient(settings);
            DeregisterInstancesFromLoadBalancerRequest request = new DeregisterInstancesFromLoadBalancerRequest();

            request.LoadBalancerName = loadBalancer;

            foreach (string instance in instances)
            {
                request.Instances.Add(new Instance(instance));
            }



            //Check Response
            DeregisterInstancesFromLoadBalancerResponse response = client.DeregisterInstancesFromLoadBalancer(request);

            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                _Log.Verbose("Successfully deregistered instances '{0}'", string.Join(",", instances));
                return true;
            }
            else
            {
                _Log.Error("Failed to deregister instances '{0}'", string.Join(",", instances));
                return false;
            }
        }



        /// <summary>
        ///  Adds the specified Availability Zones to the set of Availability Zones for the specified load balancer.
        ///  The load balancer evenly distributes requests across all its registered Availability Zones that contain instances.
        /// </summary>
        /// <param name="loadBalancer">The name associated with the load balancer.</param>
        /// <param name="zones">The Availability Zones to add to the load balancer.</param>
        /// <param name="settings">The <see cref="LoadBalancingSettings"/> used during the request to AWS.</param>
        public bool EnableAvailabilityZones(string loadBalancer, IList<string> zones, LoadBalancingSettings settings)
        {
            if (String.IsNullOrEmpty(loadBalancer))
            {
                throw new ArgumentNullException("loadBalancer");
            }
            if ((zones == null) || (zones.Count == 0))
            {
                throw new ArgumentNullException("zones");
            }



            //Create Request
            AmazonElasticLoadBalancingClient client = this.CreateClient(settings);
            EnableAvailabilityZonesForLoadBalancerRequest request = new EnableAvailabilityZonesForLoadBalancerRequest();
            
            request.LoadBalancerName = loadBalancer;

            foreach (string zone in zones)
            {
                request.AvailabilityZones.Add(zone);
            }



            //Check Response
            EnableAvailabilityZonesForLoadBalancerResponse response = client.EnableAvailabilityZonesForLoadBalancer(request);

            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                _Log.Verbose("Successfully enabled zones '{0}'", string.Join(",", zones));
                return true;
            }
            else
            {
                _Log.Error("Failed to enabled zones '{0}'", string.Join(",", zones));
                return false;
            }
        }

        /// <summary>
        /// Removes the specified Availability Zones from the set of Availability Zones for the specified load balancer.
        /// There must be at least one Availability Zone registered with a load balancer at all times. After an Availability Zone is removed, 
        /// all instances registered with the load balancer that are in the removed Availability Zone go into the OutOfService state. 
        /// Then, the load balancer attempts to equally balance the traffic among its remaining Availability Zones.
        /// </summary>
        /// <param name="loadBalancer">The name associated with the load balancer.</param>
        /// <param name="zones">The Availability Zones to remove from the load balancer.</param>
        /// <param name="settings">The <see cref="LoadBalancingSettings"/> used during the request to AWS.</param>
        public bool DisableAvailabilityZones(string loadBalancer, IList<string> zones, LoadBalancingSettings settings)
        {
            if (String.IsNullOrEmpty(loadBalancer))
            {
                throw new ArgumentNullException("loadBalancer");
            }
            if ((zones == null) || (zones.Count == 0))
            {
                throw new ArgumentNullException("zones");
            }



            //Create Request
            AmazonElasticLoadBalancingClient client = this.CreateClient(settings);
            DisableAvailabilityZonesForLoadBalancerRequest request = new DisableAvailabilityZonesForLoadBalancerRequest();

            request.LoadBalancerName = loadBalancer;

            foreach (string zone in zones)
            {
                request.AvailabilityZones.Add(zone);
            }



            //Check Response
            DisableAvailabilityZonesForLoadBalancerResponse response = client.DisableAvailabilityZonesForLoadBalancer(request);

            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                _Log.Verbose("Successfully disabled zones '{0}'", string.Join(",", zones));
                return true;
            }
            else
            {
                _Log.Error("Failed to disabled zones '{0}'", string.Join(",", zones));
                return false;
            }
        }
        #endregion
    }
}