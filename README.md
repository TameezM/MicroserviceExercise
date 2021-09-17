# Microservice Exercise
This a anonymous microservice exercise. 

To test invoke swagger on https://localhost:44343/Swagger or if are using docker use http://localhost:5001/Swagger

Start all services in one go by changing the solution properties so that all the services have started. I have used .Net core 3.1. Hence, to run it, you should use .net core 3.1
As it stands now, for some services IP is mandatory (RDAP) hence give IP address instead of domain name, if you want right response from services.
To test in swagger which will be launched automatically, Use BackEndExc controller post method. Sample input json to use in swagger 
{
  "address": "103.48.71.101",
  "services": [
    "GeoIP","RDAP","ReverseDNS","Ping"
  ]
}
or
{
  "address": "103.48.71.101",
  "services": null
}

Docker support  is done for Linux containers running on Windows. If you are running on MAC, you have make appropriate environment settings.
Please install appropriate prerquisites to run in docker. 


TODO:

Due to time constraints, Instead of ReverseDNS I did DNSLookup as I could not get free Reverse DNS service after spending an hour. I returned json string for this service due to time constraints. A model design demo is done for geoIP and RDAP Service. But I think in this model a interested properties should be kept as DTO Model 
For single payload, we need to remove nested properties at the aggregate service wherever possible and trim down unwanted properties, which I could not work due to time constraints and properties which we are of interest.

As the reqs stand now, interfaces designed will work, once I get more clarity on it we can think of minimizing code or write better interfaces.

For Ping service, I returned success as I could not get free REST endpoint to query, but that’s not big development effort to integrate once we get free ping REST endpoint.

For nuget package, we have to select "generate nuget package option in project properties, which we can do that.
For application insights we need to configure it.

Introduce Identity for user authentication and authorization and roles management.
Introduce API gateway like ocelot or Azure API gateway.
Introduce unit testing mechanism for each Microservice.
Introduce Health checks and better logging mechanism. Serilog recommended.



