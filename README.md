BeerBrowser


## Architecture

- The web-application is a Single Page Application implemented in vue.js.
Client-side routing has been implemented.
Infinite scroll loading has been used.

- The back-end API is a REST-API implemented in ASP.Net Core. The persistency is using a PostgreSQL database.
It is decomposed in 3 layers: 
  - the Site is responsible for exposing the Rest API. The search API are using pagination.
  - Services implements and exposes the functionality to the site. CQRS principles have been applied with an separation between read and write objects.
  - Data provide entities Nhibernate mapping and migrations. 

## Build instructions

### Set-up

Create an empty PostgreSQL database:

```SQL
CREATE DATABASE beer WITH OWNER = postgres ENCODING = 'UTF8' CONNECTION LIMIT = -1;
```

The connection string to the PostgreSQL can be altered using the `appsettings.json` file, name "ConnectionString"

### Back-End

```bash
dotnet restore
dotnet build
```
### Front-End

```bash
npm install
npm run build
```

For debug:
```bash
npm install
npm run serve
```

When running in debug the front-end application, the back-end url is provided by the .env file.
It is configured to be the default port of the ASP back-end and should work without adjust.

## Libraries used

### Back-End
  - ASP.Net Core 2.2
  - [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) to provide swagger integration of the API
  - [Nhibernate](https://nhibernate.info/), [Fluent Nhibernate](https://github.com/FluentNHibernate/fluent-nhibernate) and [Fluent.Migrator](https://fluentmigrator.github.io/) to handle SQL data
  - [Scrutor](https://github.com/khellang/Scrutor) to simplify dependency injection
  - For tests:
    - [XUnit](https://xunit.net/) as test framework
    - [NSubstitute](https://nsubstitute.github.io/) for mocking
    - [FluentAssertions](https://fluentassertions.com/) for test assertion
    - [AutoFixture](https://github.com/AutoFixture/AutoFixture) to generate random test data

### Front-End

- [vue.js](https://vuejs.org/) as the front-end framework
- [vue router](https://router.vuejs.org/) to handle client-side navigation
- [vuetify](https://vuetifyjs.com/en/) as UI material design library
- [axios](https://github.com/axios/axios) as a ajax library
- [scrollwatch](https://edull24.github.io/ScrollWatch/) to handle lazy-loading on scroll
- [lodash.debounce](https://lodash.com/docs#debounce) to debounce search input updates
