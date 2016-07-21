# Cake.AWS.ElasticLoadBalancing
Cake Build addin for configuring Amazon Elastic Load Balancers

[![Build status](https://ci.appveyor.com/api/projects/status/w86dpcm8320m79ru?svg=true)](https://ci.appveyor.com/project/SharpeRAD/cake-aws-elasticloadbalancing)

[![cakebuild.net](https://img.shields.io/badge/WWW-cakebuild.net-blue.svg)](http://cakebuild.net/)

[![Join the chat at https://gitter.im/cake-build/cake](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/cake-build/cake)



## Table of contents

1. [Implemented functionality](https://github.com/SharpeRAD/Cake.AWS.ElasticLoadBalancing#implemented-functionality)
2. [Referencing](https://github.com/SharpeRAD/Cake.AWS.ElasticLoadBalancing#referencing)
3. [Usage](https://github.com/SharpeRAD/Cake.AWS.ElasticLoadBalancing#usage)
4. [Example](https://github.com/SharpeRAD/Cake.AWS.ElasticLoadBalancing#example)
5. [Plays well with](https://github.com/SharpeRAD/Cake.AWS.ElasticLoadBalancing#plays-well-with)
6. [License](https://github.com/SharpeRAD/Cake.AWS.ElasticLoadBalancing#license)
7. [Share the love](https://github.com/SharpeRAD/Cake.AWS.ElasticLoadBalancing#share-the-love)



## Implemented functionality

* Register Instances
* Deregister Instances
* Uses AWS fallback credentials (app.config / web.config file, SDK store or credentials file, environment variables, instance profile)



## Referencing

[![NuGet Version](http://img.shields.io/nuget/v/Cake.AWS.ElasticLoadBalancing.svg?style=flat)](https://www.nuget.org/packages/Cake.AWS.ElasticLoadBalancing/)

Cake.AWS.ElasticLoadBalancing is available as a nuget package from the package manager console:

```csharp
Install-Package Cake.AWS.ElasticLoadBalancing
```

or directly in your build script via a cake addin directive:

```csharp
#addin "Cake.AWS.ElasticLoadBalancing"
```



## Usage

```csharp
#addin "Cake.AWS.ElasticLoadBalancing"

LoadBalancingSettings settings = Context.CreateLoadBalancingSettings();



Task("Register-Instances")
    .Description("Adds new instances to the load balancer.")
    .Does(() =>
{
    RegisterLoadBalancerInstances("LoadBlanerName", "instance1,instance2,instance3", settings);
});

Task("Deregister-Instances")
    .Description("Deregisters instances from the load balancer.")
    .Does(() =>
{
    DeregisterLoadBalancerInstances("LoadBlanerName", "instance1,instance2,instance3", settings);
});

Task("Deregister-Instances-Fallback")
    .Description("Deregisters instances from the load balancer, using AWS Fallback credentials")
    .Does(() =>
{
    DeregisterLoadBalancerInstances("LoadBlanerName", "instance1,instance2,instance3", Context.CreateLoadBalancingSettings());
});

RunTarget("Register-Instances");
```



## Example

A complete Cake example can be found [here](https://github.com/SharpeRAD/Cake.AWS.ElasticLoadBalancing/blob/master/test/build.cake).



## Plays well with

If your routing traffic to EC2 instances its worth checking out [Cake.AWS.EC2](https://github.com/SharpeRAD/Cake.AWS.EC2) or if your using Route53 as your DNS server check out [Cake.AWS.Route53](https://github.com/SharpeRAD/Cake.AWS.Route53).

If your looking for a way to trigger cake tasks based on windows events or at scheduled intervals then check out [CakeBoss](https://github.com/SharpeRAD/CakeBoss).



## License

Copyright (c) 2015 - 2016 Phillip Sharpe

Cake.AWS.ElasticLoadBalancing is provided as-is under the MIT license. For more information see [LICENSE](https://github.com/SharpeRAD/Cake.AWS.ElasticLoadBalancing/blob/master/LICENSE).



## Share the love

If this project helps you in anyway then please :star: the repository.
