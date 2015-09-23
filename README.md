# Cake.AWS.ElasticLoadBalancing
Cake Build addon for configuring Amazon Elastic Load Balancers

[![Build status](https://ci.appveyor.com/api/projects/status/bg004fntkfkjji83?svg=true)](https://ci.appveyor.com/project/PhillipSharpe/cake-services)

[![cakebuild.net](https://img.shields.io/badge/WWW-cakebuild.net-blue.svg)](http://cakebuild.net/)

[![Join the chat at https://gitter.im/cake-build/cake](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/cake-build/cake?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)



## Implemented functionality

* Register Instances
* Deregister Intances



## Referencing

Cake.AWS.ElasticLoadBalancing is available as a nuget package from the package manager console:

```csharp
Install-Package Cake.AWS.ElasticLoadBalancing
```

or directly in your build script via a cake addin:

```csharp
#addin "Cake.AWS.ElasticLoadBalancing"
```



## Usage

```csharp
#addin "Cake.AWS.ElasticLoadBalancing"


Task("Register-Instances")
    .Description("Adds new instances to the load balancer.")
    .Does(() =>
{
    RegisterLoadBalancerInstances("LoadBlanerName", "instance1,instance2,instance3");
});

Task("Deregister-Instances")
    .Description("Deregisters instances from the load balancer.")
    .Does(() =>
{
    DeregisterLoadBalancerInstances("LoadBlanerName", "instance1,instance2,instance3");
});


RunTarget("Register-Instances");
```



## Example

A complete Cake example can be found [here](https://github.com/SharpeRAD/Cake.AWS.ElasticLoadBalancing/blob/master/test/build.cake)
