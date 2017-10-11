//////////////////////////////////////////////////////////////////////
// IMPORTS
//////////////////////////////////////////////////////////////////////

#addin "Cake.Slack"
#addin "Cake.ReSharperReports"
#addin "Cake.AWS.S3"
#addin "Cake.FileHelpers"

#tool "ReportUnit"
#tool "JetBrains.ReSharper.CommandLineTools"





//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");





//////////////////////////////////////////////////////////////////////
// SOLUTION
//////////////////////////////////////////////////////////////////////

// Name
var appName = "Cake.AWS.ElasticLoadBalancing";

// Projects
var projectNames = new List<string>() 
{ 
    "Cake.AWS.ElasticLoadBalancing"
};





///////////////////////////////////////////////////////////////////////////////
// LOAD
///////////////////////////////////////////////////////////////////////////////

#load "./build/scripts/load.cake"