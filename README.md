# CopySourceGenerator
[WiP]
Used to create copies of records (by default iQuery or iCommand) for modular monolith architecture.
Without creating references, it adds a copy along with submodels, generics and enums to an additional library that does not have references to the library from which the code is created.
This allows to maintain independence between libraries (modules)

TODO:
- Change the way the path is pulled for saving (currently you have to specify it in the code)
- Add versioning and checking to prevent unnecessary file generation
- Add deletion of unnecessary copies


