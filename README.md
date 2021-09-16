# MicroserviceExercise
anonymous microservice exercise. To test invoke swagger on https://localhost:44343/Swagger

Start all services in one go by changing the solution properties so that all the services have started.
For now, For some services IP is mandatory hence give IP address instead of domain name, if you want right response from services.

TODO:
Due to time constraints, Instead of ReverseDNS I did DNSLookup as I could not get free reversedns service after spending an hour
I returned json string for this service due to time constraints. A model demo is done for geoIP and RDAP Service. But I think in 
single payload, we need to remove nested proporties at the aggregate service whereever possible and trim down unwanted properties,
which I could not work due to time constraints.

For Ping service, I justed returned success as I could not get free rest endpoint to query, but thats not big development
effort to integrate once we get free ping REST endpoint.


For nuget package, we have "generate nuget package option in project properties, which we can do that.

For applicatin insights we need to configure it.

For docker support, could not integrate it due to system limitations that can be done via Right click project->Add->docker support

For some services IP is mandatory hence give IP address instead of domain name.

