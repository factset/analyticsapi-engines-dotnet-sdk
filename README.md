# analyticsapi-engines-dotnet-sdk

## Overview
API client library to leverage Factset's Analytics API in C#. Each API version directory contains its respective Analytics API implementation.

**`Engines`** - C# library for Engines API. It is developed using [open-api-generator](https://github.com/OpenAPITools/openapi-generator).

**`Utilities`** - Contains the EnginesAPI's OpenAPI schema (openapi-schema.json), OpenAPI's csharp edited templates, configuration file (openapi-generator-config.json) and End-to-End tests of library. 

#### Recommended framework
* .Net Standard 2.0

#### Current versions
* API_VERSION - 2
* PACKAGE_VERSION - 2.0.0

## Steps to install library on Visual Studio
* Go to `Tools` -> `Nuget Package Manager` -> `Manage Nuget Packages for Solution`.
* Search for `FactSet.AnalyticsAPI.Engines.vAPI_VERSION.*.*.*.nupkg` and install it.

## Generate library
To customize the OpenAPI generator options and generate the library. Please go through [Open API](https://swagger.io/docs/specification/about/) and [open-api-generator](https://github.com/OpenAPITools/openapi-generator) for more details.

### Pre-requisites
* Install [Java SDK8 64 bit version](http://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html).
* Install Visual Studio.
* Clone this `analyticsapi-engines-dotnet-sdk` repository.
* Move into the `analyticsapi-engines-dotnet-sdk/vAPI_VERSION/Utilities/codegen` folder and run the `download-codegen.bat` file by double clicking it (for downloading the openapi-generator-cli.jar).

### To update and build the library
* Move to the `analyticsapi-engines-dotnet-sdk/vAPI_VERSION` location.
* Increment the package version in `Utilities/openapi-generator-config.json`.
* Delete all the files in the `Engines` folder excluding `.openapi-generator-ignore` file. 
* Replace vAPI_VERSION and PACKAGE_VERSION in the below command with the latest values and run it.
```
javac -classpath Utilities/codegen/*; Utilities/codegen/CustomCSharpNetCoreClientCodegen.java
java -DmodelTests=false -DapiTests=false -classpath Utilities/codegen/;Utilities/codegen/*; org.openapitools.codegen.OpenAPIGenerator generate --generator-name CustomCSharpNetCoreClientCodegen --input-spec Utilities/codegen/openapi-schema.json --output EnginesAPI --config Utilities/codegen/openapi-generator-config.json --http-user-agent $http_user_agent/vAPI_VERSION/PACKAGE_VERSION/csharp --template-dir Utilities/codegen/templates --skip-validate-spec
```
* Build the project by right clicking on the project name.

### Run End-to-End tests

#### Running the Test Cases using Visual Studio
* Open the Visual Studio.
* Goto File-> Open-> Project/Solution.
* Open `Engines/src/FactSet.AnalyticsAPI.Engines.v*.sln` and build the project.
* Then, open `Engines/src/FactSet.AnalyticsAPI.Engines.v*.Test.sln` and build the tests project.
* Set the below environment variables using `Package Manager Console`.
```
$env:ANALYTICS_API_USERNAME_SERIAL = "username-serial"
$env:ANALYTICS_API_PASSWORD = "apikey" // Generated on developer portal
```
* For running test cases, Goto `Test` -> `Windows` -> `Test Explorer`.
* Test Explorer contains the Test Cases for the Api.
* Run the test case by right clicking it and choose for `Run Selected Tests` option.