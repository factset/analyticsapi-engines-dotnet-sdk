5.5.0 (16/01/2023)

Supported API versions:

* v3: [pa,spar,vault,pub,fi,axp,fpo,afi,npo,bpm,quant],v1:[fiab]

Summmary:
* Supporting new functionalities in pa,spar,vault,pub,quant and fi.

Functionality Additions:
* New Parameters are added in the FI Request.
* 413 status code is added to Quant Reponse.
* 'Warnings' are added as an enhancement to quant unit status response object.
* In the Error response object new fields - code and title are added.
* Added new end point for SPAR Product to get component details by Id.

Breaking changes:
* No changes.

Bug Fixes:
* Removed requiredfield attribute for pagenumber field parameter in GetAllCalculations End Point for pa,spar,vault,pub and quant.
* Removed defaults values when the parameter field is required for look up end points for pa,spar,vault and strategy end points.
* Updated the schema for GetAllCalculations End Point for pa,spar,vault,pub and quant.

-----------------------

5.4.0 (13/12/2022)

Supported API versions:

* v3: [pa,spar,vault,pub,fi,axp,fpo,afi,npo,bpm,quant],v1:[fiab]

Summmary:
* Supporting new functionalities in FI and Quant.

Functionality Additions:
* Added new property "IsArrayReturnType" for FQL expression in Quant Request.
* Added new property "Structured Products" in FI Request.

Breaking changes:
* No changes.

Bug Fixes:
* No changes.

-----------------------

5.3.0 (14/06/2022)

Supported API versions:

* v3: [pa,spar,vault,pub,fi,axp,fpo,afi,npo,bpm,quant],v1:[fiab]

Summmary:
* Supporting new functionalities in pa,spar,vault,pub,quant.

Functionality Additions:
* Supporting new features/functionalities of the FI API.
* Added new end point for GroupingFrequencies.
* Added new endpoint for Pricing Sources.

Breaking changes:
* No changes.

Bug Fixes:
* No changes.

-----------------------

5.2.0 (24/03/2022)

Supported API versions:

* v3: [pa,spar,vault,pub,fi,axp,fpo,afi,npo,bpm,quant],v1:[fiab]

Summmary:
* New Functionality Additions.

Functionality Additions:
* Added support for MarketEnviornment in the FI calculation parameters.
* Added FI Discount curves endpoint.
* Added support for overrideUniversalScreenCalendar for Quant Dates.

Breaking changes:
* No changes.

Bug Fixes:
* No changes.

-----------------------

5.1.1 (25/02/2022)

Supported API versions:

* v3: [pa,spar,vault,pub,fi,axp,fpo,afi,npo,bpm,quant],v1:[fiab]

Summmary:
* Using the latest version of Stach extensions(internal dependency).

Functionality Additions:
* NA.

Breaking changes:
* No changes.

Bug Fixes:
* No changes.

-----------------------

5.1.0 (07/01/2022)

Supported API versions:

* v3: [pa,spar,vault,pub,fi,axp,fpo,afi,npo,bpm,quant],v1:[fiab]

Summmary:
* Supporting new functionalities in SPAR, FI, Quant APIs.

Functionality Additions:
* Supporting new features/functionalities of the FI API.
* Supporting Currency Iso in the SPAR API.
* Supporting Component Manager API.

Breaking changes:
* No changes

Bug Fixes:
* Fixing the FPO POST body.
* Fixing the Quant API.

-----------------------

5.0.0 (07/12/2021)

Supported API versions:

* v3: [pa,spar,vault,pub,fi,axp,fpo,afi,npo,bpm,quant],v1:[fiab]

Summmary:
* Add support for v3 API's

Breaking changes:
* No changes

Bug Fixes:
* No changes

-----------------------

4.1.1 (05/06/2021)

Supported API versions:
* v2

Summary:
* Adding bug fix for column names 

Breaking changes:
* No Changes

Functionality Additions:
* No Changes

Bug Fixes:
* Fixing the empty column names for dimension columns
* Fixing the order of dimensions column

