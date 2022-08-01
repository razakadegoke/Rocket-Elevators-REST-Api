# ROCKET ELEVATOR API

This API is deploy on Microsoft Azure Services and create with ASP.NET Core 6

You can test the end-point using the curl command on the terminal or in the browser.

### Exemple:
    
* Terminal:

```bash
    curl -X 'GET' \ 'https://rocketelevators-api.azurewebsites.net/api/Building'
```
* In the browser using Swagger:

    https://rocketelevators-api.azurewebsites.net/swagger/index.html



## Exemple of endpoint list : 

Retrieving the current status of a specific Battery :

    https://rocketelevators-api.azurewebsites.net/api/Battery/1

Changing the status of a specific Battery :

    https://rocketelevators-api.azurewebsites.net/api/Battery/1/Active

Retrieving the current status of a specific Column :

    https://rocketelevators-api.azurewebsites.net/api/Column/1

Changing the status of a specific Column :

    https://rocketelevators-api.azurewebsites.net/api/Column/1/Active

Retrieving the current status of a specific Elevator :

    https://rocketelevators-api.azurewebsites.net/api/Elevator/1

Changing the status of a specific Elevator :

    https://rocketelevators-api.azurewebsites.net/api/Column/1/Active

Retrieving a list of Elevators that are not in operation at the time of the request :

    https://rocketelevators-api.azurewebsites.net/api/Elevator

Retrieving a list of Buildings that contain at least one battery, column or elevator requiring intervention :

    https://rocketelevators-api.azurewebsites.net/api/Building

Retrieving a list of Leads created in the last 30 days who have not yet become customers. :

    https://rocketelevators-api.azurewebsites.net/api/Lead

Returns all fields of all intervention Request records that do not have a start date and are in "Pending" status.

    https://rocketelevators-api.azurewebsites.net/api//Intervention


****If you want to change the status of the : Batteries, columns and elevators the only possible value are : Active Inactive and Intervention

****if you dont choose thes values it will trow error.

Author : Razak Adegoke And Avinash Gopalakrishnan
