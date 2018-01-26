#region Using Statements
using Amazon;
using Amazon.Runtime;
#endregion



namespace Cake.AWS.ElasticLoadBalancing
{
    /// <summary>
    /// The settings to use with download requests to Amazon ElasticLoadBalancing
    /// </summary>
    public class LoadBalancingSettings
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="LoadBalancingSettings" /> class.
        /// </summary>
        public LoadBalancingSettings()
        {
            this.Region = RegionEndpoint.EUWest1;
        }
        #endregion





        #region Properties
        /// <summary>
        /// The AWS Access Key ID
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// The AWS Secret Access Key.
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// The AWS Session Token, if using temporary credentials.
        /// </summary>
        public string SessionToken { get; set; }

        internal AWSCredentials Credentials { get; set; }



        /// <summary>
        /// The endpoints available to AWS clients.
        /// </summary>
        public RegionEndpoint Region { get; set; }
        #endregion
    }
}