-----------------------

4.1.0 (11/17/2020)

Supported API versions:
* v2

Summary:
* Adding FIAB, Fixed Income and AXP Optimizer API support

Breaking changes:
* No Changes

Functionality Additions:
* Adding FIAB, Fixed Income and AXP Optimizer API support

Bug Fixes:
* No Changes

-----------------------

4.0.0 (08/27/2020)

Supported API versions:
* v2

Summary:
* Adding support for new features

Breaking changes:
* Additional parameter in calculation object constructor
* Remove points property from CalculationStatus and CalculationStatusSummary

Functionality Additions:
* Publisher API calculation and document lookup
* New componentdetail parameter for PA and Vault calculation
* Interactive endpoints for PA, SPAR and Vault APIs

Bug Fixes:
* No changes

-----------------------

3.0.0 (12/02/2019)

Supported API versions:
* v2
 
Summary:
* Making SDK independent of the API version.
 
Breaking changes:
* API version is removed from the namespace of all classes.
 
Functionality Additions:
* No changes
 
Bug Fixes:
* Fixed a bug to add Accept header correctly in UtilityApi's GetByUrlAsyncWithHttpInfo method.

-----------------------

v2-2.0.0 (09/27/2019)

Supported API versions:
* v2

Summary:
* Update class and property names.

Breaking changes:

* Class Name
  * OutstandingCalculation -> CalculationStatusSummary
  * CalculationParameters -> Calculation
  * OutstandingCalculations -> CalculationStatus (class)
  * CalculationStatus (enum) -> UnitStatus
  * Calculation -> CalculationUnitStatus
  * AccountList -> AccountDirectories
  * ComponentListEntity -> ComponentSummary
  * PAComponentEntity -> PAComponent
  * VaultComponentEntity -> VaultComponent
  * ConfigurationItem -> VaultConfigurationSummary
  * ConfigurationRoot -> VaultConfiguration
  * DateSettings -> DateParametersSummary
  * DocumentList -> DocumentDirectories
  * ComponentDateSettings (pa) -> PADateParameters
  * ComponentDateSettings (vault) -> VaultDateParameters

* Properties
  * pointscount -> points
  * defaultAccounts (ComponentAccount) -> accounts (PAIdentifier)
  * defaultBenchmarks (ComponentBenchmark) -> benchmarks (PAIdentifier)
  * defaultAccount (VaultCalculationAccount) -> accounts (VaultIdentifier)
  * defaultBenchmark (ComponentBenchmark) -> benchmark (VaultIdentifier)
  * currency (PAComponentEntity/VaultComponentEntity) -> currencyisocode (PAComponent/VaultComponent)
  
* Methods
  * getAllCalculationStatusSummaries -> getCalculationStatusSummaries
  * getAllPAColumnStatistics -> getPAColumnStatistics
  * getAllPAColumns -> getPAColumns
  * getPAColumn -> getPAColumnById
  * getAllPACurrencies -> getPACurrencies
  * getAllPAFrequencies -> getPAFrequencies
  * getAllSPARFrequencies -> getSPARFrequencies
  * getAllVaultFrequencies -> getVaultFrequencies
  * getAllPAGroups -> getPAGroups
  * getAllCalculations -> getAllCalculationStatusSummaries
  * getCalculationById -> getCalculationStatusById

* Headers
  * X-FactSet-Api-PointsCount-Limit -> X-FactSet-Api-Points-Limit
  * X-FactSet-Api-PointsCount-Remaining -> X-FactSet-Api-Points-Remaining
  
* Currencies
  * Change response from List to Dictionary with currencyisocode as key
  
Functionality Additions:
* New Property snapshot in PAComponent & VaultComponent.

Bug Fixes:
* No changes.

-----------------------

v2-1.0.0 (08/30/2019)

Supported API versions:
* v2
 
Summary:
* Releasing first version of Engines API(v2).
 
Breaking changes:
* No changes
 
Functionality Additions:
* Supports PA, SPAR and Vault calculations.
 
Bug Fixes:
* No changes