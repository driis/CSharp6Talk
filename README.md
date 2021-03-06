# What's new in C#6 ?

Based on: https://github.com/dotnet/roslyn/wiki/Languages-features-in-C%23-6-and-VB-14

Agenda of this talk:
## `using` static members
* `using` Can now bring static members into scope
* Should probably be used sparingly

## String interpolation
* Known from a lot of other languages (Ruby ...)
* String formatting made easy

## Null propagation
* Use new `.?` operator if something might be null ...

## Auto-properties
* Getter-only auto-properties
* Auto-property initializers
* Ctor assignment to getter-only autoprops

## Expression-bodied members
- A member can be implemented by an expression

## Exceptions
* Await in catch/finally
* Exception filters

## Other small improvements
* `nameof` operator
* Dictionary initializer
