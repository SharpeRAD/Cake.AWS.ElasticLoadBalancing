#region Using Statements
using System;
using System.IO;
using System.Collections.Generic;

using Cake.Core;
using Cake.Core.IO;
using Cake.Testing;
#endregion



namespace Cake.AWS.ElasticLoadBalancing.Tests
{
    internal static class CakeHelper
    {
        #region Methods
        public static ICakeEnvironment CreateEnvironment()
        {
            var environment = FakeEnvironment.CreateWindowsEnvironment();
            environment.WorkingDirectory = Directory.GetCurrentDirectory();
            environment.WorkingDirectory = environment.WorkingDirectory.Combine("../../../");

            return environment;
        }



        public static ILoadBalancingManager CreateTransferManager()
        {
            return new LoadBalancingManager(CakeHelper.CreateEnvironment(), new DebugLog());
        }
        #endregion
    }
}
