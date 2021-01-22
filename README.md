# WebApiVersoning

Initial URL
http://localhost:32042/api/Users/1

Add Nuget Package : Microsoft.AspNetCore.Mvc.Versioning
Try below url with aditional parameter in querystring "?api-version=1.0"
Url after adding package and configuration 
http://localhost:32042/api/Users/1?api-version=1.0

URL Once we configure default version if not spacefied.

http://localhost:32042/api/Users/1

Define version with accept Header

http://localhost:32042/api/Users/1
Headers : Accept = application/json;version=2.0

Configure Api Service for accepting version info as seprate header
http://localhost:32042/api/Users/1
Headers: X-Version = 2.0

Api version as user path
http://localhost:32042/api/v2.0/Users/1
