# Dependency Injection Using Service Extensions

Note: This particular demo uses [Microsoft's default dependency injection provider](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection) with .NET 6.0, but this pattern has also been used successfully with Autofac in .NET Framework 4.X.

## Option #1

Consumer is responsible for managing its own dependencies. Specific implementation can vary, but the gist is that every service binding used in the consuming layer has to be individually declared. This is the status quo.

- Example: [Program.cs Line 43](DiExtensionDemo.Api/Program.cs#L43)

### Pros

- Allows for more granular control at the consumer level -- each consumer can strictly define which service(s) it needs.
- Decouples service layer from dependency injection provider.

### Cons

- Difficult to maintain; tightly couples service package releases to consumer releases.
  - Can be mitigated with unit tests.
- Each individual consumer must be updated when dependency tree changes.
  - Can be mitigated by locking consumers to specific versions, but this only defers configuration changes until an upgrade to services package is needed.
- Violates semantic versioning. When a service has its dependencies updated, consumers must update their own declarations. This is considered a breaking change; therefore, such changes must be published as a new major version to adhere to semantic versioning.

## Option #2

Service package registers its own services. A single helper/extension method is exposed to allow the consumer to register all of its available services.

- Example of Implementation: [ServiceBuilderExtensions.cs Line 14](DiExtensionDemo.Services/Extensions/ServiceBuilderExtensions.cs#L14)
- Example of Registration: [Program.cs Line 55](DiExtensionDemo.Api/Program.cs#L55)

### Pros

- When managed properly, upgrades to services package will not break consumer builds.
- Reduces boilerplate in consumers; each consuming application will only need to call a single method to register all required dependencies.

### Cons

- Service layer is coupled to dependency injection provider.
- Services are provided as an "all or nothing" package. While this is reasonable if there is a single known consumer, if there are multiple consumers that each leverage their own set of services within the package, unused services might be registered.
- Introduces risk of service package being updated without the proper dependency configuration.
  - While not a "new" risk, it does separate the point of failure from the entry point, meaning if someone forgets to register new dependencies, it won't be obvious until the new package is installed into the consumer. Fixes would require another service layer update.
  - Can be mitigated with unit tests.

## Option #3

Service package exposes methods of registering "batches" of services. Each batch contains one or more service(s) and defines its own dependency tree; consumer is responsible for adding individual batches.

- Example of Implementation: [ServiceBuilderExtensions.cs Line 26](DiExtensionDemo.Services/Extensions/ServiceBuilderExtensions.cs#L26)
- Example of Registration: [Program.cs Line 66](DiExtensionDemo.Api/Program.cs#L66)

### Pros

- Allows for more control at the consumer level -- each consumer can define which services it needs and sub-dependencies will be injected automatically.
- Somewhat reduces boilerplate in consumers.
- When managed properly, upgrades to services package will not break consumer builds.
- Batches can be flexible, e.g. dependencies can be defined per service (`AddUser`, `AddProfile`), by area of application (`AddSecurity`), or by defined consumer (`AddServicesForMyApp1`, where `MyApp1` is a consuming application), although the latter couples the service layer to its anticipated consumers.

### Cons

- Service layer is coupled to dependency injection provider.
- See "Introduces risk of service package..." under Option #2 Cons.
- Depending on the DI provider, potentially introduces risk of conflict when multiple services are registered by multiple batches.