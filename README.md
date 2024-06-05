# CopySourceGenerator
[WiP]
Used to create copies of records (by default iQuery or iCommand) for modular monolith architecture.
Without creating references, it adds a copy along with submodels, generics and enums to an additional library that does not have references to the library from which the code is created.
This allows to maintain independence between libraries (modules)

TODO:
- Maybe fix the way to get the path to the directory. Now it uses a pre-build event, so on the first compilation there is an error
- Add versioning and checking to prevent unnecessary file generation
- Fix nullable parameters (Nullable<T> -> T?)
