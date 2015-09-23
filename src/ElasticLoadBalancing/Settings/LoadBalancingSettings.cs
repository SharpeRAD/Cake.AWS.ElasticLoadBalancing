#region Using Statements
    using System.Collections.Generic;

    using Amazon;
#endregion



namespace Cake.AWS.ElasticLoadBalancing
{
    /// <summary>
    /// The settings to use with downlad requests to Amazon ElasticLoadBalancing
    /// </summary>
    public class LoadBalancingSettings
    {
        #region Properties (5)
            /// <summary>
            /// The AWS Access Key ID
            /// </summary>
            public string AccessKey { get; set; }

            /// <summary>
            /// The AWS Secret Access Key.
            /// </summary>
            public string SecretKey { get; set; }



            /// <summary>
            /// The endpoints available to AWS clients.
            /// </summary>
            public RegionEndpoint Region { get; set; }

            /// <summary>
            /// Gets or sets the name of the load balancer.
            /// </summary>
            public string Name { get; set; }



            /// <summary>
            /// The IDs of the instances assosiated with the load balancer.
            /// </summary>
            public IList<string> Instances { get; set; }
        #endregion
    }
}
