## DTO Pattern analysis

This repository contains code to demonstrate the usage of DTO pattern aided by Automapper

## Build and run codebase locally

1. Build the code using the following command

   ```
   dotnet build
   ```

2. The required configuration to run the codebase in vscode is already setup

3. Run and debug using `vscode` .NET Core Launch (web) configuration

## Points of interest

1. Usage of domain models as much as possible in all endpoints (request values, url paths)

2. If the domain models are extensive, we can make of the data transfer objects

3. `Models\DTOs\Incoming` could contain the dtos for constructing API input requests
   `Models\DTOs\Outgoing` could contain the dtos for consructing responses

4. Automapper or any possible mapper could be used to manage the mapping of input request DTOs to domain model on the server side

5. The entire reponsiblity of domain model construction should be delegated to the server side
