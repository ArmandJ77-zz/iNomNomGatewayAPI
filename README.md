DEPRICATED
======
The iNomnom project was part of an interview process and uses a 3rd party api to get data.
This project is no longer being maintained and has been archived 
-------------------------------------------------------------------------------------------------------------------------------------

# iNomNomGatewayAPI

## Problem Statement
Provides a single interface for the UI when interacting with resources from the Menu Api and External employee api, the gateway also 
provides a JWT token as an added security layer between UI and gateway.

## Domain
The api returns results for a lunch menu and which contains menu items

## Stack
Build ontop of:
- .NetCore 2.2 as the RESTful framework
- Entitiy Framework Core used as the ORM
- Serilog used for logging
- Swagger used for documentation
- Fluentvalidation for dto validation
- Automapper for dto to entity mapping
- Nunit for testing
- RestSharp for api http communication

## Solution
Tests
- Integration tests (Class Library)
  Used to house all the integration tests and the boilerplate required
- Test Objects
  Contains the object mothers and builders user by the Integration Tests
- Integrations 
  - ExternalPythonService
    Used for employee lookups and CRUD operations. Has its own Token based authentication
  - iNomNomMenService
    Used for interaction on the menu items
  - Infrastructure
    Houses the Http Request layer used by the Service projects
- GatewayApi
  Contains the project setup and controllers
- Domain
  Has the handlers, builders, DTOs and mappings generally this contains all the business rules for th API
- Repositories
  Is the Data layer linking the ORM and the database together and is consumed in the Domain.
  Designed a very thin Repository layerand avoided going tinto detail wiht the full
  implementation fo the repository and Unit of work pattern.
